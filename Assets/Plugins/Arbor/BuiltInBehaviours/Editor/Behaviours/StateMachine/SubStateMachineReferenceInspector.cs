using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Collections;

using Arbor;
using Arbor.StateMachine.StateBehaviours;

namespace ArborEditor.StateMachine.StateBehaviours
{
	[CustomEditor(typeof(SubStateMachineReference))]
	public class SubStateMachineReferenceInspector : NodeBehaviourEditor
	{
		private FlexibleFieldProperty _ExternalFSMProperty;

		private void OnEnable()
		{
			_ExternalFSMProperty = new FlexibleFieldProperty(serializedObject.FindProperty("_ExternalFSM"));
		}

		private GraphArgumentListEditor _ArgumentListEditor = null;

		private GraphArgumentListEditor argumentListEditor
		{
			get
			{
				if (_ArgumentListEditor == null)
				{
					_ArgumentListEditor = new GraphArgumentListEditor(serializedObject.FindProperty("_ArgumentList"));
					_ArgumentListEditor.nodeGraph = GetExternalGraph();
				}
				return _ArgumentListEditor;
			}
		}

		NodeGraph GetExternalGraph()
		{
			FlexibleType type = EnumUtility.GetValueFromIndex<FlexibleType>(_ExternalFSMProperty.type.enumValueIndex);
			if (type == FlexibleType.Constant)
			{
				return _ExternalFSMProperty.value.objectReferenceValue as NodeGraph;
			}

			return null;
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			EditorGUI.BeginChangeCheck();
			EditorGUILayout.PropertyField(_ExternalFSMProperty.property);
			if (EditorGUI.EndChangeCheck())
			{
				argumentListEditor.nodeGraph = GetExternalGraph();
			}

			EditorGUILayout.PropertyField(serializedObject.FindProperty("_UsePool"));

			SubStateMachineReference subStateMachine = target as SubStateMachineReference;
			NodeGraph nodeGraph = subStateMachine.runtimeFSM;

			if (nodeGraph != null)
			{
				if (GUILayout.Button("Open " + nodeGraph.displayGraphName, ArborEditor.Styles.largeButton))
				{
					if (graphEditor != null)
					{
						graphEditor.hostWindow.ChangeCurrentNodeGraph(nodeGraph);
					}
				}
			}

			EditorGUILayout.PropertyField(serializedObject.FindProperty("_PassThroughTrigger"));

			argumentListEditor.DoLayoutList();

			serializedObject.ApplyModifiedProperties();
		}
	}
}
