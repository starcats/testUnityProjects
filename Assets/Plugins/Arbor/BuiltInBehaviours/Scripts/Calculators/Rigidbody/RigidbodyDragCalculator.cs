﻿using UnityEngine;
using System.Collections;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// オブジェクトの抵抗
	/// </summary>
#else
	/// <summary>
	/// The drag of the object.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Rigidbody/Rigidbody.Drag")]
	[BehaviourTitle("Rigidbody.Drag")]
	[BuiltInBehaviour]
	public sealed class RigidbodyDragCalculator : Calculator
	{
		#region Serialize fields

		/// <summary>
		/// Rigidbody
		/// </summary>
		[SerializeField] private FlexibleRigidbody _Rigidbody = new FlexibleRigidbody();

#if ARBOR_DOC_JA
		/// <summary>
		/// オブジェクトの抵抗
		/// </summary>
#else
		/// <summary>
		/// The drag of the object.
		/// </summary>
#endif
		[SerializeField] private OutputSlotFloat _Drag = new OutputSlotFloat();

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
				_Drag.SetValue(rigidbody.drag);
            }
		}
	}
}
