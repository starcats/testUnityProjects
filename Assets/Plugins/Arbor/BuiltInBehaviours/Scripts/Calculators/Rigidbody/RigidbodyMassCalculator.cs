using UnityEngine;
using System.Collections;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Rigidbody の質量
	/// </summary>
#else
	/// <summary>
	/// The mass of the rigidbody.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Rigidbody/Rigidbody.Mass")]
	[BehaviourTitle("Rigidbody.Mass")]
	[BuiltInBehaviour]
	public sealed class RigidbodyMassCalculator : Calculator
	{
		#region Serialize fields

		/// <summary>
		/// Rigidbody
		/// </summary>
		[SerializeField] private FlexibleRigidbody _Rigidbody = new FlexibleRigidbody();

#if ARBOR_DOC_JA
		/// <summary>
		/// 質量
		/// </summary>
#else
		/// <summary>
		/// The mass
		/// </summary>
#endif
		[SerializeField] private OutputSlotFloat _Mass = new OutputSlotFloat();

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
				_Mass.SetValue(rigidbody.mass);
            }
		}
	}
}
