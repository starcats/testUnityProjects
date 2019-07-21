using UnityEngine;
using UnityEditor;
using System.Collections;

using Arbor.StateMachine.StateBehaviours;

namespace ArborEditor.StateMachine.StateBehaviours
{
	[CustomEditor(typeof(GoToTransition))]
	public class GoToTransitionInspector : Editor
	{
		public override void OnInspectorGUI ()
		{
			serializedObject.Update();

			EditorGUILayout.PropertyField(serializedObject.FindProperty("_TransitionMethod"));

			serializedObject.ApplyModifiedProperties();
		}
	}
}