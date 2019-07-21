using UnityEngine;
using UnityEditor;
using System.Collections;

using Arbor.StateMachine.StateBehaviours;

namespace ArborEditor.StateMachine.StateBehaviours
{
	[CustomEditor(typeof(OnCollisionEnter2DTransition))]
	public class OnCollisionEnter2DTransitionInspector : Editor
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

			EditorGUILayout.PropertyField(serializedObject.FindProperty("_Collision2D"));

			serializedObject.ApplyModifiedProperties();
		}
	}
}
