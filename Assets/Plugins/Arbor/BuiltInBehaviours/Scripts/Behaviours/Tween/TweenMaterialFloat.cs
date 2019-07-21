using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// MaterialのFloat値を徐々に変化させる。
	/// </summary>
#else
	/// <summary>
	/// Tween Float value of material.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Tween/TweenMaterialFloat")]
	[BuiltInBehaviour]
	public sealed class TweenMaterialFloat : TweenBase
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
		[SerializeField] private FlexibleFloat _From = new FlexibleFloat(0.0f);

#if ARBOR_DOC_JA
		/// <summary>
		/// 目標値。
		/// </summary>
#else
		/// <summary>
		/// The goal value.
		/// </summary>
#endif
		[SerializeField] private FlexibleFloat _To = new FlexibleFloat(0.0f);

		#endregion // Serialize fields

		private Renderer _MyRenderer;
		private Renderer _CachedTarget;

		private string _CachedPropertyName;

		private float _CachedFromValue;
		private float _CachedToValue;

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
			
			float startValue = 0.0f;
			if (_Block.isEmpty)
			{
				startValue = _CachedTarget.sharedMaterial.GetFloat(_CachedPropertyName);
			}
			else
			{
				startValue = _Block.GetFloat(_CachedPropertyName);
			}

			switch (_TweenMoveType)
			{
				case TweenMoveType.Absolute:
					break;
				case TweenMoveType.Relative:
					_CachedFromValue += startValue;
					_CachedToValue += startValue;
					break;
				case TweenMoveType.ToAbsolute:
					_CachedFromValue = startValue;
					break;
			}
		}

		protected override void OnTweenUpdate(float factor)
		{
			if (_CachedTarget != null)
			{
				float value = Mathf.Lerp(_CachedFromValue, _CachedToValue, factor);

				if (_Block == null)
				{
					_Block = new MaterialPropertyBlock();
				}

				_Block.SetFloat(_CachedPropertyName, value);

				_CachedTarget.SetPropertyBlock(_Block);
			}
		}
	}
}
