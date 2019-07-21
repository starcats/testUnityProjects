using UnityEngine;
using UnityEditor;
using System.Collections;

using Arbor;
using Arbor.StateMachine.StateBehaviours;

namespace ArborEditor.StateMachine.StateBehaviours
{
	[CustomEditor(typeof(UISetSlider))]
	public class UISetSliderInspector : Editor
	{
		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			EditorGUILayout.PropertyField(serializedObject.FindProperty("_Slider"));

			SerializedProperty valueProperty = serializedObject.FindProperty("_Value");
			EditorGUILayout.PropertyField(valueProperty);

			SerializedProperty typeProperty = valueProperty.FindPropertyRelative("_Type");
			FlexiblePrimitiveType type = EnumUtility.GetValueFromIndex<FlexiblePrimitiveType>(typeProperty.enumValueIndex);
			if (type == FlexiblePrimitiveType.Parameter)
			{
				EditorGUILayout.PropertyField(serializedObject.FindProperty("_ChangeTimingUpdate"));
			}

			serializedObject.ApplyModifiedProperties();
		}
	}
}