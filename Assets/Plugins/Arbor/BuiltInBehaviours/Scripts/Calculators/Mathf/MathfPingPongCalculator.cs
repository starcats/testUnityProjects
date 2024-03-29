﻿using UnityEngine;
using System.Collections;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// 補間パラメータTにより0からLengthの間を往復させる。
	/// </summary>
#else
    /// <summary>
    /// The interpolation parameter T makes a round trip between 0 and Length.
    /// </summary>
#endif
    [AddComponentMenu("")]
	[AddBehaviourMenu("Mathf/Mathf.PingPong")]
	[BehaviourTitle("Mathf.PingPong")]
	[BuiltInBehaviour]
	public sealed class MathfPingPongCalculator : Calculator
	{
        #region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 補間パラメータ
		/// </summary>
#else
        /// <summary>
        /// Interpolation parameter
        /// </summary>
#endif
        [SerializeField] private FlexibleFloat _T = new FlexibleFloat();

#if ARBOR_DOC_JA
		/// <summary>
		/// 長さ
		/// </summary>
#else
		/// <summary>
		/// Length
		/// </summary>
#endif
		[SerializeField] private FlexibleFloat _Length = new FlexibleFloat();

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
			_Result.SetValue(Mathf.PingPong(_T.value, _Length.value));
		}
	}
}
