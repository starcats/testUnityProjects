using UnityEngine;
using System.Collections;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Transform のローカル空間で計算された矩形
	/// </summary>
#else
	/// <summary>
	/// The calculated rectangle in the local space of the Transform.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("RectTransform/RectTransform.Rect")]
	[BehaviourTitle("RectTransform.Rect")]
	[BuiltInBehaviour]
	public sealed class RectTransformRectCalculator : Calculator
	{
		#region Serialize fields

		/// <summary>
		/// RectTransform
		/// </summary>
		[SerializeField] private FlexibleRectTransform _RectTransform = new FlexibleRectTransform();

#if ARBOR_DOC_JA
		/// <summary>
		/// ローカル空間で計算された矩形
		/// </summary>
#else
		/// <summary>
		/// The calculated rectangle in the local space
		/// </summary>
#endif
		[SerializeField] private OutputSlotRect _Rect = new OutputSlotRect();

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
				_Rect.SetValue(rectTransform.rect);
			}
		}
	}
}
