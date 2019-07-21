using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.BehaviourTree.Actions
{
#if ARBOR_DOC_JA
	/// <summary>
	/// AgentをTargetに近づくように移動させる。
	/// </summary>
#else
	/// <summary>
	/// Move Agent so that it approaches Target.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Agent/AgentMoveToPosition")]
	[BuiltInBehaviour]
	public class AgentMoveToPosition : AgentMoveBase
	{
		#region Serialize fields
		
#if ARBOR_DOC_JA
		/// <summary>
		/// 停止する距離
		/// </summary>
#else
		/// <summary>
		/// Distance to stop
		/// </summary>
#endif
		[SerializeField]
		private FlexibleFloat _StoppingDistance = new FlexibleFloat();

#if ARBOR_DOC_JA
		/// <summary>
		/// 対象の位置
		/// </summary>
#else
		/// <summary>
		/// Target position
		/// </summary>
#endif
		[SerializeField]
		private FlexibleVector3 _TargetPosition = new FlexibleVector3();
		
		#endregion // Serialize fields

		protected override void OnExecute()
		{
			AgentController agentController = cachedAgentController;
			if (agentController != null)
			{
				agentController.Follow(_Speed.value, _StoppingDistance.value, _TargetPosition.value);

				if (agentController.isDone)
				{
					FinishExecute(true);
				}
			}
			else
			{
				FinishExecute(false);
			}
		}
	}
}