﻿using UnityEngine;
using System.Collections;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// ベクトルの長さ
	/// </summary>
#else
	/// <summary>
	/// The length of vector.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Vector3/Vector3.Magnitude")]
	[BehaviourTitle("Vector3.Magnitude")]
	[BuiltInBehaviour]
	public sealed class Vector3MagnitudeCalculator : Calculator
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// ベクトル
		/// </summary>
#else
		/// <summary>
		/// Vector
		/// </summary>
#endif
		[SerializeField] private FlexibleVector3 _Vector3 = new FlexibleVector3();

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
			_Result.SetValue(_Vector3.value.magnitude);
		}
	}
}
