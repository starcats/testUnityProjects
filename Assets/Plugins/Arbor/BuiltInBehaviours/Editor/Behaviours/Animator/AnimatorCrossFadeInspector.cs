using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;
using System.Collections;
using System.Collections.Generic;

using Arbor;
using Arbor.StateMachine.StateBehaviours;

namespace ArborEditor.StateMachine.StateBehaviours
{
	[CustomEditor(typeof(AnimatorCrossFade))]
	public class AnimatorCrossFadeInspector : Editor
	{
		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			SerializedProperty animatorProperty = serializedObject.FindProperty("_Animator");
			SerializedProperty layerNameProperty = serializedObject.FindProperty("_LayerName");
			SerializedProperty stateNameProperty = serializedObject.FindProperty("_StateName");

			EditorGUILayout.PropertyField(animatorProperty);

			if (animatorProperty.FindPropertyRelative("_Type").enumValueIndex == EnumUtility.GetIndexFromValue(FlexibleType.Constant))
			{
				Animator animator = animatorProperty.FindPropertyRelative("_Value").objectReferenceValue as Animator;

				EditorGUITools.AnimatorStateField(animator, layerNameProperty, stateNameProperty);
			}
			else
			{
				EditorGUILayout.PropertyField(layerNameProperty);
				EditorGUILayout.PropertyField(stateNameProperty);
			}

			EditorGUILayout.PropertyField(serializedObject.FindProperty("_TransitionDuration"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("_NormalizedTime"));

			serializedObject.ApplyModifiedProperties();
		}
	}
}
