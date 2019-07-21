using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

using Arbor.ObjectPooling;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// GameObjectを削除する。
	/// </summary>
#else
	/// <summary>
	/// It will remove the GameObject.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("GameObject/DestroyGameObject")]
	[BuiltInBehaviour]
    public sealed class DestroyGameObject : StateBehaviour, INodeBehaviourSerializationCallbackReceiver
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 削除するGameObject。
		/// </summary>
#else
		/// <summary>
		/// It will remove the GameObject.
		/// </summary>
#endif
		[SerializeField]
		private FlexibleGameObject _Target = new FlexibleGameObject();

		[SerializeField]
		[HideInInspector]
		private int _SerializeVersion;

		#region old

		[FormerlySerializedAs( "_Target" )]
		[SerializeField]
		[HideInInspector]
		private GameObject _OldTarget = null;

		#endregion // old

		#endregion // Serialize fields

		public GameObject target
		{
			get
			{
				return _Target.value;
			}
		}

		void SerializeVer1()
		{
			_Target = (FlexibleGameObject)_OldTarget;
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

		public override void OnStateBegin()
		{
			if(target != null )
			{
				ObjectPool.Destroy (target);
			}
		}
	}
}
