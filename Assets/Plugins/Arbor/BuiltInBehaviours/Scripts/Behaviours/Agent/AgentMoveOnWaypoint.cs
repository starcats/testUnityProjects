using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.StateMachine.StateBehaviours
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
	public sealed class AgentMoveOnWaypoint : AgentBase
	{
#if ARBOR_DOC_JA
		/// <summary>
		/// 移動速度
		/// </summary>
#else
		/// <summary>
		/// Moving Speed
		/// </summary>
#endif
		[SerializeField]
		private float _Speed = 0f;

#if ARBOR_DOC_JA
		/// <summary>
		/// ステートから抜けるときに停止するかどうか
		/// </summary>
#else
		/// <summary>
		/// Whether to stop when leaving the state.
		/// </summary>
#endif
		[SerializeField] private bool _StopOnStateEnd = false;

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

#if ARBOR_DOC_JA
		/// <summary>
		/// 移動完了した時のステート遷移(Onceのみ)<br />
		/// 遷移メソッド : OnStateUpdate
		/// </summary>
#else
		/// <summary>
		/// State transition at the time of movement completion(only Once)<br />
		/// Transition Method : OnStateUpdate
		/// </summary>
#endif
		[SerializeField] private StateLink _Done = new StateLink();

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
								Transition(_Done);
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
								Transition(_Done);
								_IsDone = true;
								_DestPoint = 0;
								break;
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

			agentController.Follow(_Speed, _StoppingDistance.value, waypoint.GetPoint(_DestPoint));
		}
		
		// Use this for enter state
		public override void OnStateBegin()
		{
			_IsDone = false;
			GotoNextPoint(false);
		}

		// Use this for exit state
		public override void OnStateEnd()
		{
			AgentController agentController = cachedAgentController;
			if (_StopOnStateEnd && agentController != null)
			{
				agentController.Stop();
			}
		}

		// Update is called once per frame
		public override void OnStateUpdate()
		{
			AgentController agentController = cachedAgentController;
			if (agentController != null && agentController.isDone)
			{
				GotoNextPoint(true);
			}
		}
	}
}