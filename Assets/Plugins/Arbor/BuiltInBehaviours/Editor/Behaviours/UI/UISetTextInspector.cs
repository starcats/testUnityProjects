using UnityEngine;
using UnityEditor;
using System.Collections;

using Arbor;
using Arbor.StateMachine.StateBehaviours;

namespace ArborEditor.StateMachine.StateBehaviours
{
	[CustomEditor(typeof(UISetText))]
	public class UISetTextInspector : Editor
	{
		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			EditorGUILayout.PropertyField(serializedObject.FindProperty("_Text"));

			SerializedProperty stringProperty = serializedObject.FindProperty("_String");
			EditorGUILayout.PropertyField(stringProperty);

			SerializedProperty typeProperty = stringProperty.FindPropertyRelative("_Type");
			FlexibleType type = EnumUtility.GetValueFromIndex<FlexibleType>(typeProperty.enumValueIndex);
			if (type == FlexibleType.Parameter)
			{
				EditorGUILayout.PropertyField(serializedObject.FindProperty("_ChangeTimingUpdate"));
			}

			serializedObject.ApplyModifiedProperties();
		}
	}
}