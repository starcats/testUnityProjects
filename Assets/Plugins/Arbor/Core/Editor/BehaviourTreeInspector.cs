using UnityEngine;
using UnityEditor;
using System.Collections;

namespace ArborEditor.BehaviourTree
{
	using Arbor.BehaviourTree;

	[CustomEditor(typeof(BehaviourTree))]
	public sealed class BehaviourTreeInspector : BehaviourTreeInternalInspector
	{
	}
}