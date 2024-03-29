﻿using UnityEngine;
using System.Collections;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// GameObjectにアタッチされているTransformを取得する。
	/// </summary>
#else
	/// <summary>
	/// Gets the Transform attached to GameObject.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transform/Transform.Get")]
	[BehaviourTitle("Transform.Get")]
	[BuiltInBehaviour]
	public sealed class TransformGetCalculator : Calculator
	{
		#region Serialize fields

		/// <summary>
		/// GameObject
		/// </summary>
		[SerializeField] private FlexibleGameObject _GameObject = new FlexibleGameObject();

#if ARBOR_DOC_JA
		/// <summary>
		/// 取得したTransform
		/// </summary>
#else
		/// <summary>
		/// Get the Transform
		/// </summary>
#endif
		[SerializeField] private OutputSlotTransform _Transform = new OutputSlotTransform();

		#endregion // Serialize fields

		// Use this for calculate
		public override void OnCalculate()
		{
			GameObject gameObject = _GameObject.value;
			if (gameObject != null)
			{
				_Transform.SetValue(gameObject.GetComponent<Transform>());
            }
		}
	}
}
