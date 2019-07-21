using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Time.timeScaleを徐々に変化させる。
	/// </summary>
#else
	/// <summary>
	/// Tween Time.timeScale.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Tween/TweenTimeScale")]
	[BuiltInBehaviour]
	public sealed class TweenTimeScale : TweenBase
	{
		#region Serialize fields

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
		[SerializeField] private FlexibleFloat _From = new FlexibleFloat(1.0f);

#if ARBOR_DOC_JA
		/// <summary>
		/// 目標値。
		/// </summary>
#else
		/// <summary>
		/// The goal value.
		/// </summary>
#endif
		[SerializeField] private FlexibleFloat _To = new FlexibleFloat(1.0f);

		#endregion // Serialize fields

		public override bool forceRealtime
		{
			get
			{
				return true;
			}
		}

		private float _CachedFromValue;
		private float _CachedToValue;

		protected override void OnTweenBegin()
		{
			_CachedFromValue = _From.value;
			_CachedToValue = _To.value;

			float startValue = Time.timeScale;

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
			Time.timeScale = Mathf.Lerp(_CachedFromValue, _CachedToValue, factor);
		}
	}
}
