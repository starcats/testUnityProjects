using UnityEngine;
using UnityEditor;
using System.Collections;

using Arbor;
using Arbor.StateMachine.StateBehaviours;

namespace ArborEditor.StateMachine.StateBehaviours
{
	[CustomEditor(typeof(SendMessageGameObject))]
	public class SendMessageGameObjectInspector : Editor
	{
		public override void OnInspectorGUI()
		{
			serializedObject.Update ();

			EditorGUILayout.PropertyField(serializedObject.FindProperty( "_Target" ));
			EditorGUILayout.PropertyField(serializedObject.FindProperty( "_MethodName" ));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("_Argument"));

			serializedObject.ApplyModifiedProperties();
		}
	}
}
