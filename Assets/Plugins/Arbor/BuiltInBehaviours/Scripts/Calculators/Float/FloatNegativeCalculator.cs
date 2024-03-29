﻿using UnityEngine;
using System.Collections;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// floatの符号を反転する。
	/// </summary>
#else
	/// <summary>
	/// To invert the sign of the float.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Float/Float.Negative")]
	[BehaviourTitle("Float.Negative")]
	[BuiltInBehaviour]
	public sealed class FloatNegativeCalculator : Calculator
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 値
		/// </summary>
#else
		/// <summary>
		/// Value
		/// </summary>
#endif
		[SerializeField] private FlexibleFloat _Value = new FlexibleFloat();

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
			_Result.SetValue(-_Value.value);
        }
	}
}
