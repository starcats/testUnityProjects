﻿using UnityEngine;
using UnityEditor;
using System.Collections;

using Arbor;

namespace ArborEditor
{
	[CustomEditor(typeof(ParameterContainer))]
	public sealed class ParameterContainerInspector : ParameterContainerInternalInspector
	{
	}
}
