using UnityEngine;
using System.Collections;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// オブジェクトが重力により影響を受ける度合い
	/// </summary>
#else
	/// <summary>
	/// The degree to which this object is affected by gravity.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Rigidbody2D/Rigidbody2D.GravityScale")]
	[BehaviourTitle("Rigidbody2D.GravityScale")]
	[BuiltInBehaviour]
	public sealed class Rigidbody2DGravityScaleCalculator : Calculator
	{
		#region Serialize fields

		/// <summary>
		/// Rigidbody2D
		/// </summary>
		[SerializeField] private FlexibleRigidbody2D _Rigidbody2D = new FlexibleRigidbody2D();

#if ARBOR_DOC_JA
		/// <summary>
		/// オブジェクトが重力により影響を受ける度合い
		/// </summary>
#else
		/// <summary>
		/// The degree to which this object is affected by gravity.
		/// </summary>
#endif
		[SerializeField] private OutputSlotFloat _GravityScale = new OutputSlotFloat();

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
				_GravityScale.SetValue(rigidbody2D.gravityScale);
            }
		}
	}
}
