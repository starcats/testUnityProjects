using UnityEngine;
using UnityEditor;
using System.Collections;

using Arbor;

namespace ArborEditor
{
	[CustomEditor(typeof(GlobalParameterContainer))]
	public sealed class GlobalParameterContainerInspector : GlobalParameterContainerInternalInspector
	{
	}
}
