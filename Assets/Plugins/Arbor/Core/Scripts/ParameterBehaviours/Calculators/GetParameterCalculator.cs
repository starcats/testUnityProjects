using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.ParameterBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Parameterから値を取得する。
	/// </summary>
#else
	/// <summary>
	/// Get a value from Parameter.
	/// </summary>
#endif
	[BehaviourTitle("GetParameter")]
	[BuiltInBehaviour]
	[AddComponentMenu("")]
	[AddBehaviourMenu("Parameter/GetParameter")]
	public class GetParameterCalculator : GetParameterCalculatorInternal
	{
	}
}