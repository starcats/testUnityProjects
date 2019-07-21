using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.ParameterBehaviours
{
	using Arbor.BehaviourTree;

#if ARBOR_DOC_JA
	/// <summary>
	/// Parameterに値を設定する。
	/// </summary>
#else
	/// <summary>
	/// Set a value for Parameter.
	/// </summary>
#endif
	[BehaviourTitle("SetParameter")]
	[AddBehaviourMenu("Parameter/SetParameter")]
	[BuiltInBehaviour]
	[AddComponentMenu("")]
	public class SetParameterAction : SetParameterActionInternal
	{
	}
}
