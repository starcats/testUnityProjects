﻿using UnityEngine;
using UnityEditor;
using System.Collections;

using Arbor.StateMachine.StateBehaviours;

namespace ArborEditor.StateMachine.StateBehaviours
{
	[CustomEditor(typeof(AgentEscape))]
	public class AgentEscapeInspector : AgentMoveBaseInspector
	{
		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			DrawBase();

			EditorGUILayout.Space();

			EditorGUILayout.PropertyField(serializedObject.FindProperty("_Distance"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("_Target"));
			
			serializedObject.ApplyModifiedProperties();
		}
	}
}