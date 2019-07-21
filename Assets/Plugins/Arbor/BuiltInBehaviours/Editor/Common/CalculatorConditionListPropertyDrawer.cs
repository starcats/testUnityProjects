﻿using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Collections;

namespace ArborEditor
{
	using Arbor;

	class CalculatorConditionListEditor : PropertyEditor
	{
		ReorderableList _ConditionsList;

		SerializedProperty _IntParameters;
		SerializedProperty _FloatParameters;
		SerializedProperty _BoolParameters;

		private LayoutArea _LayoutArea = new LayoutArea();
		private PropertyHeightCache _PropertyHeights = new PropertyHeightCache();
		
		private const string kParameterIndexPath = "_ParameterIndex";
		private const string kTypePath = "_Type";

		protected override void OnInitialize()
		{
			_ConditionsList = new ReorderableList(property.serializedObject, property.FindPropertyRelative("_Conditions"));
			_ConditionsList.drawHeaderCallback = DrawHeader;
			_ConditionsList.onAddDropdownCallback = OnAddDropdown;
			_ConditionsList.onRemoveCallback = OnRemove;
			_ConditionsList.drawElementCallback = DrawElement;
			_ConditionsList.elementHeightCallback = GetElementHeight;

			_IntParameters = property.FindPropertyRelative("_IntParameters");
			_FloatParameters = property.FindPropertyRelative("_FloatParameters");
			_BoolParameters = property.FindPropertyRelative("_BoolParameters");
		}

		void DrawHeader(Rect rect)
		{
			EditorGUI.LabelField(rect, property.displayName);
		}

		static CalculatorCondition.Type GetType(SerializedProperty elementProperty)
		{
			SerializedProperty typeProperty = elementProperty.FindPropertyRelative(kTypePath);

			return EnumUtility.GetValueFromIndex<CalculatorCondition.Type>(typeProperty.enumValueIndex);
		}

		void AddParameter(SerializedProperty elementProperty, CalculatorCondition.Type type)
		{
			SerializedProperty typeProperty = elementProperty.FindPropertyRelative(kTypePath);
			typeProperty.enumValueIndex = EnumUtility.GetIndexFromValue(type);

			SerializedProperty parametersProperty = GetParametersProperty(type);

			if (parametersProperty != null)
			{
				parametersProperty.arraySize++;
				int parameterIndex = parametersProperty.arraySize - 1;

				SerializedProperty parameterProperty = parametersProperty.GetArrayElementAtIndex(parameterIndex);

				SerializedProperty value1Property = parameterProperty.FindPropertyRelative("value1");
				SerializedProperty value2Property = parameterProperty.FindPropertyRelative("value2");

				FlexibleFieldProperty field1Property = null;
				FlexibleFieldProperty field2Property = null;
				switch (type)
				{
					case CalculatorCondition.Type.Int:
					case CalculatorCondition.Type.Float:
						field1Property = new FlexibleNumericProperty(value1Property);
						field2Property = new FlexibleNumericProperty(value2Property);
						break;
					case CalculatorCondition.Type.Bool:
						field1Property = new FlexibleBoolProperty(value1Property);
						field2Property = new FlexibleBoolProperty(value2Property);
						break;
				}

				if (field1Property != null)
				{
					field1Property.Clear(true);
				}
				if (field2Property != null)
				{
					bool clearBool = SerializedPropertyExtentions.clearBool;
					if (type == CalculatorCondition.Type.Bool)
					{
						SerializedPropertyExtentions.clearBool = true;
					}

					field2Property.Clear(true);

					SerializedPropertyExtentions.clearBool = clearBool;
				}

				SerializedProperty parameterIndexProperty = elementProperty.FindPropertyRelative(kParameterIndexPath);
				parameterIndexProperty.intValue = parameterIndex;
			}
		}

		void AddConditionMenu(object value)
		{
			SerializedObject serializedObject = _ConditionsList.serializedProperty.serializedObject;
			serializedObject.Update();

			CalculatorCondition.Type type = (CalculatorCondition.Type)value;

			ReorderableList.defaultBehaviours.DoAddButton(_ConditionsList);

			SerializedProperty elementProperty = _ConditionsList.serializedProperty.GetArrayElementAtIndex(_ConditionsList.index);
			AddParameter(elementProperty, type);

			serializedObject.ApplyModifiedProperties();
		}

		private void OnAddDropdown(Rect buttonRect, ReorderableList list)
		{
			GenericMenu genericMenu = new GenericMenu();
			foreach (object userData in System.Enum.GetValues(typeof(CalculatorCondition.Type)))
			{
				genericMenu.AddItem(EditorGUITools.GetTextContent(userData.ToString()), false, AddConditionMenu, userData);
			}

			genericMenu.DropDown(buttonRect);
		}

		private void OnRemove(ReorderableList list)
		{
			SerializedProperty elementProperty = list.serializedProperty.GetArrayElementAtIndex(list.index);
			
			CalculatorCondition.Type type = GetType(elementProperty);

			DeleteParameter(elementProperty, type, true);

			ReorderableList.defaultBehaviours.DoRemoveButton(list);
		}

		void DoGUI(SerializedProperty elementProperty)
		{
			CalculatorCondition.Type type = GetType(elementProperty);

			SerializedProperty parametersProperty = GetParametersProperty(type);

			SerializedProperty parameterIndexProperty = elementProperty.FindPropertyRelative(kParameterIndexPath);

			SerializedProperty parameterProperty = parametersProperty.GetArrayElementAtIndex(parameterIndexProperty.intValue);
			
			SerializedProperty value1Property = parameterProperty.FindPropertyRelative("value1");
			SerializedProperty value2Property = parameterProperty.FindPropertyRelative("value2");

			switch (type)
			{
				case CalculatorCondition.Type.Int:
					{
						_LayoutArea.PropertyField(elementProperty.FindPropertyRelative("_CompareType"));
						_LayoutArea.PropertyField(value1Property, EditorGUITools.GetTextContent("Int Value 1"));
						_LayoutArea.PropertyField(value2Property, EditorGUITools.GetTextContent("Int Value 2"));
					}
					break;
				case CalculatorCondition.Type.Float:
					{
						_LayoutArea.PropertyField(elementProperty.FindPropertyRelative("_CompareType"));
						_LayoutArea.PropertyField(value1Property, EditorGUITools.GetTextContent("Float Value 1"));
						_LayoutArea.PropertyField(value2Property, EditorGUITools.GetTextContent("Float Value 2"));
					}
					break;
				case CalculatorCondition.Type.Bool:
					{
						_LayoutArea.PropertyField(value1Property, EditorGUITools.GetTextContent("Bool Value 1"));
						_LayoutArea.PropertyField(value2Property, EditorGUITools.GetTextContent("Bool Value 2"));
					}
					break;
			}
		}

		void DrawElement(Rect rect, int index, bool isActive, bool isFocused)
		{
			SerializedProperty property = _ConditionsList.serializedProperty.GetArrayElementAtIndex(index);

			_LayoutArea.Begin(rect, false, new RectOffset(0, 0, 2, 2));

			DoGUI(property);

			_LayoutArea.End();
		}

		float GetElementHeight(int index)
		{
			SerializedProperty property = _ConditionsList.serializedProperty.GetArrayElementAtIndex(index);

			float height = 0f;
			if (!_PropertyHeights.TryGetHeight(property, out height))
			{
				_LayoutArea.Begin(new Rect(), true, new RectOffset(0, 0, 2, 2));

				DoGUI(property);

				_LayoutArea.End();

				height = _LayoutArea.rect.height;
			}

			return height;
		}

		SerializedProperty GetParametersProperty(CalculatorCondition.Type type)
		{
			switch (type)
			{
				case CalculatorCondition.Type.Int:
					return _IntParameters;
				case CalculatorCondition.Type.Float:
					return _FloatParameters;
				case CalculatorCondition.Type.Bool:
					return _BoolParameters;
			}

			return null;
		}

		void DeleteParameter(SerializedProperty elementProperty, CalculatorCondition.Type type,bool deleteParameter )
		{
			SerializedProperty parametersProperty = GetParametersProperty(type);
			if (parametersProperty == null)
			{
				return;
			}

			SerializedProperty parameterIndexProperty = elementProperty.FindPropertyRelative(kParameterIndexPath);
			int parameterIndex = parameterIndexProperty.intValue;
			SerializedProperty parameterProperty = parametersProperty.GetArrayElementAtIndex(parameterIndex);

			if (parameterProperty == null)
			{
				return;
			}

			foreach (object valueObj in EditorGUITools.GetPropertyObjects(parameterProperty))
			{
				EachField<DataSlot>.Find(valueObj, valueObj.GetType(), (s) =>
				{
					s.Disconnect();
				});
			}

			if (deleteParameter)
			{
				parametersProperty.DeleteArrayElementAtIndex(parameterIndex);

				for (int i = 0, count = _ConditionsList.serializedProperty.arraySize; i < count; i++)
				{
					SerializedProperty p = _ConditionsList.serializedProperty.GetArrayElementAtIndex(i);
					CalculatorCondition.Type t = GetType(p);
					if (t != type)
					{
						continue;
					}
					SerializedProperty indexProperty = p.FindPropertyRelative(kParameterIndexPath);
					if (indexProperty.intValue > parameterIndex)
					{
						indexProperty.intValue--;
					}
				}
			}
		}

		void OnChangeParameterType(SerializedProperty elementProperty, CalculatorCondition.Type oldType, CalculatorCondition.Type newType)
		{
			DeleteParameter(elementProperty, oldType, true);
			AddParameter(elementProperty, newType);
		}

		void ClearCache()
		{
			_PropertyHeights.Clear();
		}

		protected override void OnGUI(Rect position, GUIContent label)
		{
			if (Event.current.type == EventType.Layout)
			{
				ClearCache();
			}

			if (_ConditionsList != null)
			{
				var oldIndentLevel = EditorGUI.indentLevel;
				EditorGUI.indentLevel = 0;
				_ConditionsList.DoList(position);
				EditorGUI.indentLevel = oldIndentLevel;
			}
		}

		protected override float GetHeight(GUIContent label)
		{
			if (Event.current.type == EventType.Layout)
			{
				ClearCache();
			}

			float height = 0f;
			if (_ConditionsList != null)
			{
				var oldIndentLevel = EditorGUI.indentLevel;
				EditorGUI.indentLevel = 0;
				height = _ConditionsList.GetHeight();
				EditorGUI.indentLevel = oldIndentLevel;
			}

			return height;
		}
	}

	[CustomPropertyDrawer(typeof(CalculatorConditionList))]
	class CalculatorConditionListPropertyDrawer : PropertyEditorDrawer<CalculatorConditionListEditor>
	{
	}
}