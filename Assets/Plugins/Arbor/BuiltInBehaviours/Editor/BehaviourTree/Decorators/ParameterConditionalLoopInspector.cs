using UnityEngine;
using UnityEditor;
using System.Collections;

namespace ArborEditor.BehaviourTree.Decorators
{
	using Arbor;
	using Arbor.BehaviourTree;
	using Arbor.BehaviourTree.Decorators;

	[CustomEditor(typeof(ParameterConditionalLoop))]
	public class ParameterConditionalLoopInspector : Editor
	{
		SerializedProperty _ConditionsProperty;
		
		private void OnEnable()
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