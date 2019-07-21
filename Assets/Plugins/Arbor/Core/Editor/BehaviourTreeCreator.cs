using UnityEngine;
using UnityEditor;
using System.Collections;

namespace ArborEditor.BehaviourTree
{
	using Arbor;
	using Arbor.BehaviourTree;

	static class BehaviourTreeCreator
	{
		[MenuItem("GameObject/Arbor/BehaviourTree", false,11)]
		static void CreateBehaviourTree(MenuCommand menuCommand)
		{
			NodeGraphUtility.CreateGraphObject(typeof(BehaviourTree), "BehaviourTree", menuCommand.context as GameObject);
		}
	}
}