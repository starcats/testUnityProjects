using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// GameObjectに割り当てられているすべてのArborFSMにトリガーを送ります。
	/// </summary>
#else
	/// <summary>
	/// Send the trigger to all of ArborFSM that is assigned to the GameObject.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Trigger/SendTriggerGameObject")]
	[BuiltInBehaviour]
	public sealed class SendTriggerGameObject : StateBehaviour, INodeBehaviourSerializationCallbackReceiver
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 対象のGameObject
		/// </summary>
#else
		/// <summary>
		/// GameObject target
		/// </summary>
#endif
		[SerializeField]
		private FlexibleGameObject _Target = new FlexibleGameObject();

#if ARBOR_DOC_JA
		/// <summary>
		/// 送るトリガー
		/// </summary>
#else
		/// <summary>
		/// Trigger to send
		/// </summary>
#endif
		[SerializeField]
		private FlexibleString _Message = new FlexibleString(string.Empty);

		[SerializeField]
		[HideInInspector]
		private int _SerializeVersion = 0;

		#region old

		[FormerlySerializedAs("_Target")]
		[SerializeField]
		[HideInInspector]
		private GameObject _OldTarget = null;

		[FormerlySerializedAs("_Message")]
		[SerializeField]
		[HideInInspector]
		private string _OldMessage = string.Empty;

		#endregion // old

		#endregion // Serialize fields

		private const int kCurrentSerializeVersion = 2;

		public GameObject target
		{
			get
			{
				return _Target.value;
			}
		}

		public override void OnStateBegin()
		{
			GameObject target = this.target;
			string message = _Message.value;

			if (target != null)
			{
				foreach (ArborFSM fsm in target.GetComponents<ArborFSM>())
				{
					if (fsm.parentGraph == null)
					{
						fsm.SendTrigger(message);
					}
				}
			}
		}

		void SerializeVer1()
		{
			_Target = (FlexibleGameObject)_OldTarget;
		}

		void SerializeVer2()
		{
			_Message = (FlexibleString)_OldMessage;
		}

		void Serialize()
		{
			while (_SerializeVersion != kCurrentSerializeVersion)
			{
				switch (_SerializeVersion)
				{
					case 0:
						SerializeVer1();
						_SerializeVersion++;
						break;
					case 1:
						SerializeVer2();
						_SerializeVersion++;
						break;
					default:
						_SerializeVersion = kCurrentSerializeVersion;
						break;
				}
			}
		}

		void INodeBehaviourSerializationCallbackReceiver.OnBeforeSerialize()
		{
			Serialize();
		}

		void INodeBehaviourSerializationCallbackReceiver.OnAfterDeserialize()
		{
			Serialize();
		}
	}
}
