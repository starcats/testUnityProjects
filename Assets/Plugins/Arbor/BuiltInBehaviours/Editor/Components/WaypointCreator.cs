using UnityEngine;
using UnityEditor;
using System.Collections;

using Arbor;

namespace ArborEditor
{
	static class WaypointCreator
	{
		[MenuItem("GameObject/Arbor/Waypoint", false, 21)]
		static void CreateWaypoint(MenuCommand menuCommand)
		{
			GameObject gameObject = new GameObject("Waypoint", typeof(Waypoint));
			GameObjectUtility.SetParentAndAlign(gameObject, menuCommand.context as GameObject);
			Undo.RegisterCreatedObjectUndo(gameObject, "Create Waypoint");
			Selection.activeGameObject = gameObject;
		}
	}
}
