using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.BehaviourTree.Actions
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Waypointに沿ってAgentを移動させる。
	/// </summary>
#else
	/// <summary>
	/// Move the Agent along the Waypoint.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Agent/AgentMoveOnWaypoint")]
	[BuiltInBehaviour]
	public class AgentMoveOnWaypoint : AgentMoveBase
	{
		#region Serialize fields
		
#if ARBOR_DOC_JA
		/// <summary>
		/// Agentを移動させる経路
		/// </summary>
#else
		/// <summary>
		/// Route to move Agent
		/// </summary>
#endif
		[SerializeField]
		[SlotType(typeof(Waypoint))]
		private FlexibleComponent _Waypoint = new FlexibleComponent();

#if ARBOR_DOC_JA
		/// <summary>
		/// 再生タイプ。
		/// </summary>
#else
		/// <summary>
		/// Play type.
		/// </summary>
#endif
		[SerializeField]
		private MoveWaypointType _Type = MoveWaypointType.Once;

#if ARBOR_DOC_JA
		/// <summary>
		/// 停止する距離
		/// </summary>
#else
		/// <summary>
		/// Distance to stop
		/// </summary>
#endif
		[SerializeField] private FlexibleFloat _StoppingDistance = new FlexibleFloat(0f);

		#endregion // Serialize fields

		private int _DestPoint = 0;
		private bool _Reverse = false;
		private bool _IsDone = false;

		void GotoNextPoint(bool moveDone)
		{
			AgentController agentController = cachedAgentController;
			Waypoint waypoint = _Waypoint.value as Waypoint;
			if (waypoint == null || waypoint.pointCount == 0 || agentController == null || _IsDone)
			{
				return;
			}

			if (moveDone)
			{
				if (!_Reverse)
				{
					_DestPoint++;
					if (_DestPoint >= waypoint.pointCount)
					{
						switch (_Type)
						{
							case MoveWaypointType.Once:
								_IsDone = true;
								_DestPoint = 0;
								return;
							case MoveWaypointType.Cycle:
								_DestPoint = 0;
								break;
							case MoveWaypointType.PingPong:
								_DestPoint = waypoint.pointCount - 1;
								_Reverse = !_Reverse;
								break;
						}
					}
				}
				else
				{
					_DestPoint--;
					if (_DestPoint < 0)
					{
						switch (_Type)
						{
							case MoveWaypointType.Once:
								_IsDone = true;
								_DestPoint = 0;
								return;
							case MoveWaypointType.Cycle:
								_DestPoint = waypoint.pointCount - 1;
								break;
							case MoveWaypointType.PingPong:
								_DestPoint = 1;
								_Reverse = !_Reverse;
								break;
						}
					}
				}
			}

			agentController.Follow(_Speed.value, _StoppingDistance.value, waypoint.GetPoint(_DestPoint));
		}
		
		protected override void OnStart()
		{
			base.OnStart();

			_IsDone = false;
			GotoNextPoint(false);
		}

		protected override void OnExecute()
		{
			AgentController agentController = cachedAgentController;
			if (agentController != null && agentController.isDone)
			{
				GotoNextPoint(true);
				if (_IsDone)
				{
					FinishExecute(true);
				}
			}
		}
	}
}