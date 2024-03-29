﻿using UnityEngine;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// 単円内のランダムな点を出力する。
	/// </summary>
#else
	/// <summary>
	/// Output a random point inside the unit circle.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Random/Random.InsideUnitCircle")]
	[BehaviourTitle("Random.InsideUnitCircle")]
	[BuiltInBehaviour]
	public class RandomInsideUnitCircle : Calculator
	{
#if ARBOR_DOC_JA
		/// <summary>
		/// 出力スロット
		/// </summary>
#else
		/// <summary>
		/// Output slot
		/// </summary>
#endif
		[SerializeField]
		private OutputSlotVector2 _Output = new OutputSlotVector2();

		public override bool OnCheckDirty()
		{
			return true;
		}

		// Use this for calculate
		public override void OnCalculate()
		{
			_Output.SetValue(Random.insideUnitCircle);
		}
	}
}