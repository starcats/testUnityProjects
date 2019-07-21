﻿using UnityEngine;
using UnityEditor;
using System.Collections;

using Arbor;
using Arbor.StateMachine.StateBehaviours;

namespace ArborEditor.StateMachine.StateBehaviours
{
	[CustomEditor(typeof(TimeTransition))]
	public class TimeTransitionInspector : Editor
	{
		TimeTransition _Target;

		SerializedProperty _TimeTypeProperty;
		SerializedProperty _SecondsProperty;

		void OnEnable()
		{
			_Target = target as TimeTransition;

			_TimeTypeProperty = serializedObject.FindProperty( "_TimeType" );
			_SecondsProperty = serializedObject.FindProperty( "_Seconds" );
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update ();

			EditorGUILayout.PropertyField( _TimeTypeProperty );
			EditorGUILayout.PropertyField( _SecondsProperty );

			if (Application.isPlaying && _Target.stateMachine.currentState == _Target.state && _Target.duration > 0.0f )
			{
				Rect r = EditorGUILayout.BeginVertical();
				EditorGUI.ProgressBar(r, _Target.elapsedTime / _Target.duration, _Target.elapsedTime.ToString("0.00") );
				GUILayout.Space(16);
				EditorGUILayout.EndVertical();
			}

			serializedObject.ApplyModifiedProperties();
		}

		public override bool RequiresConstantRepaint()
		{
			return Application.isPlaying && _Target.stateMachine.currentState == _Target.state && _Target.duration > 0.0f;
		}
	}
}
