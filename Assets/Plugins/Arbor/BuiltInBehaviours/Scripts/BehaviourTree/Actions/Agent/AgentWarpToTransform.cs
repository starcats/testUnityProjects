using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.BehaviourTree.Actions
{
#if ARBOR_DOC_JA
	/// <summary>
	/// AgentをTargetの位置にワープする。
	/// </summary>
	/// <remarks>成功した場合はTrueを返し、そうでなければFalseを返す。</remarks>
#else
	/// <summary>
	/// Warp the Agent to the Target position.
	/// </summary>
	/// <remarks>Returns true if successful, otherwise returns false.</remarks>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Agent/AgentWarpToTransform")]
	[BuiltInBehaviour]
	public class AgentWarpToTransform : AgentBase
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 対象のTransform
		/// </summary>
#else
		/// <summary>
		/// Target Transform
		/// </summary>
#endif
		[SerializeField]
		private FlexibleTransform _TargetTransform = new FlexibleTransform();

		#endregion // Serialize fields

		protected override void OnExecute()
		{
			bool result = false;
			AgentController agentController = cachedAgentController;
			Transform targetTransform = _TargetTransform.value;
			if (targetTransform != null && agentController != null)
			{
				result = agentController.Warp(targetTransform.position);
			}
			FinishExecute(result);
		}
	}
}