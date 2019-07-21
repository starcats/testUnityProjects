using UnityEngine;
using UnityEditor;
using System.Collections;

using Arbor.StateMachine.StateBehaviours;

namespace ArborEditor.StateMachine.StateBehaviours
{
	public class AgentRotateBaseInspector : AgentIntervalUpdateInspector
	{
		protected override void DrawBase()
		{
			EditorGUILayout.PropertyField(serializedObject.FindProperty("_AgentController"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("_AngularSpeed"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("_MinInterval"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("_MaxInterval"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("_StopOnStateEnd"));
		}
	}
}