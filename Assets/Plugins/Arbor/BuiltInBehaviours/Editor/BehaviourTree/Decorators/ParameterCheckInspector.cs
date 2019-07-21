using UnityEngine;
using UnityEditor;
using System.Collections;

namespace ArborEditor.BehaviourTree.Decorators
{
	using Arbor;
	using Arbor.BehaviourTree;
	using Arbor.BehaviourTree.Decorators;

	[CustomEditor(typeof(ParameterCheck))]
	public class ParameterCheckInspector : Editor
	{
		SerializedProperty _AbortFlagsProperty;
		SerializedProperty _ConditionsProperty;
		
		private void OnEnable()
		{
			_AbortFlagsProperty = serializedObject.FindProperty("_AbortFlags");
			_ConditionsProperty = serializedObject.FindProperty("_ConditionList");
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			EditorGUILayout.PropertyField(_AbortFlagsProperty);
			EditorGUILayout.PropertyField(_ConditionsProperty);

			serializedObject.ApplyModifiedProperties();
		}
	}
}