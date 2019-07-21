﻿using UnityEngine;
using System.Collections;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// GameObjectにアタッチされているRigidbodyを取得する。
	/// </summary>
#else
	/// <summary>
	/// Gets the Rigidbody attached to GameObject.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Rigidbody/Rigidbody.Get")]
	[BehaviourTitle("Rigidbody.Get")]
	[BuiltInBehaviour]
	public sealed class RigidbodyGetCalculator : Calculator
	{
		#region Serialize fields

		/// <summary>
		/// GameObject
		/// </summary>
		[SerializeField] private FlexibleGameObject _GameObject = new FlexibleGameObject();

#if ARBOR_DOC_JA
		/// <summary>
		/// 取得したRigidbody
		/// </summary>
#else
		/// <summary>
		/// Get the Rigidbody
		/// </summary>
#endif
		[SerializeField] private OutputSlotRigidbody _Rigidbody = new OutputSlotRigidbody();

		#endregion // Serialize fields

		// Use this for calculate
		public override void OnCalculate()
		{
			GameObject gameObject = _GameObject.value;
			if (gameObject != null)
			{
				_Rigidbody.SetValue(gameObject.GetComponent<Rigidbody>());
            }
		}
	}
}
