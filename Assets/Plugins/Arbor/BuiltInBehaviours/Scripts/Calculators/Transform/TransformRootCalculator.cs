﻿using UnityEngine;
using System.Collections;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// 階層の一番上の Transform
	/// </summary>
#else
	/// <summary>
	/// Gets the topmost transform in the hierarchy.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transform/Transform.Root")]
	[BehaviourTitle("Transform.Root")]
	[BuiltInBehaviour]
	public sealed class TransformRootCalculator : Calculator
	{
		#region Serialize fields

		/// <summary>
		/// Transform
		/// </summary>
		[SerializeField] private FlexibleTransform _Transform = new FlexibleTransform();

#if ARBOR_DOC_JA
		/// <summary>
		/// 階層の一番上の Transform
		/// </summary>
#else
		/// <summary>
		/// The topmost transform in the hierarchy.
		/// </summary>
#endif
		[SerializeField] private OutputSlotTransform _Root = new OutputSlotTransform();

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
				_Root.SetValue(transform.root);
            }
		}
	}
}
