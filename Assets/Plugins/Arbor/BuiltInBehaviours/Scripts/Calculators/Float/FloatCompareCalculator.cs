using UnityEngine;
using System.Collections;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// floatを比較する。
	/// </summary>
#else
	/// <summary>
	/// Compare floats.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Float/Float.Compare")]
	[BehaviourTitle("Float.Compare")]
	[BuiltInBehaviour]
	public sealed class FloatCompareCalculator : Calculator
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 比較タイプ。
		/// </summary>
#else
		/// <summary>
		/// Comparison type.
		/// </summary>
#endif
		[SerializeField] private CompareType _CompareType = CompareType.Equals;

#if ARBOR_DOC_JA
		/// <summary>
		/// 値1
		/// </summary>
#else
		/// <summary>
		/// Value 1
		/// </summary>
#endif
		[SerializeField] private FlexibleFloat _Value1 = new FlexibleFloat();

#if ARBOR_DOC_JA
		/// <summary>
		/// 値2
		/// </summary>
#else
		/// <summary>
		/// Value 2
		/// </summary>
#endif
		[SerializeField] private FlexibleFloat _Value2 = new FlexibleFloat();

#if ARBOR_DOC_JA
		/// <summary>
		/// 結果出力
		/// </summary>
#else
		/// <summary>
		/// Result output
		/// </summary>
#endif
		[SerializeField] private OutputSlotBool _Result = new OutputSlotBool();

		#endregion // Serialize fields

		// Use this for calculate
		public override void OnCalculate()
		{
			bool result = false;
			switch (_CompareType)
			{
				case CompareType.Equals:
					result = _Value1.value == _Value2.value;
					break;
				case CompareType.NotEquals:
					result = _Value1.value != _Value2.value;
					break;
				case CompareType.Greater:
					result = _Value1.value > _Value2.value;
					break;
				case CompareType.GreaterOrEquals:
					result = _Value1.value >= _Value2.value;
					break;
				case CompareType.Less:
					result = _Value1.value < _Value2.value;
					break;
				case CompareType.LessOrEquals:
					result = _Value1.value <= _Value2.value;
					break;
			}
			_Result.SetValue(result);
		}
	}
}
