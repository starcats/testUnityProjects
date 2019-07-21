using UnityEngine;
using UnityEditor;

namespace ArborEditor
{
	using Arbor;

	[CustomEditor(typeof(RandomSelectComponent))]
	public class RandomSelectComponentInspector : NodeBehaviourEditor
	{
		RandomSelectComponent _Target;
		SerializedProperty _TypeProperty;
		SerializedProperty _WeightsProperty;
		SerializedProperty _OutputProperty;
		ClassConstraintInfo _ConstraintInfo = null;

		private DataSlotField outputSlotField
		{
			get
			{
				DataSlot slot = EditorGUITools.GetPropertyObject<DataSlot>(_OutputProperty);
				NodeBehaviour nodeBehaviour = target as NodeBehaviour;
				if (nodeBehaviour != null)
				{
					return nodeBehaviour.GetDataSlotField(slot);
				}

				return null;
			}
		}

		private void OnEnable()
		{
			_Target = target as RandomSelectComponent;

			_ConstraintInfo = new ClassConstraintInfo();

			_WeightsProperty = serializedObject.FindProperty("_Weights");
			_OutputProperty = serializedObject.FindProperty("_Output");
			_TypeProperty = _OutputProperty.FindPropertyRelative("_Type");

			WeightListPropertyDrawer.onPreValueFieldCallback += OnPreValueField;
		}

		private void OnDisable()
		{
			WeightListPropertyDrawer.onPreValueFieldCallback -= OnPreValueField;
		}

		void OnPreValueField(SerializedProperty valueProperty)
		{
			if (valueProperty.serializedObject.targetObject != target)
			{
				return;
			}

			if (_ConstraintInfo != null)
			{
				valueProperty.SetStateData(_ConstraintInfo.GetConstraintBaseType());
			}
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			_ConstraintInfo.baseType = _Target.type;

			EditorGUILayout.PropertyField(_TypeProperty);
			EditorGUILayout.PropertyField(_WeightsProperty);

			DataSlotField slotField = outputSlotField;
			if (slotField != null && _ConstraintInfo != null)
			{
				slotField.overrideConstraint = _ConstraintInfo;
			}
			EditorGUILayout.PropertyField(_OutputProperty);

			serializedObject.ApplyModifiedProperties();
		}
	}
}