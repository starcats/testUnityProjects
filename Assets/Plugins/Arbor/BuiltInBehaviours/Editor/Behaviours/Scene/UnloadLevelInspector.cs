using UnityEngine;
using UnityEditor;
using System.Collections;

using Arbor.StateMachine.StateBehaviours;

namespace ArborEditor.StateMachine.StateBehaviours
{
	[CustomEditor(typeof(UnloadLevel))]
	public class UnloadLevelInspector : Editor
	{
		public override void OnInspectorGUI ()
		{
			serializedObject.Update();

			EditorGUILayout.PropertyField( serializedObject.FindProperty( "_LevelName" ) );

			serializedObject.ApplyModifiedProperties();
		}
	}
}
