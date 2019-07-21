﻿using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Collections;

namespace ArborEditor
{
	using Arbor;

	class ParameterConditionListEditor : PropertyEditor
	{
		ReorderableList _ConditionsList;

		SerializedProperty _IntParameters;
		SerializedProperty _LongParameters;
		SerializedProperty _FloatParameters;
		SerializedProperty _BoolParameters;
		SerializedProperty _StringParameters;
		SerializedProperty _EnumParameters;
		SerializedProperty _Vector2Parameters;
		SerializedProperty _Vector3Parameters;
		SerializedProperty _QuaternionParameters;
		SerializedProperty _RectParameters;
		SerializedProperty _BoundsParameters;
		SerializedProperty _ColorParameters;
		SerializedProperty _GameObjectParameters;
		SerializedProperty _ComponentParameters;

		private LayoutArea _LayoutArea = new LayoutArea();

		private PropertyHeightCache _PropertyHeights = new PropertyHeightCache();
		
		protected override void OnInitialize()
		{
			_ConditionsList = new ReorderableList(property.serializedObject, property.FindPropertyRelative("_Conditions"));
			_ConditionsList.drawHeaderCallback = DrawHeader;
			_ConditionsList.onAddCallback = OnAdd;
			_ConditionsList.onRemoveCallback = OnRemove;
			_ConditionsList.drawElementCallback = DrawElement;
			_ConditionsList.elementHeightCallback = GetElementHeight;

			_IntParameters = property.FindPropertyRelative("_IntParameters");
			_LongParameters = property.FindPropertyRelative("_LongParameters");
			_FloatParameters = property.FindPropertyRelative("_FloatParameters");
			_BoolParameters = property.FindPropertyRelative("_BoolParameters");
			_EnumParameters = property.FindPropertyRelative("_EnumParameters");
			_StringParameters = property.FindPropertyRelative("_StringParameters");
			_Vector2Parameters = property.FindPropertyRelative("_Vector2Parameters");
			_Vector3Parameters = property.FindPropertyRelative("_Vector3Parameters");
			_QuaternionParameters = property.FindPropertyRelative("_QuaternionParameters");
			_RectParameters = property.FindPropertyRelative("_RectParameters");
			_BoundsParameters = property.FindPropertyRelative("_BoundsParameters");
			_ColorParameters = property.FindPropertyRelative("_ColorParameters");
			_GameObjectParameters = property.FindPropertyRelative("_GameObjectParameters");
			_ComponentParameters = property.FindPropertyRelative("_ComponentParameters");
		}

		void DrawHeader(Rect rect)
		{
			EditorGUI.LabelField(rect, property.displayName);
		}

		void AddParameter(ParameterConditionProperty conditionProperty, Parameter.Type parameterType)
		{
			conditionProperty.parameterType = parameterType;

			SerializedProperty parametersProperty = GetParametersProperty(parameterType);

			if (parametersProperty != null)
			{
				parametersProperty.arraySize++;
				int parameterIndex = parametersProperty.arraySize - 1;

				SerializedProperty valueProperty = parametersProperty.GetArrayElementAtIndex(parameterIndex);

				FlexibleFieldProperty fieldProperty = null;
				switch (parameterType)
				{
					case Parameter.Type.Int:
					case Parameter.Type.Float:
					case Parameter.Type.Long:
						fieldProperty = new FlexibleNumericProperty(valueProperty);
						break;
					case Parameter.Type.Bool:
						fieldProperty = new FlexibleBoolProperty(valueProperty);
						break;
					default:
						fieldProperty = new FlexibleFieldProperty(valueProperty);
						break;
				}

				fieldProperty.Clear(true);

				conditionProperty.parameterIndex = parameterIndex;
			}
		}

		void AddParameter(ParameterConditionProperty conditionProperty)
		{
			AddParameter(conditionProperty, conditionProperty.parameterType);
		}

		private void OnAdd(ReorderableList list)
		{
			ReorderableList.defaultBehaviours.DoAddButton(list);
			SerializedProperty elementProperty = list.serializedProperty.GetArrayElementAtIndex(list.index);
			ParameterConditionProperty conditionProperty = new ParameterConditionProperty(elementProperty);

			AddParameter(conditionProperty);
		}

		private void OnRemove(ReorderableList list)
		{
			SerializedProperty elementProperty = list.serializedProperty.GetArrayElementAtIndex(list.index);
			ParameterConditionProperty conditionProperty = new ParameterConditionProperty(elementProperty);
			DeleteParameter(conditionProperty, conditionProperty.parameterType, true);

			ReorderableList.defaultBehaviours.DoRemoveButton(list);
		}

		void DoGUI(SerializedProperty elementProperty)
		{
			ParameterConditionProperty conditionProperty = new ParameterConditionProperty(elementProperty);
			
			Parameter.Type oldParameterType = conditionProperty.parameterType;

			EditorGUI.BeginChangeCheck();
			_LayoutArea.PropertyField(conditionProperty.referenceProperty.property);
			if (EditorGUI.EndChangeCheck())
			{
				Parameter.Type parameterType = conditionProperty.GetParameterType();
				if (parameterType != oldParameterType)
				{
					OnChangeParameterType(conditionProperty, oldParameterType, parameterType);
				}
				oldParameterType = parameterType;
			}

			ParameterReferenceType parameterReferenceType = conditionProperty.referenceProperty.type;
			if (parameterReferenceType == ParameterReferenceType.DataSlot)
			{
				EditorGUI.BeginChangeCheck();
				_LayoutArea.PropertyField(conditionProperty.parameterTypeProperty);
				if (EditorGUI.EndChangeCheck())
				{
					Parameter.Type parameterType = conditionProperty.parameterType;
					if (parameterType != oldParameterType)
					{
						OnChangeParameterType(conditionProperty, oldParameterType, parameterType);

						conditionProperty.referenceType = null;
					}
					oldParameterType = parameterType;
				}

				switch (oldParameterType)
				{
					case Parameter.Type.Component:
						{
							System.Type oldReferenceType = conditionProperty.referenceType;

							conditionProperty.referenceTypeProperty.property.SetStateData<ClassTypeConstraintAttribute>(ClassTypeConstraintEditorUtility.component);

							EditorGUI.BeginChangeCheck();
							_LayoutArea.PropertyField(conditionProperty.referenceTypeProperty.property);
							if (EditorGUI.EndChangeCheck())
							{
								System.Type referenceType = conditionProperty.referenceType;
								if (referenceType != oldReferenceType)
								{
									DeleteParameter(conditionProperty, oldParameterType, false);
								}
								oldReferenceType = referenceType;
							}
						}
						break;
					case Parameter.Type.Enum:
						{
							System.Type oldReferenceType = conditionProperty.referenceType;

							conditionProperty.referenceTypeProperty.property.SetStateData<ClassTypeConstraintAttribute>(ClassTypeConstraintEditorUtility.enumField);

							EditorGUI.BeginChangeCheck();
							_LayoutArea.PropertyField(conditionProperty.referenceTypeProperty.property);
							if (EditorGUI.EndChangeCheck())
							{
								System.Type referenceType = conditionProperty.referenceType;
								if (referenceType != oldReferenceType)
								{
									DeleteParameter(conditionProperty, oldParameterType, false);
								}
								oldReferenceType = referenceType;
							}
						}
						break;
				}
			}

			if (parameterReferenceType == ParameterReferenceType.DataSlot || conditionProperty.referenceProperty.container != null)
			{
				ConditionGUI(conditionProperty);
			}
		}

		private void ConditionGUI(ParameterConditionProperty conditionProperty)
		{
			Parameter.Type parameterType = conditionProperty.parameterType;

			int parameterIndex = conditionProperty.parameterIndex;

			SerializedProperty compareTypeProperty = conditionProperty.compareTypeProperty;
			SerializedProperty parametersProperty = GetParametersProperty(parameterType);
			SerializedProperty valueProperty = parametersProperty != null ? parametersProperty.GetArrayElementAtIndex(parameterIndex) : null;

			switch (parameterType)
			{
				case Parameter.Type.Int:
					{
						_LayoutArea.PropertyField(compareTypeProperty);
						_LayoutArea.PropertyField(valueProperty, EditorGUITools.GetTextContent("Int Value"));
					}
					break;
				case Parameter.Type.Long:
					{
						_LayoutArea.PropertyField(compareTypeProperty);
						_LayoutArea.PropertyField(valueProperty, EditorGUITools.GetTextContent("Long Value"));
					}
					break;
				case Parameter.Type.Float:
					{
						_LayoutArea.PropertyField(compareTypeProperty);
						_LayoutArea.PropertyField(valueProperty, EditorGUITools.GetTextContent("Float Value"));
					}
					break;
				case Parameter.Type.Bool:
					{
						_LayoutArea.PropertyField(valueProperty, EditorGUITools.GetTextContent("Bool Value"));
					}
					break;
				case Parameter.Type.String:
					{
						_LayoutArea.PropertyField(compareTypeProperty);
						_LayoutArea.PropertyField(valueProperty, EditorGUITools.GetTextContent("String Value"));
					}
					break;
				case Parameter.Type.GameObject:
					{
						_LayoutArea.PropertyField(valueProperty, EditorGUITools.GetTextContent("GameObject Value"));
					}
					break;
				case Parameter.Type.Vector2:
					{
						_LayoutArea.PropertyField(valueProperty, EditorGUITools.GetTextContent("Vector2 Value"));
					}
					break;
				case Parameter.Type.Vector3:
					{
						_LayoutArea.PropertyField(valueProperty, EditorGUITools.GetTextContent("Vector3 Value"));
					}
					break;
				case Parameter.Type.Quaternion:
					{
						_LayoutArea.PropertyField(valueProperty, EditorGUITools.GetTextContent("Quaternion Value"));
					}
					break;
				case Parameter.Type.Rect:
					{
						_LayoutArea.PropertyField(valueProperty, EditorGUITools.GetTextContent("Rect Value"));
					}
					break;
				case Parameter.Type.Bounds:
					{
						_LayoutArea.PropertyField(valueProperty, EditorGUITools.GetTextContent("Bounds Value"));
					}
					break;
				case Parameter.Type.Color:
					{
						_LayoutArea.PropertyField(valueProperty, EditorGUITools.GetTextContent("Color Value"));
					}
					break;
				case Parameter.Type.Transform:
					{
						valueProperty.SetStateData(typeof(Transform));
						_LayoutArea.PropertyField(valueProperty, EditorGUITools.GetTextContent("Transform Value"));
					}
					break;
				case Parameter.Type.RectTransform:
					{
						valueProperty.SetStateData(typeof(RectTransform));
						_LayoutArea.PropertyField(valueProperty, EditorGUITools.GetTextContent("RectTransform Value"));
					}
					break;
				case Parameter.Type.Rigidbody:
					{
						valueProperty.SetStateData(typeof(Rigidbody));
						_LayoutArea.PropertyField(valueProperty, EditorGUITools.GetTextContent("Rigidbody Value"));
					}
					break;
				case Parameter.Type.Rigidbody2D:
					{
						valueProperty.SetStateData(typeof(Rigidbody2D));
						_LayoutArea.PropertyField(valueProperty, EditorGUITools.GetTextContent("Rigidbody2D Value"));
					}
					break;
				case Parameter.Type.Component:
					{
						valueProperty.SetStateData(conditionProperty.GetReferenceType());

						_LayoutArea.PropertyField(valueProperty, EditorGUITools.GetTextContent("Component Value"));
					}
					break;
				case Parameter.Type.Enum:
					{
						valueProperty.SetStateData(conditionProperty.GetReferenceType());

						_LayoutArea.PropertyField(valueProperty, EditorGUITools.GetTextContent("Enum Value"));
					}
					break;
				case Parameter.Type.Variable:
					{
						Parameter parameter = conditionProperty.referenceProperty.GetParameter();
						string valueTypeName = (parameter != null && parameter.valueType != null) ? parameter.valueType.ToString() : "Variable";
						string message = string.Format(Localization.GetWord("ParameterCondition.NotSupportVariable"), valueTypeName);

						_LayoutArea.HelpBox(message, MessageType.Warning);
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

				_PropertyHeights.AddHeight(property, height);
			}

			return height;
		}

		SerializedProperty GetParametersProperty(Parameter.Type parameterType)
		{
			switch (parameterType)
			{
				case Parameter.Type.Int:
					return _IntParameters;
				case Parameter.Type.Long:
					return _LongParameters;
				case Parameter.Type.Float:
					return _FloatParameters;
				case Parameter.Type.Bool:
					return _BoolParameters;
				case Parameter.Type.String:
					return _StringParameters;
				case Parameter.Type.Enum:
					return _EnumParameters;
				case Parameter.Type.GameObject:
					return _GameObjectParameters;
				case Parameter.Type.Vector2:
					return _Vector2Parameters;
				case Parameter.Type.Vector3:
					return _Vector3Parameters;
				case Parameter.Type.Quaternion:
					return _QuaternionParameters;
				case Parameter.Type.Rect:
					return _RectParameters;
				case Parameter.Type.Bounds:
					return _BoundsParameters;
				case Parameter.Type.Color:
					return _ColorParameters;
				case Parameter.Type.Transform:
				case Parameter.Type.RectTransform:
				case Parameter.Type.Rigidbody:
				case Parameter.Type.Rigidbody2D:
				case Parameter.Type.Component:
					return _ComponentParameters;
				case Parameter.Type.Variable:
					return null;
			}

			return null;
		}

		void DeleteParameter(ParameterConditionProperty conditionProperty, Parameter.Type parameterType,bool deleteParameter )
		{
			SerializedProperty parametersProperty = GetParametersProperty(parameterType);
			if (parametersProperty == null)
			{
				return;
			}

			int parameterIndex = conditionProperty.parameterIndex;
			SerializedProperty valueProperty = parametersProperty.GetArrayElementAtIndex(parameterIndex);

			if (valueProperty == null)
			{
				return;
			}

			foreach (object valueObj in EditorGUITools.GetPropertyObjects(valueProperty))
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
					ParameterConditionProperty cp = new ParameterConditionProperty(p);
					Parameter.Type t = cp.GetParameterType();
					SerializedProperty parameters = GetParametersProperty(t);
					if (!SerializedProperty.EqualContents(parameters,parametersProperty))
					{
						continue;
					}
					if (cp.parameterIndex > parameterIndex)
					{
						cp.parameterIndex--;
					}
				}
			}
		}

		void OnChangeParameterType(ParameterConditionProperty conditionProperty, Parameter.Type oldType, Parameter.Type newType)
		{
			DeleteParameter(conditionProperty, oldType, true);

			AddParameter(conditionProperty, newType);
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

	[CustomPropertyDrawer(typeof(ParameterConditionList))]
	class ParameterConditionListPropertyDrawer : PropertyEditorDrawer<ParameterConditionListEditor>
	{
	}
}