using UnityEngine;
using System.Collections;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Rigidbody の位置
	/// </summary>
#else
	/// <summary>
	/// The position of the rigidbody.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Rigidbody/Rigidbody.Position")]
	[BehaviourTitle("Rigidbody.Position")]
	[BuiltInBehaviour]
	public sealed class RigidbodyPositionCalculator : Calculator
	{
		#region Serialize fields

		/// <summary>
		/// Rigidbody
		/// </summary>
		[SerializeField] private FlexibleRigidbody _Rigidbody = new FlexibleRigidbody();

#if ARBOR_DOC_JA
		/// <summary>
		/// 位置
		/// </summary>
#else
		/// <summary>
		/// The position.
		/// </summary>
#endif
		[SerializeField] private OutputSlotVector3 _Position = new OutputSlotVector3();

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
				_Position.SetValue(rigidbody.position);
            }
		}
	}
}
