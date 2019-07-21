using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// MaterialのVector2を徐々に変化させる。
	/// </summary>
#else
	/// <summary>
	/// Tween Vector2 of Material.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Tween/TweenMaterialVector2")]
	[BuiltInBehaviour]
	public sealed class TweenMaterialVector2 : TweenBase
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
		[SerializeField] private FlexibleString _PropertyName = new FlexibleString("");

#if ARBOR_DOC_JA
		/// <summary>
		/// Vector2のテクスチャ座標タイプ。
		/// </summary>
#else
		/// <summary>
		/// Texcoord Vector2 Type.
		/// </summary>
#endif
		[SerializeField]
		private TexcoordVector2Type _TexcoordVector2Type = TexcoordVector2Type.XY;

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
		[SerializeField] private FlexibleVector2 _From = new FlexibleVector2(Vector2.zero);

#if ARBOR_DOC_JA
		/// <summary>
		/// 目標値。
		/// </summary>
#else
		/// <summary>
		/// The goal value.
		/// </summary>
#endif
		[SerializeField] private FlexibleVector2 _To = new FlexibleVector2(Vector2.zero);

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

			Vector4 vector = Vector4.zero;
			if (_Block.isEmpty)
			{
				vector = _CachedTarget.sharedMaterial.GetVector(_CachedPropertyName);
			}
			else
			{
				vector = _Block.GetVector(_CachedPropertyName);
			}

			Vector2 startVector = Vector2.zero;
			switch (_TexcoordVector2Type)
			{
				case TexcoordVector2Type.XY:
					startVector.x = vector.x;
					startVector.y = vector.y;
					break;
				case TexcoordVector2Type.ZW:
					startVector.x = vector.z;
					startVector.y = vector.w;
					break;
			}

			switch (_TweenMoveType)
			{
				case TweenMoveType.Absolute:
					break;
				case TweenMoveType.Relative:
					_CachedFromValue += startVector;
					_CachedToValue += startVector;
					break;
				case TweenMoveType.ToAbsolute:
					_CachedFromValue = startVector;
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

				Vector4 vector = Vector4.zero;
				if (_Block.isEmpty)
				{
					vector = _CachedTarget.sharedMaterial.GetVector(_CachedPropertyName);
				}
				else
				{
					vector = _Block.GetVector(_CachedPropertyName);
				}

				switch (_TexcoordVector2Type)
				{
					case TexcoordVector2Type.XY:
						vector.x = textureScale.x;
						vector.y = textureScale.y;
						break;
					case TexcoordVector2Type.ZW:
						vector.z = textureScale.x;
						vector.w = textureScale.y;
						break;
				}

				_Block.SetVector(_CachedPropertyName, vector);

				_CachedTarget.SetPropertyBlock(_Block);
			}
		}
	}
}
