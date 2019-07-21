using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Collections;

using Arbor.StateMachine.StateBehaviours;

namespace ArborEditor.StateMachine.StateBehaviours
{
	using Arbor;

	[CustomEditor(typeof(TweenBlendShapeWeight))]
	public class TweenBlendShapeWeightInspector : TweenBaseInspector
	{
		private ReorderableList _BlendShapeList;
		private SerializedProperty _BlendShapesProperty;

		protected override void OnEnable()
		{
			base.OnEnable();

			_BlendShapesProperty = serializedObject.FindProperty("_BlendShapes");

			_BlendShapeList = new ReorderableList(serializedObject, _BlendShapesProperty)
			{
				drawHeaderCallback = DrawHeader,
				elementHeightCallback = GetElementHeight,
				drawElementCallback = DrawElement,
			};
		}

		void DrawHeader(Rect rect)
		{
			EditorGUI.LabelField(rect, _BlendShapeList.serializedProperty.displayName);
		}

		float GetElementHeight(int index)
		{
			float height = _BlendShapeList.elementHeight + EditorGUIUtility.standardVerticalSpacing;

			SerializedProperty blendShapeProperty = _BlendShapeList.serializedProperty.GetArrayElementAtIndex(index);

			SerializedProperty targetProperty = blendShapeProperty.FindPropertyRelative("_Target");
			height += EditorGUI.GetPropertyHeight(targetProperty) + EditorGUIUtility.standardVerticalSpacing;

			SerializedProperty nameProperty = blendShapeProperty.FindPropertyRelative("_Name");
			height += EditorGUI.GetPropertyHeight(nameProperty) + EditorGUIUtility.standardVerticalSpacing;

			SerializedProperty tweenMoveTypeProperty = blendShapeProperty.FindPropertyRelative("_TweenMoveType");
			height += EditorGUI.GetPropertyHeight(tweenMoveTypeProperty) + EditorGUIUtility.standardVerticalSpacing;

			SerializedProperty fromProperty = blendShapeProperty.FindPropertyRelative("_From");
			TweenMoveType tweenMoveType = EnumUtility.GetValueFromIndex<TweenMoveType>(tweenMoveTypeProperty.enumValueIndex);
			switch (tweenMoveType)
			{
				case TweenMoveType.Absolute:
				case TweenMoveType.Relative:
					{
						height += EditorGUI.GetPropertyHeight(fromProperty) + EditorGUIUtility.standardVerticalSpacing;
					}
					break;
				case TweenMoveType.ToAbsolute:
					break;
			}

			SerializedProperty toProperty = blendShapeProperty.FindPropertyRelative("_To");
			height += EditorGUI.GetPropertyHeight(toProperty);

			return height;
		}

		void DrawElement(Rect rect, int index, bool isActive, bool isFocused)
		{
			SerializedProperty blendShapeProperty = _BlendShapeList.serializedProperty.GetArrayElementAtIndex(index);

			GUIContent label = EditorGUI.BeginProperty(rect, EditorGUITools.GetTextContent(blendShapeProperty.displayName), blendShapeProperty);

			rect.height = _BlendShapeList.elementHeight;
			EditorGUI.PrefixLabel(rect, label);
			rect.y += rect.height + EditorGUIUtility.standardVerticalSpacing;

			SerializedProperty targetProperty = blendShapeProperty.FindPropertyRelative("_Target");
			rect.height = EditorGUI.GetPropertyHeight(targetProperty);
			EditorGUI.PropertyField(rect, targetProperty);
			rect.y += rect.height + EditorGUIUtility.standardVerticalSpacing;

			SerializedProperty nameProperty = blendShapeProperty.FindPropertyRelative("_Name");
			rect.height = EditorGUI.GetPropertyHeight(nameProperty);
			EditorGUI.PropertyField(rect, nameProperty);
			rect.y += rect.height + EditorGUIUtility.standardVerticalSpacing;

			SerializedProperty tweenMoveTypeProperty = blendShapeProperty.FindPropertyRelative("_TweenMoveType");
			rect.height = EditorGUI.GetPropertyHeight(tweenMoveTypeProperty);
			EditorGUI.PropertyField(rect, tweenMoveTypeProperty);
			rect.y += rect.height + EditorGUIUtility.standardVerticalSpacing;

			SerializedProperty fromProperty = blendShapeProperty.FindPropertyRelative("_From");
			TweenMoveType tweenMoveType = EnumUtility.GetValueFromIndex<TweenMoveType>(tweenMoveTypeProperty.enumValueIndex);
			switch (tweenMoveType)
			{
				case TweenMoveType.Absolute:
				case TweenMoveType.Relative:
					{
						rect.height = EditorGUI.GetPropertyHeight(fromProperty);
						EditorGUI.PropertyField(rect, fromProperty);
						rect.y += rect.height + EditorGUIUtility.standardVerticalSpacing;
					}
					break;
				case TweenMoveType.ToAbsolute:
					break;
			}

			SerializedProperty toProperty = blendShapeProperty.FindPropertyRelative("_To");
			rect.height = EditorGUI.GetPropertyHeight(toProperty);
			EditorGUI.PropertyField(rect, toProperty);
			rect.y += rect.height;

			EditorGUI.EndProperty();
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();
			
			DrawBase();
			
			EditorGUILayout.Space();
			
			_BlendShapeList.DoLayoutList();

			serializedObject.ApplyModifiedProperties();
		}
	}
}