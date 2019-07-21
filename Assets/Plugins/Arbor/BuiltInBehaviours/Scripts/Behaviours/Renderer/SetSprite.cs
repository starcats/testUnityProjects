using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Spriteを設定する。
	/// </summary>
#else
	/// <summary>
	/// Set the Sprite.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Renderer/SetSprite")]
	[BuiltInBehaviour]
	public sealed class SetSprite : StateBehaviour, INodeBehaviourSerializationCallbackReceiver
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 対象となるSpriteRenderer。<br/>
		/// 指定しない場合はArborFSMを割り当ててあるGameObjectのSpriteRenderer。
		/// </summary>
#else
		/// <summary>
		/// SpriteRenderer of interest.<br/>
		/// If not specified, the SpriteRenderer of the GameObject to which ArborFSM is assigned.
		/// </summary>
#endif
		[SerializeField]
		[SlotType(typeof(SpriteRenderer))]
		private FlexibleComponent _Target = new FlexibleComponent();

#if ARBOR_DOC_JA
		/// <summary>
		/// 設定するSprite。
		/// </summary>
#else
		/// <summary>
		/// Setting Sprite that.
		/// </summary>
#endif
		[SerializeField] private Sprite _Sprite = null;

		[SerializeField]
		[HideInInspector]
		private int _SerializeVersion = 0;

		#region old

		[FormerlySerializedAs("_Target")]
		[SerializeField]
		[HideInInspector]
		private SpriteRenderer _OldTarget = null;

		#endregion // old

		#endregion // Serialize fields

		private SpriteRenderer _MySpriteRenderer;
		public SpriteRenderer cachedSpriteRenderer
		{
			get
			{
				SpriteRenderer spriteRenderer = _Target.value as SpriteRenderer;
				if (spriteRenderer == null && _Target.type == FlexibleType.Constant)
				{
					if (_MySpriteRenderer == null)
					{
						_MySpriteRenderer = GetComponent<SpriteRenderer>();
					}

					spriteRenderer = _MySpriteRenderer;
				}
				return spriteRenderer;
			}
		}

		// Use this for enter state
		public override void OnStateBegin()
		{
			SpriteRenderer spriteRenderer = cachedSpriteRenderer;
			if (spriteRenderer != null)
			{
				spriteRenderer.sprite = _Sprite;
			}
		}

		void SerializeVer1()
		{
			_Target = (FlexibleComponent)_OldTarget;
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
