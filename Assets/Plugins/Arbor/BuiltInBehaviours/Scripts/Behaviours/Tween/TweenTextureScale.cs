using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// TextureのTilingを徐々に変化させる。
	/// </summary>
#else
	/// <summary>
	/// Gradually change Tiling of Texture.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Tween/TweenTextureScale")]
	[BuiltInBehaviour]
	public sealed class TweenTextureScale : TweenBase
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
		private TweenMoveType _TweenMoveType = TweenMoveType.Absolute;

#if ARBOR_DOC_JA
		/// <summary>
		/// 開始値。
		/// </summary>
#else
		/// <summary>
		/// Start value.
		/// </summary>
#endif
		[SerializeField] private FlexibleVector2 _From = new FlexibleVector2(Vector2.one);

#if ARBOR_DOC_JA
		/// <summary>
		/// 目標値。
		/// </summary>
#else
		/// <summary>
		/// The goal value.
		/// </summary>
#endif
		[SerializeField] private FlexibleVector2 _To = new FlexibleVector2(Vector2.one);

		#endregion // Serialize fields

		private Renderer _MyRenderer;
		private Renderer _CachedTarget;

		private string _CachedPropertyName;

		private Vector2 _CachedFromValue;
		private Vector2 _CachedToValue;

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
			
			Vector2 startScale = Vector2.zero;
			if (_Block.isEmpty)
			{
				startScale = _CachedTarget.sharedMaterial.GetTextureScale(_CachedPropertyName);
			}
			else
			{
				Vector4 texST = _Block.GetVector(_CachedPropertyName + "_ST");
				startScale = new Vector2(texST.x, texST.y);
			}

			switch (_TweenMoveType)
			{
				case TweenMoveType.Absolute:
					break;
				case TweenMoveType.Relative:
					_CachedFromValue += startScale;
					_CachedToValue += startScale;
					break;
				case TweenMoveType.ToAbsolute:
					_CachedFromValue = startScale;
					break;
			}
		}

		protected override void OnTweenUpdate(float factor)
		{
			if (_CachedTarget != null)
			{
				Vector2 textureScale = Vector2.Lerp(_CachedFromValue, _CachedToValue, factor);

				if (_Block == null)
				{
					_Block = new MaterialPropertyBlock();
				}

				Vector4 texST = Vector4.zero;
				if (_Block.isEmpty)
				{
					Vector2 texOffset = _CachedTarget.sharedMaterial.GetTextureOffset(_CachedPropertyName);
					texST.z = texOffset.x;
					texST.w = texOffset.y;
				}
				else
				{
					texST = _Block.GetVector(_CachedPropertyName + "_ST");
				}

				texST.x = textureScale.x;
				texST.y = textureScale.y;

				_Block.SetVector(_CachedPropertyName + "_ST", texST);

				_CachedTarget.SetPropertyBlock(_Block);
			}
		}
	}
}
