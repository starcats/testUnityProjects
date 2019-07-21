﻿using UnityEngine;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
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
	public sealed class AgentStop : AgentBase
	{
		// Use this for enter state
		public override void OnStateBegin()
		{
			AgentController agentController = cachedAgentController;
			if (agentController != null)
			{
				agentController.Stop();
			}
		}
	}
}