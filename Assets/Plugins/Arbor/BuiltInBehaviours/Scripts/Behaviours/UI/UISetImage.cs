using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// ImageにSpriteを設定する。
	/// </summary>
#else
	/// <summary>
	/// Set the Sprite to Image.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("UI/UISetImage")]
	[BuiltInBehaviour]
	public sealed class UISetImage : StateBehaviour, INodeBehaviourSerializationCallbackReceiver
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 対象となるImage。<br/>
		/// 指定しない場合は、ArborFSMと同じGameObjectに割り当てられているImage。
		/// </summary>
#else
		/// <summary>
		/// Image of interest.<br/>
		/// If not specified, Image of GameObject that ArborFSM is assigned a target.
		/// </summary>
#endif
		[SerializeField]
		[SlotType(typeof(Image))]
		private FlexibleComponent _Image = new FlexibleComponent();

#if ARBOR_DOC_JA
		/// <summary>
		/// 設定するSprite
		/// </summary>
#else
		/// <summary>
		/// Sprite to be set
		/// </summary>
#endif
		[SerializeField] private Sprite _Sprite = null;

		[SerializeField]
		[HideInInspector]
		private int _SerializeVersion = 0;

		#region old

		[SerializeField]
		[FormerlySerializedAs("_Image")]
		[HideInInspector]
		private Image _OldImage = null;

		#endregion // old

		#endregion // Serialize fields

		private Image _MyImage;
		public Image cachedImage
		{
			get
			{
				Image image = _Image.value as Image;
				if (image == null && _Image.type == FlexibleType.Constant)
				{
					if (_MyImage == null)
					{
						_MyImage = GetComponent<Image>();
					}

					image = _MyImage;
				}
				return image;
			}
		}
		
		// Use this for enter state
		public override void OnStateBegin()
		{
			Image image = cachedImage;
			if (image != null)
			{
				image.sprite = _Sprite;
			}
		}

		void SerializeVer1()
		{
			_Image = (FlexibleComponent)_OldImage;
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
