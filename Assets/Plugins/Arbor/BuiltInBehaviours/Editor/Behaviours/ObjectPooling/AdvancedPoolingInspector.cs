using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Collections;

namespace ArborEditor.StateMachine.StateBehaviours.ObjectPooling
{
	using Arbor.StateMachine.StateBehaviours.ObjectPooling;
	
	[CustomEditor(typeof(AdvancedPooling))]
	public class AdvancedPoolingInspector : Editor
	{
		// Paths
		private const string kPoolingItemsPath = "_PoolingItems";

		private SerializedProperty _PoolingItems;

		void OnEnable()
		{
			_PoolingItems = serializedObject.FindProperty(kPoolingItemsPath);
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			EditorGUILayout.PropertyField(_PoolingItems);

			serializedObject.ApplyModifiedProperties();
		}
	}
}
