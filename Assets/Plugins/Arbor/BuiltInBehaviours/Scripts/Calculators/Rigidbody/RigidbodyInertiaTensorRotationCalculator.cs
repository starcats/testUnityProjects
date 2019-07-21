using UnityEngine;
using System.Collections;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// 慣性テンソルの回転角度
	/// </summary>
#else
	/// <summary>
	/// The rotation of the inertia tensor.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Rigidbody/Rigidbody.InertiaTensorRotation")]
	[BehaviourTitle("Rigidbody.InertiaTensorRotation")]
	[BuiltInBehaviour]
	public sealed class RigidbodyInertiaTensorRotationCalculator : Calculator
	{
		#region Serialize fields

		/// <summary>
		/// Rigidbody
		/// </summary>
		[SerializeField] private FlexibleRigidbody _Rigidbody = new FlexibleRigidbody();

#if ARBOR_DOC_JA
		/// <summary>
		/// 慣性テンソルの回転角度
		/// </summary>
#else
		/// <summary>
		/// The rotation of the inertia tensor.
		/// </summary>
#endif
		[SerializeField] private OutputSlotQuaternion _InertiaTensorRotation = new OutputSlotQuaternion();

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
				_InertiaTensorRotation.SetValue(rigidbody.inertiaTensorRotation);
            }
		}
	}
}
