﻿using UnityEngine;
using System.Collections;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// FromとToのベクトルの間を補間パラメータTで線形補間する。
	/// </summary>
#else
	/// <summary>
	/// Linear interpolation is performed between the vectors of From and To with the interpolation parameter T.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Vector2/Vector2.Lerp")]
	[BehaviourTitle("Vector2.Lerp")]
	[BuiltInBehaviour]
	public sealed class Vector2LerpCalculator : Calculator
	{
        #region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 開始ベクトル
		/// </summary>
#else
        /// <summary>
        /// Starting vector
        /// </summary>
#endif
        [SerializeField] private FlexibleVector2 _From = new FlexibleVector2();

#if ARBOR_DOC_JA
		/// <summary>
		/// 終了ベクトル
		/// </summary>
#else
		/// <summary>
		/// End vector
		/// </summary>
#endif
		[SerializeField] private FlexibleVector2 _To = new FlexibleVector2();

#if ARBOR_DOC_JA
		/// <summary>
		/// 補間パラメータ
		/// </summary>
#else
		/// <summary>
		/// The interpolation parameter
		/// </summary>
#endif
		[SerializeField] private FlexibleFloat _T = new FlexibleFloat();

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
			_Result.SetValue(Vector2.Lerp(_From.value, _To.value,_T.value));
		}
	}
}
