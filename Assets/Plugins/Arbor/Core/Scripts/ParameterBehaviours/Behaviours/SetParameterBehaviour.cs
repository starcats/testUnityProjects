using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.ParameterBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Parameterに値を設定する。
	/// </summary>
#else
	/// <summary>
	/// Set a value for Parameter.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[BehaviourTitle("SetParameter")]
	[AddBehaviourMenu("Parameter/SetParameter")]
	[BuiltInBehaviour]
	public class SetParameterBehaviour : SetParameterBehaviourInternal
	{
	}
}