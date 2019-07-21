using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// TextureのUV座標を徐々に変化させる。
	/// </summary>
#else
	/// <summary>
	/// Gradually change UV cordinates of Texture.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Tween/TweenTextureOffset")]
	[BuiltInBehaviour]
	public sealed class TweenTextureOffset : TweenBase
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 対象となるRenderer。<br/>
		/// 指定しない場合は、ArborFSMと同じGameObjectに割り当てられているRenderer。
		/// </summary>
#else
		/// <summary>
		/// Renderer of interest.<br/>
		/// If not specified, Renderer of GameObject that ArborFSM is assigned a target.
		/// </summary>
#endif
		[SerializeField]
		[SlotType(typeof(Renderer))]
		private FlexibleComponent _Target = new FlexibleComponent();

#if ARBOR_DOC_JA
		/// <summary>
		/// Textureのプロパティ名。
		/// </summary>
#else
		/// <summary>
		/// Property name of Texture.
		/// </summary>
#endif
		[SerializeField] private FlexibleString _PropertyName = new FlexibleString("_MainTex");

#if ARBOR_DOC_JA
		/// <summary>
		/// 開始した状態からの相対的な変化かどうか。
		/// </summary>
#else
		/// <summary>
		/// Whether the relative change from the start state.
		/// </summary>
#endif
		[SerializeField]
		[FormerlySerializedAs("_Relative")]
		private TweenMoveType _TweenMoveType = TweenMoveType.Absolute;

#if ARBOR_DOC_JA
		/// <summary>
		/// 開始UV座標。
		/// </summary>
#else
		/// <summary>
		/// Start UV coordinates.
		/// </summary>
#endif
		[SerializeField] private FlexibleVector2 _From = new FlexibleVector2();

#if ARBOR_DOC_JA
		/// <summary>
		/// 目標UV座標。
		/// </summary>
#else
		/// <summary>
		/// The goal UV coordinates.
		/// </summary>
#endif
		[SerializeField] private FlexibleVector2 _To = new FlexibleVector2();

		[SerializeField]
		[HideInInspector]
		private int _SerializeVersion;

		#region old

		[SerializeField]
		[FormerlySerializedAs("_Target")]
		[HideInInspector]
		private Renderer _OldTarget = null;

		[SerializeField]
		[FormerlySerializedAs("_PropertyName")]
		[HideInInspector]
		private string _OldPropertyName = "_MainTex";

		[SerializeField, FormerlySerializedAs( "_From" )]
		[HideInInspector]
		private Vector2 _OldFrom = Vector2.zero;

		[SerializeField, FormerlySerializedAs( "_To" )]
		[HideInInspector]
		private Vector2 _OldTo = Vector2.zero;

		#endregion // old

		#endregion // Serialize fields

		private Renderer _MyRenderer;
		private Renderer _CachedTarget;

		private string _CachedPropertyName;

		private Vector2 _CachedFromValue;
		private Vector2 _CachedToValue;

		private const int _CurrentSerializeVersion = 3;

		void SerializeVer1()
		{
			_From = (FlexibleVector2)_OldFrom;
			_To = (FlexibleVector2)_OldTo;
		}

		void SerializeVer2()
		{
			_Target = (FlexibleComponent)_OldTarget;
		}

		void SerlializeVer3()
		{
			_PropertyName = (FlexibleString)_OldPropertyName;
		}

		void Serialize()
		{
			while (_SerializeVersion != _CurrentSerializeVersion)
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
					case 2:
						SerlializeVer3();
						_SerializeVersion++;
						break;
					default:
						_SerializeVersion = _CurrentSerializeVersion;
						break;
				}
			}
		}

		public override void OnBeforeSerialize()
		{
			base.OnBeforeSerialize();

			Serialize();
		}

		public override void OnAfterDeserialize()
		{
			base.OnAfterDeserialize();

			Serialize();
		}

		MaterialPropertyBlock _Block = null;

		protected override void OnTweenBegin()
		{
			_CachedTarget = _Target.value as Renderer;
			if (_CachedTarget == null && _Target.type == FlexibleType.Constant)
			{
				if (_MyRenderer == null)
				{
					_MyRenderer = GetComponent<Renderer>();
				}

				_CachedTarget = _MyRenderer;
			}

			if (_CachedTarget == null)
			{
				return;
			}

			_CachedPropertyName = _PropertyName.value;

			_CachedFromValue = _From.value;
			_CachedToValue = _To.value;

			if (_Block == null)
			{
				_Block = new MaterialPropertyBlock();
			}
			
			_CachedTarget.GetPropertyBlock(_Block);
			
			Vector2 startOffset = Vector2.zero;
			if (_Block.isEmpty)
			{
				startOffset = _CachedTarget.sharedMaterial.GetTextureOffset(_CachedPropertyName);
			}
			else
			{
				Vector4 texST = _Block.GetVector(_CachedPropertyName + "_ST");
				startOffset = new Vector2(texST.z, texST.w);
			}

			switch (_TweenMoveType)
			{
				case TweenMoveType.Absolute:
					break;
				case TweenMoveType.Relative:
					_CachedFromValue += startOffset;
					_CachedToValue += startOffset;
					break;
				case TweenMoveType.ToAbsolute:
					_CachedFromValue = startOffset;
					break;
			}
		}

		protected override void OnTweenUpdate(float factor)
		{
			if (_CachedTarget != null)
			{
				Vector2 textureOffset = Vector2.Lerp(_CachedFromValue, _CachedToValue, factor);

				if (_Block == null)
				{
					_Block = new MaterialPropertyBlock();
				}

				Vector4 texST = Vector4.zero;
				if (_Block.isEmpty)
				{
					Vector2 texScale = _CachedTarget.sharedMaterial.GetTextureScale(_CachedPropertyName);
					texST.x = texScale.x;
					texST.y = texScale.y;
				}
				else
				{
					texST = _Block.GetVector(_CachedPropertyName + "_ST");
				}

				texST.z = textureOffset.x;
				texST.w = textureOffset.y;

				_Block.SetVector(_CachedPropertyName + "_ST", texST);

				_CachedTarget.SetPropertyBlock(_Block);
			}
		}
	}
}
