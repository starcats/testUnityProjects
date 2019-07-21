using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
	[AddComponentMenu("")]
	[HideBehaviour()]
	public class AgentBase : StateBehaviour, INodeBehaviourSerializationCallbackReceiver
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 制御したいAgentController。<br/>
		/// 指定しない場合はArborFSMを割り当ててあるGameObjectのAgentController。
		/// </summary>
#else
		/// <summary>
		/// AgentController you want to control.<br/>
		/// If not specified, ArborFSM is assigned to the AgentController in the GameObject.
		/// </summary>
#endif
		[SerializeField]
		[SlotType(typeof(AgentController))]
		protected FlexibleComponent _AgentController = new FlexibleComponent();

		[SerializeField]
		[HideInInspector]
		private int _SerializeVersion;

		#region old

		[FormerlySerializedAs("_AgentController")]
		[SerializeField]
		[HideInInspector]
		protected AgentController _OldAgentController;

		#endregion // old

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

		void SerializeVer1()
		{
			_AgentController = (FlexibleComponent)_OldAgentController;
		}

		void INodeBehaviourSerializationCallbackReceiver.OnBeforeSerialize()
		{
			if (_SerializeVersion == 0)
			{
				SerializeVer1();
				_SerializeVersion = 1;
			}
		}

		void INodeBehaviourSerializationCallbackReceiver.OnAfterDeserialize()
		{
			if (_SerializeVersion == 0)
			{
				SerializeVer1();
			}
		}
	}
}