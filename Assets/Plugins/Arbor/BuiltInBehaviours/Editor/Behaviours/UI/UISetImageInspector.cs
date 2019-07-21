using UnityEngine;
using UnityEditor;
using System.Collections;

using Arbor.StateMachine.StateBehaviours;

namespace ArborEditor.StateMachine.StateBehaviours
{
	[CustomEditor(typeof(UISetImage))]
	public class UISetImageInspector : Editor
	{
		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			EditorGUILayout.PropertyField(serializedObject.FindProperty("_Image"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("_Sprite"));

			serializedObject.ApplyModifiedProperties();
		}
	}
}