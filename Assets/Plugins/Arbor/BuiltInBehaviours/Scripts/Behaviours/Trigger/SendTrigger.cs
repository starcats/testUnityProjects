using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// トリガーを送る。
	/// </summary>
#else
	/// <summary>
	/// It will send a trigger.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Trigger/SendTrigger")]
	[BuiltInBehaviour]
	public sealed class SendTrigger : StateBehaviour, INodeBehaviourSerializationCallbackReceiver
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// トリガーを送る対象。
		/// </summary>
#else
		/// <summary>
		/// Subject to send a trigger.
		/// </summary>
#endif
		[SerializeField]
		[ClassExtends(typeof(ArborFSM))]
		private FlexibleComponent _Target = new FlexibleComponent((Component)null);

#if ARBOR_DOC_JA
		/// <summary>
		/// 送るトリガー
		/// </summary>
#else
		/// <summary>
		/// Trigger to send
		/// </summary>
#endif
		[SerializeField] private FlexibleString _Message = new FlexibleString(string.Empty);

		[SerializeField]
		[HideInInspector]
		private int _SerializeVersion = 0;

		#region old

		[FormerlySerializedAs("_Target")]
		[SerializeField]
		[HideInInspector]
		private ArborFSM _OldTarget = null;

		[FormerlySerializedAs("_Message")]
		[SerializeField]
		[HideInInspector]
		private string _OldMessage = string.Empty;

		#endregion // old

		#endregion // Serialize fields

		private const int kCurrentSerializeVersion = 1;

		public override void OnStateBegin()
		{
			ArborFSM target = _Target.value as ArborFSM;
			if (target != null)
			{
				target.SendTrigger(_Message.value);
			}
		}

		void SerializeVer1()
		{
			_Target = (FlexibleComponent)_OldTarget;
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
					default:
						_SerializeVersion = kCurrentSerializeVersion;
						break;
				}
			}
		}

		void INodeBehaviourSerializationCallbackReceiver.OnAfterDeserialize()
		{
			Serialize();
		}

		void INodeBehaviourSerializationCallbackReceiver.OnBeforeSerialize()
		{
			Serialize();
		}
	}
}
