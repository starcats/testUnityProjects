using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;
using System.Collections;
using System.Collections.Generic;

using Arbor;
using Arbor.StateMachine.StateBehaviours;

namespace ArborEditor.StateMachine.StateBehaviours
{
	[CustomEditor(typeof(AnimatorSetLayerWeight))]
	public class AnimatorSetLayerWeightInspector : Editor
	{
		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			SerializedProperty animatorProperty = serializedObject.FindProperty("_Animator");
			SerializedProperty layerNameProperty = serializedObject.FindProperty("_LayerName");

			EditorGUILayout.PropertyField(animatorProperty);

			if (animatorProperty.FindPropertyRelative("_Type").enumValueIndex == EnumUtility.GetIndexFromValue(FlexibleType.Constant))
			{
				Animator animator = animatorProperty.FindPropertyRelative("_Value").objectReferenceValue as Animator;

				EditorGUITools.AnimatorLayerField(animator, layerNameProperty);
			}
			else
			{
				EditorGUILayout.PropertyField(layerNameProperty);
			}

			EditorGUILayout.PropertyField(serializedObject.FindProperty("_Weight"));

			serializedObject.ApplyModifiedProperties();
		}
	}
}
