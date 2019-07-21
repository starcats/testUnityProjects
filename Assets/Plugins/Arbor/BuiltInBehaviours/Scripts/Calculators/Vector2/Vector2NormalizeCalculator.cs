﻿using UnityEngine;
using System.Collections;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Vector2を正規化したベクトル
	/// </summary>
#else
    /// <summary>
    /// Vector 2 normalized vector
    /// </summary>
#endif
    [AddComponentMenu("")]
	[AddBehaviourMenu("Vector2/Vector2.Normalize")]
	[BehaviourTitle("Vector2.Normalize")]
	[BuiltInBehaviour]
	public sealed class Vector2NormalizeCalculator : Calculator
	{
        #region Serialize fields

        /// <summary>
        /// Vector2
        /// </summary>
		[SerializeField] private FlexibleVector2 _Vector2 = new FlexibleVector2();

#if ARBOR_DOC_JA
		/// <summary>
		/// 結果出力
		/// </summary>
#else
		/// <summary>
		/// Output result
		/// </summary>
#endif
		[SerializeField] private OutputSlotVector2 _Result = new OutputSlotVector2();

		#endregion // Serialize fields

		public override void OnCalculate()
		{
			_Result.SetValue(_Vector2.value.normalized);
		}
	}
}
