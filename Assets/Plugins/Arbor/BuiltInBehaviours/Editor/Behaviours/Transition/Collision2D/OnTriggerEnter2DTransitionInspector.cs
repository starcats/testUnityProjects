using UnityEngine;
using UnityEditor;
using System.Collections;

using Arbor.StateMachine.StateBehaviours;

namespace ArborEditor.StateMachine.StateBehaviours
{
	[CustomEditor(typeof(OnTriggerEnter2DTransition))]
	public class OnTriggerEnter2DTransitionInspector : Editor
	{
		public override void OnInspectorGUI()
		{
			serializedObject.Update ();
			
			EditorGUILayout.PropertyField( serializedObject.FindProperty( "_IsCheckTag" ) );

			SerializedProperty tagProperty = serializedObject.FindProperty( "_Tag" );
			
			EditorGUI.BeginChangeCheck();
			string tag = EditorGUILayout.TagField( EditorGUITools.NicifyVariableName(tagProperty.name), tagProperty.stringValue );
			if( EditorGUI.EndChangeCheck() )
			{
				tagProperty.stringValue = tag;
			}

			EditorGUILayout.PropertyField(serializedObject.FindProperty("_Collider2D"));

			serializedObject.ApplyModifiedProperties();
		}
	}
}
