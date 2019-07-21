﻿using UnityEngine;
using System.Collections;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Rigidbody の角速度ベクトル
	/// </summary>
#else
	/// <summary>
	/// The angular velocity vector of the rigidbody measured in radians per second.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Rigidbody/Rigidbody.AngularVelocity")]
	[BehaviourTitle("Rigidbody.AngularVelocity")]
	[BuiltInBehaviour]
	public sealed class RigidbodyAngularVelocityCalculator : Calculator
	{
		#region Serialize fields

		/// <summary>
		/// Rigidbody
		/// </summary>
		[SerializeField] private FlexibleRigidbody _Rigidbody = new FlexibleRigidbody();

#if ARBOR_DOC_JA
		/// <summary>
		/// 角速度ベクトル
		/// </summary>
#else
		/// <summary>
		/// The angular velocity vector
		/// </summary>
#endif
		[SerializeField] private OutputSlotVector3 _AngularVelocity = new OutputSlotVector3();

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
				_AngularVelocity.SetValue(rigidbody.angularVelocity);
            }
		}
	}
}
