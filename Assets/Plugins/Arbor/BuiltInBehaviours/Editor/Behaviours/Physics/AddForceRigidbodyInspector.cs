using UnityEngine;
using UnityEditor;
using System.Collections;

using Arbor.StateMachine.StateBehaviours;

namespace ArborEditor.StateMachine.StateBehaviours
{
	[CustomEditor(typeof(AddForceRigidbody))]
	public class AddForceRigidbodyInspector : Editor
	{
		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			EditorGUILayout.PropertyField(serializedObject.FindProperty("_Target"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("_Angle"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("_Power"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("_ForceMode"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("_Space"));

			serializedObject.ApplyModifiedProperties();
		}
	}
}
