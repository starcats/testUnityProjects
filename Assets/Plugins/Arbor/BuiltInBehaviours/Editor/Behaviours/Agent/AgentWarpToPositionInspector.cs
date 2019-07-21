using UnityEngine;
using UnityEditor;
using System.Collections;

using Arbor.StateMachine.StateBehaviours;

namespace ArborEditor.StateMachine.StateBehaviours
{
	[CustomEditor(typeof(AgentWarpToPosition))]
	public class AgentWarpToPositionInspector : Editor
	{
		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			EditorGUILayout.PropertyField(serializedObject.FindProperty("_AgentController"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("_Target"));

			serializedObject.ApplyModifiedProperties();
		}
	}
}