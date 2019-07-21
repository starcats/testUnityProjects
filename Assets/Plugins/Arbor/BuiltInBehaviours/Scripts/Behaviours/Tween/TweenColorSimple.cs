using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Rendererの色を徐々に変化させる。
	/// </summary>
#else
	/// <summary>
	/// Gradually change color of Renderer.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Tween/TweenColorSimple")]
	[BuiltInBehaviour]
	public sealed class TweenColorSimple : TweenBase
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
		/// Colorのプロパティ名。
		/// </summary>
#else
		/// <summary>
		/// Property name of Color.
		/// </summary>
#endif
		[SerializeField]
		private FlexibleString _PropertyName = new FlexibleString("_Color");

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
		/// 開始色。
		/// </summary>
#else
		/// <summary>
		/// Start color.
		/// </summary>
#endif
		[SerializeField] private FlexibleColor _From = new FlexibleColor(Color.white);

#if ARBOR_DOC_JA
		/// <summary>
		/// 目標色。
		/// </summary>
#else
		/// <summary>
		/// Target color.
		/// </summary>
#endif
		[SerializeField] private FlexibleColor _To = new FlexibleColor(Color.white);

		#endregion // Serialize fields

		private Renderer _MyRenderer;
		private Renderer _CachedTarget;

		private string _CachedPropertyName;

		private Color _CachedFromValue;
		private Color _CachedToValue;
		
		private MaterialPropertyBlock _Block = null;

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
			
			Color startColor = Color.clear;
			if (_Block.isEmpty)
			{
				startColor = _CachedTarget.sharedMaterial.GetColor(_CachedPropertyName);
			}
			else
			{
#if UNITY_2017_3_OR_NEWER
				startColor = _Block.GetColor(_CachedPropertyName);
#else
				startColor = _Block.GetVector(_CachedPropertyName);
#endif
			}

			switch (_TweenMoveType)
			{
				case TweenMoveType.Absolute:
					break;
				case TweenMoveType.Relative:
					_CachedFromValue += startColor;
					_CachedToValue += startColor;
					break;
				case TweenMoveType.ToAbsolute:
					_CachedFromValue = startColor;
					break;
			}
		}

		protected override void OnTweenUpdate (float factor)
		{
			if(_CachedTarget != null )
			{
				if (_Block == null)
				{
					_Block = new MaterialPropertyBlock();
				}

				Color color = Color.Lerp(_CachedFromValue, _CachedToValue, factor);

				_Block.SetColor(_CachedPropertyName, color);

				_CachedTarget.SetPropertyBlock(_Block);
			}
		}
	}
}
