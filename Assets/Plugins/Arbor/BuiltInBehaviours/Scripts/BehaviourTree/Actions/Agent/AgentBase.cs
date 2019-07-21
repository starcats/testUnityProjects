using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.BehaviourTree.Actions
{
	[AddComponentMenu("")]
	[HideBehaviour()]
	public class AgentBase : ActionBehaviour
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 制御したいAgentController。<br/>
		/// 指定しない場合はBehaviourTreeを割り当ててあるGameObjectのAgentController。
		/// </summary>
#else
		/// <summary>
		/// AgentController you want to control.<br/>
		/// If not specified, BehaviourTree is assigned to the AgentController in the GameObject.
		/// </summary>
#endif
		[SerializeField]
		[SlotType(typeof(AgentController))]
		protected FlexibleComponent _AgentController = new FlexibleComponent();

		#endregion // Serialize fields

		private AgentController _MyAgentController;
		public AgentController cachedAgentController
		{
			get
			{
				AgentController agentController = _AgentController.value as AgentController;
				if (agentController == null && _AgentController.type == FlexibleType.Constant)
				{
					if (_MyAgentController == null)
					{
						_MyAgentController = GetComponent<AgentController>();
					}

					agentController = _MyAgentController;
				}
				return agentController;
			}
		}

		protected override void OnStart()
		{
			AgentController agentController = cachedAgentController;
			if (agentController == null)
			{
				Debug.LogWarning(actionNode.name + " : AgentController is not set.", behaviourTree);
			}
		}
	}
}
