﻿using UnityEngine;
using System.Collections;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// AとBの間の距離を計算する。
	/// </summary>
#else
	/// <summary>
	/// Calculates the distance between A and B.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Vector2/Vector2.Distance")]
	[BehaviourTitle("Vector2.Distance")]
	[BuiltInBehaviour]
	public sealed class Vector2DistanceCalculator : Calculator
	{
        #region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// ベクトルA
		/// </summary>
#else
        /// <summary>
        /// Vector A
        /// </summary>
#endif
        [SerializeField] private FlexibleVector2 _A = new FlexibleVector2();

#if ARBOR_DOC_JA
		/// <summary>
		/// ベクトルB
		/// </summary>
#else
		/// <summary>
		/// Vector B
		/// </summary>
#endif
		[SerializeField] private FlexibleVector2 _B = new FlexibleVector2();

#if ARBOR_DOC_JA
		/// <summary>
		/// 結果出力
		/// </summary>
#else
		/// <summary>
		/// Output result
		/// </summary>
#endif
		[SerializeField] private OutputSlotFloat _Result = new OutputSlotFloat();

        #endregion // Serialize fields

        public override void OnCalculate()
		{
			_Result.SetValue(Vector2.Distance(_A.value, _B.value));
		}
	}
}
