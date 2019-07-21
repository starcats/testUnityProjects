using UnityEngine;
using System.Collections;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// 右上の角をアンカーした親 RectTransform で正規化された位置
	/// </summary>
#else
	/// <summary>
	/// The normalized position in the parent RectTransform that the upper right corner is anchored to.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("RectTransform/RectTransform.AnchorMax")]
	[BehaviourTitle("RectTransform.AnchorMax")]
	[BuiltInBehaviour]
	public sealed class RectTransformAnchorMaxCalculator : Calculator
	{
		#region Serialize fields

		/// <summary>
		/// RectTransform
		/// </summary>
		[SerializeField] private FlexibleRectTransform _RectTransform = new FlexibleRectTransform();

#if ARBOR_DOC_JA
		/// <summary>
		/// アンカーの最大の位置
		/// </summary>
#else
		/// <summary>
		/// Maximum position of anchor
		/// </summary>
#endif
		[SerializeField] private OutputSlotVector2 _AnchorMax = new OutputSlotVector2();

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
				_AnchorMax.SetValue(rectTransform.anchorMax);
			}
		}
	}
}
