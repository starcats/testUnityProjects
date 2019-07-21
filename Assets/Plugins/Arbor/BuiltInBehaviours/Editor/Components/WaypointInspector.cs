using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Collections;

using Arbor;
namespace ArborEditor
{
	[CustomEditor(typeof(Waypoint))]
	public sealed class WaypointInspector : Editor
	{
		private ReorderableList _PointsList;
		private SerializedProperty _GizmosColorProperty;

		private void OnEnable()
		{
			SerializedProperty pointsProperty = serializedObject.FindProperty("_Points");

			_GizmosColorProperty = serializedObject.FindProperty("_GizmosColor");

			_PointsList = new ReorderableList(serializedObject, pointsProperty);

			_PointsList.drawHeaderCallback = (rect) =>
			{
				EditorGUI.LabelField(rect, pointsProperty.displayName);
			};

			_PointsList.drawElementCallback = (rect, index, isActive, isFocused) =>
			{
				SerializedProperty element = pointsProperty.GetArrayElementAtIndex(index);
				rect.height -= EditorGUIUtility.standardVerticalSpacing * 2;
				rect.y += EditorGUIUtility.standardVerticalSpacing;
				EditorGUI.PropertyField(rect, element);
			};

			_PointsList.onRemoveCallback = (list) =>
			{
				int index = list.index;
				SerializedProperty property = pointsProperty.GetArrayElementAtIndex(index);
				if (property.objectReferenceValue != null)
				{
					pointsProperty.DeleteArrayElementAtIndex(index);
				}
				pointsProperty.DeleteArrayElementAtIndex(index);
			};
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			_PointsList.DoLayoutList();
			EditorGUILayout.PropertyField(_GizmosColorProperty);

			serializedObject.ApplyModifiedProperties();
		}
	}
}