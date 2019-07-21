using UnityEngine;
using System.Collections;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// 右上のアンカーを基準にした矩形の右上角のオフセット
	/// </summary>
#else
	/// <summary>
	/// The offset of the upper right corner of the rectangle relative to the upper right anchor.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("RectTransform/RectTransform.OffsetMax")]
	[BehaviourTitle("RectTransform.OffsetMax")]
	[BuiltInBehaviour]
	public sealed class RectTransformOffsetMaxCalculator : Calculator
	{
		#region Serialize fields

		/// <summary>
		/// RectTransform
		/// </summary>
		[SerializeField] private FlexibleRectTransform _RectTransform = new FlexibleRectTransform();

#if ARBOR_DOC_JA
		/// <summary>
		/// 矩形の右上角のオフセット
		/// </summary>
#else
		/// <summary>
		/// The offset of the upper right corner of the rectangle
		/// </summary>
#endif
		[SerializeField] private OutputSlotVector2 _OffsetMax = new OutputSlotVector2();

		#endregion // Serialize fields

		public override bool OnCheckDirty()
		{
			return true;
		}

		// Use this for calculate
		public override void OnCalculate()
		{
			RectTransform rectTransform = _RectTransform.value;
			if (rectTransform != null)
			{
				_OffsetMax.SetValue(rectTransform.offsetMax);
			}
		}
	}
}
