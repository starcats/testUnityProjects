using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.BehaviourTree.Actions
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Agentを停止させる
	/// </summary>
#else
	/// <summary>
	/// Stop the Agent
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Agent/AgentStop")]
	[BuiltInBehaviour]
	public class AgentStop : AgentBase
	{
		protected override void OnExecute()
		{
			AgentController agentController = cachedAgentController;
			if (agentController != null)
			{
				agentController.Stop();
			}
			FinishExecute(true);
		}
	}
}