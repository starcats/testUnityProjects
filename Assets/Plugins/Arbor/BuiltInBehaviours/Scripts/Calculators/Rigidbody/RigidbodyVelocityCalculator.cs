﻿using UnityEngine;
using System.Collections;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Rigidbody の速度ベクトル
	/// </summary>
#else
	/// <summary>
	/// The velocity vector of the rigidbody.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Rigidbody/Rigidbody.Velocity")]
	[BehaviourTitle("Rigidbody.Velocity")]
	[BuiltInBehaviour]
	public sealed class RigidbodyVelocityCalculator : Calculator
	{
		#region Serialize fields

		/// <summary>
		/// Rigidbody
		/// </summary>
		[SerializeField] private FlexibleRigidbody _Rigidbody = new FlexibleRigidbody();

#if ARBOR_DOC_JA
		/// <summary>
		/// 速度ベクトル
		/// </summary>
#else
		/// <summary>
		/// The velocity vector.
		/// </summary>
#endif
		[SerializeField] private OutputSlotVector3 _Velocity = new OutputSlotVector3();

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
				_Velocity.SetValue(rigidbody.velocity);
            }
		}
	}
}
