using UnityEngine;
using UnityEditor;
using System.Collections;

using Arbor.StateMachine.StateBehaviours;

namespace ArborEditor.StateMachine.StateBehaviours
{
	[CustomEditor(typeof(InstantiateGameObject))]
	public class InstantiateGameObjectInspector : Editor
	{
		SerializedProperty _PrefabProperty;
		SerializedProperty _ParentProperty;
		SerializedProperty _InitTransformProperty;
		SerializedProperty _UsePoolProperty;
		SerializedProperty _ParameterProperty;
		SerializedProperty _OutputProperty;

		private void OnEnable()
		{
			_PrefabProperty = serializedObject.FindProperty("_Prefab");
			_ParentProperty = serializedObject.FindProperty("_Parent");
			_InitTransformProperty = serializedObject.FindProperty("_InitTransform");
			_UsePoolProperty = serializedObject.FindProperty("_UsePool");
			_ParameterProperty = serializedObject.FindProperty("_Parameter");
			_OutputProperty = serializedObject.FindProperty("_Output");
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update ();
			
			EditorGUILayout.PropertyField(_PrefabProperty);
			EditorGUILayout.PropertyField(_ParentProperty);
			EditorGUILayout.PropertyField(_InitTransformProperty);
			EditorGUILayout.PropertyField(_UsePoolProperty);
			EditorGUILayout.PropertyField(_ParameterProperty);
			EditorGUILayout.PropertyField(_OutputProperty);

			serializedObject.ApplyModifiedProperties();
		}
	}
}
