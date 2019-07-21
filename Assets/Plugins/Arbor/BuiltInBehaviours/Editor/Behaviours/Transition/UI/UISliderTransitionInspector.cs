﻿using UnityEngine;
using UnityEditor;
using System.Collections;

using Arbor.StateMachine.StateBehaviours;

namespace ArborEditor.StateMachine.StateBehaviours
{
	[CustomEditor(typeof(UISliderTransition))]
	public class UISliderTransitionInspector : Editor
	{
		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			EditorGUILayout.PropertyField(serializedObject.FindProperty("_Slider"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("_ChangeTimingTransition"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("_Threshold"));

			serializedObject.ApplyModifiedProperties();
		}
	}
}