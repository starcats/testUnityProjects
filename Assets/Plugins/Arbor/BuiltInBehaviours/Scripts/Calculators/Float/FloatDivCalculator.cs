﻿using UnityEngine;
using System.Collections;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// floatを除算する。
	/// </summary>
#else
	/// <summary>
	/// Divide the float.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Float/Float.Div")]
	[BehaviourTitle("Float.Div")]
	[BuiltInBehaviour]
	public sealed class FloatDivCalculator : Calculator
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
		[SerializeField] private FlexibleFloat _Value1 = new FlexibleFloat();

#if ARBOR_DOC_JA
		/// <summary>
		/// 値2
		/// </summary>
#else
		/// <summary>
		/// Value 2
		/// </summary>
#endif
		[SerializeField] private FlexibleFloat _Value2 = new FlexibleFloat();

#if ARBOR_DOC_JA
		/// <summary>
		/// 結果出力
		/// </summary>
#else
		/// <summary>
		/// Result output
		/// </summary>
#endif
		[SerializeField] private OutputSlotFloat _Result = new OutputSlotFloat();

		#endregion // Serialize fields

		// Use this for calculate
		public override void OnCalculate()
		{
            _Result.SetValue(_Value1.value / _Value2.value);
		}
	}
}
