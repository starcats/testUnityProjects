using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Collections.Generic;

namespace ArborEditor
{
	using Arbor;
	[CustomPropertyDrawer(typeof(WeightListBase),true)]
	public class WeightListPropertyDrawer : PropertyDrawer
	{
		public delegate void OnPreValueFieldCallbackDelegate(SerializedProperty valueProperty);

		public static event OnPreValueFieldCallbackDelegate onPreValueFieldCallback;

		private class ListElement
		{
			private SerializedProperty _ListProperty;
			private WeightListBase _WeightList;
			private SerializedProperty _ValuesProperty;
			private SerializedProperty _WeightsProperty;
			private int _SelectIndex;

			private float _TotalWeight;

			public ReorderableList list
			{
				get;
				private set;
			}

			public ListElement(SerializedProperty property)
			{
				_ListProperty = property;

				_WeightList = EditorGUITools.GetPropertyObject<WeightListBase>(_ListProperty);

				_ValuesProperty = property.FindPropertyRelative("_Values");
				_WeightsProperty = property.FindPropertyRelative("_Weights");

				list = new ReorderableList(property.serializedObject, _ValuesProperty)
				{
					drawHeaderCallback = DrawHeader,
					elementHeightCallback = ElementHeight,
					drawElementCallback = DrawElement,
					onAddCallback = OnAdd,
					onRemoveCallback = OnRemove,
					onSelectCallback = OnSelect,
					onReorderCallback = OnReorder,
				};
			}

			private void DrawHeader(Rect rect)
			{
				EditorGUI.LabelField(rect, _ListProperty.displayName);
			}

			private float ElementHeight(int index)
			{
				SerializedProperty valueProperty = _ValuesProperty.GetArrayElementAtIndex(index);
				SerializedProperty weightProperty = _WeightsProperty.GetArrayElementAtIndex(index);

				float height = list.elementHeight + EditorGUIUtility.standardVerticalSpacing;

				if (onPreValueFieldCallback != null)
				{
					onPreValueFieldCallback(valueProperty);
				}
				height += EditorGUI.GetPropertyHeight(valueProperty, EditorGUITools.GetTextContent("Value"), true) + EditorGUIUtility.standardVerticalSpacing;
				height += EditorGUI.GetPropertyHeight(weightProperty, EditorGUITools.GetTextContent("Weight"), true) + EditorGUIUtility.standardVerticalSpacing;
				height += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

				return height;
			}

			private void DrawElement(Rect rect, int index, bool isActive, bool isFocused)
			{
				if (index == 0)
				{
					_TotalWeight = _WeightList.GetTotalWeight();
				}

				rect.height = list.elementHeight;

				EditorGUI.LabelField(rect, EditorGUITools.GetTextContent("Element " + index));
				rect.y += rect.height + EditorGUIUtility.standardVerticalSpacing;

				SerializedProperty valueProperty = _ValuesProperty.GetArrayElementAtIndex(index);

				if (onPreValueFieldCallback != null)
				{
					onPreValueFieldCallback(valueProperty);
				}

				GUIContent valueContent = EditorGUITools.GetTextContent("Value");
				rect.height = EditorGUI.GetPropertyHeight(valueProperty, valueContent, true);

				EditorGUI.PropertyField(rect, valueProperty, valueContent);
				rect.y += rect.height + EditorGUIUtility.standardVerticalSpacing;

				SerializedProperty weightProperty = _WeightsProperty.GetArrayElementAtIndex(index);

				GUIContent weightContent = EditorGUITools.GetTextContent("Weight");
				rect.height = EditorGUI.GetPropertyHeight(weightProperty, weightContent, true);
				EditorGUI.PropertyField(rect, weightProperty, weightContent);
				rect.y += rect.height + EditorGUIUtility.standardVerticalSpacing;

				float probability = (_TotalWeight != 0.0f) ? weightProperty.floatValue / _TotalWeight : 0.0f;
				EditorGUI.LabelField(rect, "Probability", string.Format("{0:P1}", probability) );
				rect.y += rect.height + EditorGUIUtility.standardVerticalSpacing;
			}

			private void OnSelect(ReorderableList list)
			{
				_SelectIndex = list.index;
			}

			private void OnReorder(ReorderableList list)
			{
				_WeightsProperty.MoveArrayElement(_SelectIndex, list.index);
			}

			private void OnAdd(ReorderableList list)
			{
				_ValuesProperty.arraySize++;
				_WeightsProperty.arraySize = _ValuesProperty.arraySize;

				list.index = _ValuesProperty.arraySize - 1;
			}

			private void OnRemove(ReorderableList list)
			{
				int index = list.index;
				SerializedProperty valueProperty = _ValuesProperty.GetArrayElementAtIndex(index);
				if (valueProperty.propertyType == SerializedPropertyType.ObjectReference && valueProperty.objectReferenceValue != null )
				{
					_ValuesProperty.DeleteArrayElementAtIndex(index);
				}
				_ValuesProperty.DeleteArrayElementAtIndex(index);

				_WeightsProperty.DeleteArrayElementAtIndex(index);
			}
		}

		private Dictionary<SerializedProperty, ListElement> _ListElements = new Dictionary<SerializedProperty, ListElement>(SerializedPropertyComparer.Comparer);

		private ReorderableList GetList(SerializedProperty property)
		{
			ListElement listElement = null;
			if (!_ListElements.TryGetValue(property, out listElement))
			{
				listElement = new ListElement(property);

				_ListElements.Add(property, listElement);
			}
			return listElement.list;
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			ReorderableList list = GetList(property);
			return list.GetHeight();
		}

		public override void OnGUI(Rect totalPosition, SerializedProperty property, GUIContent label)
		{
			ReorderableList list = GetList(property);
			list.DoList(totalPosition);
		}
	}
}