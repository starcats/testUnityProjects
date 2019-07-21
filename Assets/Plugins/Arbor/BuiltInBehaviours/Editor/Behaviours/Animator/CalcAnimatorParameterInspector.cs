using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;
using System.Collections;

using Arbor;
using Arbor.StateMachine.StateBehaviours;

namespace ArborEditor.StateMachine.StateBehaviours
{
	[CustomEditor(typeof(CalcAnimatorParameter))]
	public class CalcAnimatorParameterInspector : Editor
	{
		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			SerializedProperty referenceProperty = serializedObject.FindProperty("_Reference");

			EditorGUILayout.PropertyField(referenceProperty);

			Animator animator = referenceProperty.FindPropertyRelative("animator").objectReferenceValue as Animator;

			if (animator != null && animator.runtimeAnimatorController != null)
			{
				AnimatorController animatorController = animator.runtimeAnimatorController as AnimatorController;

				SerializedProperty nameProperty = referenceProperty.FindPropertyRelative("name");

				AnimatorControllerParameter selectParameter = null;

				foreach (AnimatorControllerParameter parameter in animatorController.parameters)
				{
					if (parameter.name == nameProperty.stringValue)
					{
						selectParameter = parameter;
						break;
					}
				}

				if (selectParameter != null)
				{
					SerializedProperty functionProperty = serializedObject.FindProperty("_Function");

					switch (selectParameter.type)
					{
						case AnimatorControllerParameterType.Float:
							{
								EditorGUILayout.PropertyField(functionProperty);
								EditorGUILayout.PropertyField(serializedObject.FindProperty("_FloatValue"),EditorGUITools.GetTextContent("Float Value"));
							}
							break;
						case AnimatorControllerParameterType.Int:
							{
								EditorGUILayout.PropertyField(functionProperty);
								EditorGUILayout.PropertyField(serializedObject.FindProperty("_IntValue"), EditorGUITools.GetTextContent( "Int Value" ) );
							}
							break;
						case AnimatorControllerParameterType.Bool:
							{
								EditorGUILayout.PropertyField(serializedObject.FindProperty("_BoolValue"), EditorGUITools.GetTextContent( "Bool Value" ) );
							}
							break;
						case AnimatorControllerParameterType.Trigger:
							break;
					}
				}
			}

			serializedObject.ApplyModifiedProperties();
		}
	}
}
