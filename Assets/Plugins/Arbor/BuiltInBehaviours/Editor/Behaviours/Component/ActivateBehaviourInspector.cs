using UnityEngine;
using UnityEditor;
using System.Collections;

using Arbor.StateMachine.StateBehaviours;

namespace ArborEditor.StateMachine.StateBehaviours
{
	[CustomEditor(typeof(ActivateBehaviour))]
	public class ActivateBehaviourInspector : Editor
	{
		public override void OnInspectorGUI()
		{
			serializedObject.Update ();

			EditorGUILayout.PropertyField( serializedObject.FindProperty( "_Target" ) );
			EditorGUILayout.PropertyField( serializedObject.FindProperty( "_BeginActive" ) );
			EditorGUILayout.PropertyField( serializedObject.FindProperty( "_EndActive" ) );

			serializedObject.ApplyModifiedProperties();
		}
	}
}