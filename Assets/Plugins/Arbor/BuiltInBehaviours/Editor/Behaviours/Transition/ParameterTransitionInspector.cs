using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

using Arbor;
using Arbor.StateMachine.StateBehaviours;

namespace ArborEditor.StateMachine.StateBehaviours
{
	[CustomEditor(typeof(ParameterTransition))]
	public class ParameterTransitionInspector : Editor
	{
		SerializedProperty _ConditionsProperty;
		
		private void OnEnable()
		{
			_ConditionsProperty = serializedObject.FindProperty("_ConditionList");
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			EditorGUILayout.PropertyField(_ConditionsProperty, true);

			serializedObject.ApplyModifiedProperties();
		}
	}
}
