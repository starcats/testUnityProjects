using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.BehaviourTree.Actions
{
#if ARBOR_DOC_JA
	/// <summary>
	/// 指定位置の周辺を巡回させる。
	/// </summary>
#else
	/// <summary>
	/// To patrol the vicinity of the specified location.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Agent/AgentPatrol")]
	[BuiltInBehaviour]
	public class AgentPatrol : AgentMoveBase
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 移動半径
		/// </summary>
#else
		/// <summary>
		/// Moving radius
		/// </summary>
#endif
		[SerializeField]
		private FlexibleFloat _Radius = new FlexibleFloat();

#if ARBOR_DOC_JA
		/// <summary>
		/// パトロールする中心タイプ
		/// </summary>
#else
		/// <summary>
		/// Center type to patrol
		/// </summary>
#endif
		[SerializeField]
		private PatrolCenterType _CenterType = PatrolCenterType.InitialPlacementPosition;

#if ARBOR_DOC_JA
		/// <summary>
		/// 中心Transformの指定(CenterTypeがTransformのみ)
		/// </summary>
#else
		/// <summary>
		/// Specifying the center transform (CenterType is Transform only)
		/// </summary>
#endif
		[SerializeField]
		private FlexibleTransform _CenterTransform = new FlexibleTransform();

#if ARBOR_DOC_JA
		/// <summary>
		/// 中心の指定(CenterTypeがCustomのみ)
		/// </summary>
#else
		/// <summary>
		/// Specify the center (CenterType is Custom only)
		/// </summary>
#endif
		[SerializeField]
		private FlexibleVector3 _CenterPosition = new FlexibleVector3();

		#endregion // Serialize fields

		Vector3 _ActionStartPosition;

		protected override void OnStart()
		{
			base.OnStart();

			AgentController agentController = cachedAgentController;
			if (agentController != null)
			{
				_ActionStartPosition = agentController.agentTransform.position;
			}
		}

		protected override void OnExecute()
		{
			AgentController agentController = cachedAgentController;
			if (agentController != null)
			{
				switch (_CenterType)
				{
					case PatrolCenterType.InitialPlacementPosition:
						agentController.Patrol(_Speed.value, _Radius.value);
						break;
					case PatrolCenterType.StateStartPosition:
						agentController.Patrol(_ActionStartPosition,_Speed.value, _Radius.value);
						break;
					case PatrolCenterType.Transform:
						Transform centerTransform = _CenterTransform.value;
						if (centerTransform != null)
						{
							agentController.Patrol(centerTransform.position, _Speed.value, _Radius.value);
						}
						break;
					case PatrolCenterType.Custom:
						agentController.Patrol(_CenterPosition.value, _Speed.value, _Radius.value);
						break;
				}
			}
		}
	}
}