using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// UIの色を徐々に変化させる。
	/// </summary>
#else
	/// <summary>
	/// Gradually change color of UI.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("UI/Tween/UITweenColorSimple")]
	[BuiltInBehaviour]
	public sealed class UITweenColorSimple : TweenBase
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 対象となるGraphic。<br/>
		/// 指定しない場合は、ArborFSMと同じGameObjectに割り当てられているGraphic。
		/// </summary>
#else
		/// <summary>
		/// Graphic of interest.<br/>
		/// If not specified, Graphic of GameObject that ArborFSM is assigned a target.
		/// </summary>
#endif
		[SerializeField]
		[SlotType(typeof(Graphic))]
		private FlexibleComponent _Target = new FlexibleComponent();

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

		private Graphic _MyGraphic;
		private Graphic _CachedTarget;

		private Color _CachedFromValue;
		private Color _CachedToValue;

		protected override void OnTweenBegin()
		{
			_CachedTarget = _Target.value as Graphic;
			if (_CachedTarget == null && _Target.type == FlexibleType.Constant)
			{
				if (_MyGraphic == null)
				{
					_MyGraphic = GetComponent<Graphic>();
				}

				_CachedTarget = _MyGraphic;
			}

			if (_CachedTarget == null)
			{
				return;
			}

			_CachedFromValue = _From.value;
			_CachedToValue = _To.value;

			Color startColor = _CachedTarget.color;

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
			if (_CachedTarget != null )
			{
				_CachedTarget.color = Color.Lerp(_CachedFromValue, _CachedToValue, factor);
			}
		}
	}
}
