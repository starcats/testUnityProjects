using UnityEngine;
using UnityEditor;
using System.Collections;

using Arbor.StateMachine.StateBehaviours;

namespace ArborEditor.StateMachine.StateBehaviours
{
	[CustomEditor(typeof(AgentFollow))]
	public class AgentFollowInspector : AgentMoveBaseInspector
	{
		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			DrawBase();

			EditorGUILayout.Space();

			EditorGUILayout.PropertyField(serializedObject.FindProperty("_StoppingDistance"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("_Target"));
			
			serializedObject.ApplyModifiedProperties();
		}
	}
}