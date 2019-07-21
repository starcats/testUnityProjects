﻿using UnityEngine;
using System.Collections;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// ローカル座標における、Rigidbody オブジェクトの相対的速度を取得します
	/// </summary>
#else
	/// <summary>
	/// The velocity relative to the rigidbody at the point relativePoint.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Rigidbody/Rigidbody.GetRelativePointVelocity")]
	[BehaviourTitle("Rigidbody.GetRelativePointVelocity")]
	[BuiltInBehaviour]
	public sealed class RigidbodyGetRelativePointVelocityCalculator : Calculator
	{
		#region Serialize fields

		/// <summary>
		/// Rigidbody
		/// </summary>
		[SerializeField] private FlexibleRigidbody _Rigidbody = new FlexibleRigidbody();

#if ARBOR_DOC_JA
		/// <summary>
		/// ローカル座標
		/// </summary>
#else
		/// <summary>
		/// the point relativePoint.
		/// </summary>
#endif
		[SerializeField] private FlexibleVector3 _RelativePoint = new FlexibleVector3();

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

		public override bool OnCheckDirty()
		{
			return true;
		}

		// Use this for calculate
		public override void OnCalculate()
		{
			Rigidbody rigidbody = _Rigidbody.value;
			if (rigidbody != null)
			{
				_Result.SetValue( rigidbody.GetRelativePointVelocity(_RelativePoint.value) );
            }
		}
	}
}
