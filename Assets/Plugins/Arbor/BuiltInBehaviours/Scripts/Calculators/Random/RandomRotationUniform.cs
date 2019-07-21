using UnityEngine;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// 一様分布のランダムな回転を出力する。
	/// </summary>
#else
	/// <summary>
	/// Outputs a random rotation with uniform distribution.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Random/Random.RotationUniform")]
	[BehaviourTitle("Random.RotationUniform")]
	[BuiltInBehaviour]
	public class RandomRotationUniform : Calculator
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
		private OutputSlotQuaternion _Output = new OutputSlotQuaternion();

		public override bool OnCheckDirty()
		{
			return true;
		}

		// Use this for calculate
		public override void OnCalculate()
		{
			_Output.SetValue(Random.rotationUniform);
		}
	}
}