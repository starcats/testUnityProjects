using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

namespace ArborEditor.StateMachine.StateBehaviours
{
	using Arbor;
	using Arbor.StateMachine.StateBehaviours;

	[CustomEditor(typeof(CalculatorTransition))]
	public class CalculatorTransitionInspector : Editor
	{
		SerializedProperty _ConditionsProperty;

		void OnEnable()
		{
			_ConditionsProperty = serializedObject.FindProperty("_ConditionList");
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			EditorGUILayout.PropertyField(_ConditionsProperty);

			serializedObject.ApplyModifiedProperties();
		}
	}
}
