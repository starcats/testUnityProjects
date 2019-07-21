﻿using UnityEngine;
using System.Collections;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Boundsに設定した位置が、バウンディングボックスに含まれているか判定する。
	/// </summary>
#else
	/// <summary>
	/// Is point contained in the bounding box?
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Bounds/Bounds.Contains")]
	[BehaviourTitle("Bounds.Contains")]
	[BuiltInBehaviour]
	public sealed class BoundsContainsCalculator : Calculator
	{
		#region Serialize fields

		/// <summary>
		/// Bounds
		/// </summary>
		[SerializeField] private FlexibleBounds _Bounds = new FlexibleBounds();

#if ARBOR_DOC_JA
		/// <summary>
		/// 位置
		/// </summary>
#else
		/// <summary>
		/// Point
		/// </summary>
#endif
		[SerializeField] private FlexibleVector3 _Point = new FlexibleVector3();

#if ARBOR_DOC_JA
		/// <summary>
		/// 結果出力
		/// </summary>
#else
		/// <summary>
		/// Result output
		/// </summary>
#endif
		[SerializeField] private OutputSlotBool _Result = new OutputSlotBool();

		#endregion // Serialize fields

		// Use this for calculate
		public override void OnCalculate()
		{
			_Result.SetValue(_Bounds.value.Contains(_Point.value));
		}
	}
}
