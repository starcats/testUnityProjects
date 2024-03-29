﻿using UnityEngine;
using System.Collections;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// longを乗算する。
	/// </summary>
#else
	/// <summary>
	/// Multiply by long.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Long/Long.Mul")]
	[BehaviourTitle("Long.Mul")]
	[BuiltInBehaviour]
	public sealed class LongMulCalculator : Calculator
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 値1
		/// </summary>
#else
		/// <summary>
		/// Value 1
		/// </summary>
#endif
		[SerializeField] private FlexibleLong _Value1 = new FlexibleLong();

#if ARBOR_DOC_JA
		/// <summary>
		/// 値2
		/// </summary>
#else
		/// <summary>
		/// Value 2
		/// </summary>
#endif
		[SerializeField] private FlexibleLong _Value2 = new FlexibleLong();

#if ARBOR_DOC_JA
		/// <summary>
		/// 結果出力
		/// </summary>
#else
		/// <summary>
		/// Result output
		/// </summary>
#endif
		[SerializeField] private OutputSlotLong _Result = new OutputSlotLong();

		#endregion // Serialize fields

		// Use this for calculate
		public override void OnCalculate()
		{
			_Result.SetValue(_Value1.value * _Value2.value);
		}
	}
}
