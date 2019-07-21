using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// GameObjectのアクティブを切り替える。
	/// </summary>
#else
	/// <summary>
	/// It will switch the active GameObject.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("GameObject/ActivateGameObject")]
	[BuiltInBehaviour]
	public sealed class ActivateGameObject : StateBehaviour,INodeBehaviourSerializationCallbackReceiver
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// アクティブを切り替えるGameObject。
		/// </summary>
#else
		/// <summary>
		/// GameObject to switch the active.
		/// </summary>
#endif
		[SerializeField]
		private FlexibleGameObject _Target = new FlexibleGameObject();

#if ARBOR_DOC_JA
		/// <summary>
		/// ステート開始時のアクティブ切り替え。
		/// </summary>
#else
		/// <summary>
		/// Active switching at the state start.
		/// </summary>
#endif
		[SerializeField]
		private bool _BeginActive = false;

#if ARBOR_DOC_JA
		/// <summary>
		/// ステート終了時のアクティブ切り替え。
		/// </summary>
#else
		/// <summary>
		/// Active switching at the state end.
		/// </summary>
#endif
		[SerializeField]
		private bool _EndActive = false;

		[SerializeField]
		[HideInInspector]
		private int _SerializeVersion = 0;

		#region old

		[FormerlySerializedAs("_Target")]
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
				target.SetActive( _BeginActive );
			}
		}

		public override void OnStateEnd()
		{
			if(target != null )
			{
				target.SetActive( _EndActive );
			}
		}
	}
}
