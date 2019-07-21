using UnityEngine;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// 2値間のランダムなVector3値を出力する。
	/// </summary>
#else
	/// <summary>
	/// Outputs a random Vector3 value between two values.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Random/Random.RangeVector3")]
	[BehaviourTitle("Random.RangeVector3")]
	[BuiltInBehaviour]
	public class RandomRangeVector3 : Calculator
	{
#if ARBOR_DOC_JA
		/// <summary>
		/// 1つ目のVector3
		/// </summary>
#else
		/// <summary>
		/// 1st Vector3
		/// </summary>
#endif
		[SerializeField]
		private FlexibleVector3 _VectorA = new FlexibleVector3(Vector3.zero);

#if ARBOR_DOC_JA
		/// <summary>
		/// 2つ目のVector3
		/// </summary>
#else
		/// <summary>
		/// 2nd Vector3
		/// </summary>
#endif
		[SerializeField]
		private FlexibleVector3 _VectorB = new FlexibleVector3(Vector3.zero);

#if ARBOR_DOC_JA
		/// <summary>
		/// 補間タイプ
		/// </summary>
#else
		/// <summary>
		/// Interpolate type
		/// </summary>
#endif
		[SerializeField]
		private InterpolateType _InterpolateType = InterpolateType.Lerp;

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
			switch (_InterpolateType)
			{
				case InterpolateType.Lerp:
					_Output.SetValue(Vector3.Lerp(_VectorA.value, _VectorB.value, Random.value));
					break;
				case InterpolateType.Slerp:
					_Output.SetValue(Vector3.Slerp(_VectorA.value, _VectorB.value, Random.value));
					break;
			}
		}
	}
}