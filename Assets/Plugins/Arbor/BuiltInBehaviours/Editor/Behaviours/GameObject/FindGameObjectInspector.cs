using UnityEngine;
using UnityEditor;
using System.Collections;

using Arbor.StateMachine.StateBehaviours;

namespace ArborEditor.StateMachine.StateBehaviours
{
	[CustomEditor(typeof(FindGameObject))]
	public class FindGameObjectInspector : Editor
	{
		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			EditorGUILayout.PropertyField(serializedObject.FindProperty("_Reference"));
			EditorGUILayout.PropertyField( serializedObject.FindProperty( "_Output" ) );
			EditorGUILayout.PropertyField(serializedObject.FindProperty("_Name"));

			serializedObject.ApplyModifiedProperties();
		}
	}
}
