using UnityEngine;
using System.Collections;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// ワールド空間の Transform の青軸
	/// </summary>
#else
	/// <summary>
	/// The blue axis of the transform in world space.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transform/Transform.Forward")]
	[BehaviourTitle("Transform.Forward")]
	[BuiltInBehaviour]
	public sealed class TransformForwardCalculator : Calculator
	{
		#region Serialize fields

		/// <summary>
		/// Transform
		/// </summary>
		[SerializeField] private FlexibleTransform _Transform = new FlexibleTransform();

#if ARBOR_DOC_JA
		/// <summary>
		/// ワールド空間の Transform の青軸
		/// </summary>
#else
		/// <summary>
		/// The blue axis of the transform in world space.
		/// </summary>
#endif
		[SerializeField] private OutputSlotVector3 _Forward = new OutputSlotVector3();

		#endregion // Serialize fields

		public override bool OnCheckDirty()
		{
			return true;
		}

		// Use this for calculate
		public override void OnCalculate()
		{
			Transform transform = _Transform.value;
			if (transform != null)
			{
				_Forward.SetValue(transform.forward);
            }
		}
	}
}
