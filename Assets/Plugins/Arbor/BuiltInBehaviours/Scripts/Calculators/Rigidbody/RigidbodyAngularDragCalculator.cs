using UnityEngine;
using System.Collections;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// オブジェクトの回転に対する抵抗
	/// </summary>
#else
	/// <summary>
	/// The angular drag of the object.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Rigidbody/Rigidbody.AngularDrag")]
	[BehaviourTitle("Rigidbody.AngularDrag")]
	[BuiltInBehaviour]
	public sealed class RigidbodyAngularDragCalculator : Calculator
	{
		#region Serialize fields

		/// <summary>
		/// Rigidbody
		/// </summary>
		[SerializeField] private FlexibleRigidbody _Rigidbody = new FlexibleRigidbody();

#if ARBOR_DOC_JA
		/// <summary>
		/// オブジェクトの回転に対する抵抗
		/// </summary>
#else
		/// <summary>
		/// The angular drag of the object.
		/// </summary>
#endif
		[SerializeField] private OutputSlotFloat _AngularDrag = new OutputSlotFloat();

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
				_AngularDrag.SetValue(rigidbody.angularDrag);
            }
		}
	}
}
