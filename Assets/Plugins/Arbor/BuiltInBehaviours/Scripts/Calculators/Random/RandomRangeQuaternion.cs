using UnityEngine;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// 2値間のランダムなQuaternion値を出力する。
	/// </summary>
#else
	/// <summary>
	/// Outputs a random Quaternion value between two values.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Random/Random.RangeQuaternion")]
	[BehaviourTitle("Random.RangeQuaternion")]
	[BuiltInBehaviour]
	public class RandomRangeQuaternion : Calculator
	{
#if ARBOR_DOC_JA
		/// <summary>
		/// 1つ目のQuaternion
		/// </summary>
#else
		/// <summary>
		/// 1st Quaternion
		/// </summary>
#endif
		[SerializeField]
		private FlexibleQuaternion _QuatenionA = new FlexibleQuaternion(Quaternion.identity);

#if ARBOR_DOC_JA
		/// <summary>
		/// 2つ目のQuaternion
		/// </summary>
#else
		/// <summary>
		/// 2nd Quaternion
		/// </summary>
#endif
		[SerializeField]
		private FlexibleQuaternion _QuaternionB = new FlexibleQuaternion(Quaternion.identity);

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
		private InterpolateType _InterpolateType = InterpolateType.Slerp;

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
			switch (_InterpolateType)
			{
				case InterpolateType.Lerp:
					_Output.SetValue(Quaternion.Lerp(_QuatenionA.value, _QuaternionB.value, Random.value));
					break;
				case InterpolateType.Slerp:
					_Output.SetValue(Quaternion.Slerp(_QuatenionA.value, _QuaternionB.value, Random.value));
					break;
			}
		}
	}
}