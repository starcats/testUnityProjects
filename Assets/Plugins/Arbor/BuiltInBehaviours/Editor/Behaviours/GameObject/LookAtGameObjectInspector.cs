using UnityEngine;
using UnityEditor;
using System.Collections;

using Arbor.StateMachine.StateBehaviours;

namespace ArborEditor.StateMachine.StateBehaviours
{
	[CustomEditor(typeof(LookAtGameObject))]
	public class LookAtGameObjectInspector : Editor
	{
		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			EditorGUILayout.PropertyField(serializedObject.FindProperty("_Transform"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("_Target"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("_UsePositionX"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("_UsePositionY"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("_UsePositionZ"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("_ApplyLateUpdate"));

			serializedObject.ApplyModifiedProperties();
        }
	}
}