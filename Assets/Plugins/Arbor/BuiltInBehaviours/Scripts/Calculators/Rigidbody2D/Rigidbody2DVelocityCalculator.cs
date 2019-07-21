﻿using UnityEngine;
using System.Collections;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Rigdibody の線形速度
	/// </summary>
#else
	/// <summary>
	/// Linear velocity of the rigidbody.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Rigidbody2D/Rigidbody2D.Velocity")]
	[BehaviourTitle("Rigidbody2D.Velocity")]
	[BuiltInBehaviour]
	public sealed class Rigidbody2DVelocityCalculator : Calculator
	{
		#region Serialize fields

		/// <summary>
		/// Rigidbody2D
		/// </summary>
		[SerializeField] private FlexibleRigidbody2D _Rigidbody2D = new FlexibleRigidbody2D();

#if ARBOR_DOC_JA
		/// <summary>
		/// Rigdibody の線形速度
		/// </summary>
#else
		/// <summary>
		/// Linear velocity of the rigidbody.
		/// </summary>
#endif
		[SerializeField] private OutputSlotVector2 _Velocity = new OutputSlotVector2();

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
				_Velocity.SetValue(rigidbody2D.velocity);
            }
		}
	}
}
