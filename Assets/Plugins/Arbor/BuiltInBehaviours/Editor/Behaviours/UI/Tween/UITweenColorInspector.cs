using UnityEngine;
using UnityEditor;
using System.Collections;

using Arbor.StateMachine.StateBehaviours;

namespace ArborEditor.StateMachine.StateBehaviours
{
	[CustomEditor(typeof(UITweenColor))]
	public class UITweenColorInspector : TweenBaseInspector
	{
		public override void OnInspectorGUI ()
		{
			serializedObject.Update ();

			DrawBase();

			EditorGUILayout.Space();

			EditorGUILayout.PropertyField( serializedObject.FindProperty( "_Target" ) );
			EditorGUILayout.PropertyField( serializedObject.FindProperty( "_Gradient" ) );

			serializedObject.ApplyModifiedProperties();
		}
	}
}