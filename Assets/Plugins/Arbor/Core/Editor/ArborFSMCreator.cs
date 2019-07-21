using UnityEngine;
using UnityEditor;
using System.Collections;

using Arbor;

namespace ArborEditor
{
	static class ArborFSMCreator
	{
		[MenuItem("GameObject/Arbor/ArborFSM", false,10)]
		static void CreateArborFSM(MenuCommand menuCommand)
		{
			NodeGraphUtility.CreateGraphObject(typeof(ArborFSM), "ArborFSM", menuCommand.context as GameObject);
		}
	}
}