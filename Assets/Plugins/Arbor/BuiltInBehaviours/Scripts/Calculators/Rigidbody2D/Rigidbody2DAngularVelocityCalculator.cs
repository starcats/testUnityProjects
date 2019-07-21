﻿using UnityEngine;
using System.Collections;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Rigidbody2D の角速度
	/// </summary>
#else
	/// <summary>
	/// The angular velocity of the Rigidbody2D measured in radians per second.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Rigidbody2D/Rigidbody2D.AngularVelocity")]
	[BehaviourTitle("Rigidbody2D.AngularVelocity")]
	[BuiltInBehaviour]
	public sealed class Rigidbody2DAngularVelocityCalculator : Calculator
	{
		#region Serialize fields

		/// <summary>
		/// Rigidbody2D
		/// </summary>
		[SerializeField] private FlexibleRigidbody2D _Rigidbody2D = new FlexibleRigidbody2D();

#if ARBOR_DOC_JA
		/// <summary>
		/// 角速度
		/// </summary>
#else
		/// <summary>
		/// The angular velocity
		/// </summary>
#endif
		[SerializeField] private OutputSlotFloat _AngularVelocity = new OutputSlotFloat();

		#endregion // Serialize fields

		public override bool OnCheckDirty()
		{
			return true;
		}

		// Use this for calculate
		public override void OnCalculate()
		{
			Rigidbody2D rigidbody2D = _Rigidbody2D.value;
			if (rigidbody2D != null)
			{
				_AngularVelocity.SetValue(rigidbody2D.angularVelocity);
            }
		}
	}
}
