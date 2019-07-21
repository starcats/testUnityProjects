using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// AnimatorにアクセスするためのStateBehaviour基本クラス
	/// </summary>
#else
	/// <summary>
	/// Transit the state of Animator.
	/// </summary>
	/// <remarks></remarks>
#endif
	[AddComponentMenu("")]
	[HideBehaviour()]
	public class AnimatorBase : StateBehaviour, INodeBehaviourSerializationCallbackReceiver
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 対象のAnimator
		/// </summary>
#else
		/// <summary>
		/// Animator of target
		/// </summary>
#endif
		[SerializeField]
		[SlotType(typeof(Animator))]
		private FlexibleComponent _Animator = new FlexibleComponent();

		[SerializeField]
		[HideInInspector]
		private int _SerializeVersion;

		#region old

		[FormerlySerializedAs("animator")]
		[SerializeField]
		[HideInInspector]
		protected Animator _OldAnimator;

		#endregion // old

		#endregion // Serialize fields

		private Animator _MyAnimator;
		public Animator cachedAnimator
		{
			get
			{
				Animator animator = _Animator.value as Animator;
				if (animator == null && _Animator.type == FlexibleType.Constant)
				{
					if (_MyAnimator == null)
					{
						_MyAnimator = GetComponent<Animator>();
					}

					animator = _MyAnimator;
				}
				return animator;
			}
		}

		public static int GetLayerIndex(Animator animator, string layerName)
		{
			for (int i = 0; i < animator.layerCount; i++)
			{
				if (animator.GetLayerName(i) == layerName)
				{
					return i;
				}
			}

			return -1;
		}

		void SerializeVer1()
		{
			_Animator = (FlexibleComponent)_OldAnimator;
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
