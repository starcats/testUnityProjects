﻿using UnityEngine;
using System.Collections;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Vector2をVector3に変換する。
	/// </summary>
#else
    /// <summary>
    /// Vector 2 is converted to Vector 3.
    /// </summary>
#endif
    [AddComponentMenu("")]
	[AddBehaviourMenu("Vector2/Vector2.ToVector3")]
	[BehaviourTitle("Vector2.ToVector3")]
	[BuiltInBehaviour]
	public sealed class Vector2ToVector3Calculator : Calculator
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
		[SerializeField] private OutputSlotVector3 _Result = new OutputSlotVector3();

		#endregion // Serialize fields

		public override void OnCalculate()
		{
			_Result.SetValue((Vector3)_Vector2.value);
		}
	}
}
