﻿using UnityEngine;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// 単球内のランダムな点を出力する。
	/// </summary>
#else
	/// <summary>
	/// Output a random point inside the unit sphere.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Random/Random.InsideUnitSphere")]
	[BehaviourTitle("Random.InsideUnitSphere")]
	[BuiltInBehaviour]
	public class RandomInsideUnitSphere : Calculator
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
		private OutputSlotVector3 _Output = new OutputSlotVector3();

		public override bool OnCheckDirty()
		{
			return true;
		}

		// Use this for calculate
		public override void OnCalculate()
		{
			_Output.SetValue(Random.insideUnitSphere);
		}
	}
}