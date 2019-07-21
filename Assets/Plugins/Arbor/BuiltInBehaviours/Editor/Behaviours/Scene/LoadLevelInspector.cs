using UnityEngine;
using UnityEditor;
using System.Collections;

using Arbor.StateMachine.StateBehaviours;

namespace ArborEditor.StateMachine.StateBehaviours
{
	[CustomEditor(typeof(LoadLevel))]
	public class LoadLevelInspector : Editor
	{
		public override void OnInspectorGUI ()
		{
			serializedObject.Update();

			EditorGUILayout.PropertyField( serializedObject.FindProperty( "_LevelName" ) );
			EditorGUILayout.PropertyField(serializedObject.FindProperty("_LoadSceneMode"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("_IsActiveScene"));

			serializedObject.ApplyModifiedProperties();
		}
	}
}
