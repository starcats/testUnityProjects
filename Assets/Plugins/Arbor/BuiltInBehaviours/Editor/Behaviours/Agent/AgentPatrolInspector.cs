using UnityEngine;
using UnityEditor;
using System.Collections;

namespace ArborEditor.StateMachine.StateBehaviours
{
	using Arbor;
	using Arbor.StateMachine.StateBehaviours;

	[CustomEditor(typeof(AgentPatrol))]
	public class AgentPatrolInspector : AgentMoveBaseInspector
	{
		SerializedProperty _RadiusProperty;
		SerializedProperty _CenterTypeProperty;
		SerializedProperty _CenterTransformProperty;
		SerializedProperty _CenterPositionProperty;

		private void OnEnable()
		{
			_RadiusProperty = serializedObject.FindProperty("_Radius");
			_CenterTypeProperty = serializedObject.FindProperty("_CenterType");
			_CenterTransformProperty = serializedObject.FindProperty("_CenterTransform");
			_CenterPositionProperty = serializedObject.FindProperty("_CenterPosition");
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			DrawBase();

			EditorGUILayout.Space();

			EditorGUILayout.PropertyField(_RadiusProperty);
			EditorGUILayout.PropertyField(_CenterTypeProperty);

			PatrolCenterType patrolCenterType = EnumUtility.GetValueFromIndex<PatrolCenterType>(_CenterTypeProperty.enumValueIndex);
			switch (patrolCenterType)
			{
				case PatrolCenterType.InitialPlacementPosition:
					break;
				case PatrolCenterType.StateStartPosition:
					break;
				case PatrolCenterType.Transform:
					EditorGUILayout.PropertyField(_CenterTransformProperty);
					break;
				case PatrolCenterType.Custom:
					EditorGUILayout.PropertyField(_CenterPositionProperty);
					break;
			}

			serializedObject.ApplyModifiedProperties();
		}
	}
}