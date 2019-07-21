using UnityEngine;
using UnityEditor;
using System.Collections;

using Arbor.StateMachine.StateBehaviours;

namespace ArborEditor.StateMachine.StateBehaviours
{
	[CustomEditor(typeof(PlaySoundAtPoint))]
	public class PlaySoundAtPointInspector : Editor
	{
		public override void OnInspectorGUI()
		{
			serializedObject.Update ();

			EditorGUILayout.PropertyField( serializedObject.FindProperty( "_Clip") );
			EditorGUILayout.PropertyField( serializedObject.FindProperty( "_Position") );
			EditorGUILayout.PropertyField( serializedObject.FindProperty( "_Volume") );
			EditorGUILayout.PropertyField(serializedObject.FindProperty("_OutputAudioMixerGroup"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("_SpatialBlend"));

			serializedObject.ApplyModifiedProperties();
		}
	}
}
