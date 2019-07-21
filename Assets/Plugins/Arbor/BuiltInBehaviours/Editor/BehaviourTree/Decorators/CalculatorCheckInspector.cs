using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace ArborEditor.BehaviourTree.Decorators
{
	using Arbor;
	using Arbor.BehaviourTree;
	using Arbor.BehaviourTree.Decorators;

	[CustomEditor(typeof(CalculatorCheck))]
	public class CalculatorCheckInspector : Editor
	{
		SerializedProperty _ConditionsProperty;

		void OnEnable()
		{
			_ConditionsProperty = serializedObject.FindProperty("_ConditionList");
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			EditorGUILayout.PropertyField(serializedObject.FindProperty("_AbortFlags"));

			EditorGUILayout.PropertyField(_ConditionsProperty);

			serializedObject.ApplyModifiedProperties();
		}
	}
}