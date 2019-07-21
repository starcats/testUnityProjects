﻿using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Collections;

using Arbor;
using Arbor.StateMachine.StateBehaviours;

namespace ArborEditor.StateMachine.StateBehaviours
{
	[CustomEditor(typeof(SubStateMachine))]
	public class SubStateMachineInspector : NodeBehaviourEditor
	{
		[BehaviourMenuItem(typeof(SubStateMachine), "Save To Prefab", localization = true)]
		static void SaveToPrefab(MenuCommand command)
		{
			SubStateMachine behaviour = command.context as SubStateMachine;
			NodeGraph nodeGraph = behaviour.subFSM;

			string path = EditorUtility.SaveFilePanelInProject(Localization.GetWord("Save To Prefab"), nodeGraph.graphName, "prefab", "");
			if (string.IsNullOrEmpty(path))
			{
				return;
			}

			Clipboard.SaveToPrefab(path, nodeGraph);
		}

		private GraphArgumentListEditor _ArgumentListEditor = null;

		private GraphArgumentListEditor argumentListEditor
		{
			get
			{
				if (_ArgumentListEditor == null)
				{
					_ArgumentListEditor = new GraphArgumentListEditor(serializedObject.FindProperty("_ArgumentList"));

					SubStateMachine subStateMachine = target as SubStateMachine;
					_ArgumentListEditor.nodeGraph = subStateMachine.subFSM;
				}
				return _ArgumentListEditor;
			}
		}

		void DropNodes(Node[] nodes)
		{
			SubStateMachine subStateMachine = target as SubStateMachine;
			ArborFSM subFSM = subStateMachine.subFSM;

			Undo.IncrementCurrentGroup();
			int undoGroup = Undo.GetCurrentGroup();

			Undo.RegisterCompleteObjectUndo(subFSM, "DropNodes");

			Clipboard.DuplicateNodes(Vector2.zero, nodes, subFSM, false);
			graphEditor.DeleteNodes(nodes);

			Undo.CollapseUndoOperations(undoGroup);
		}

		void DropNodesField()
		{
			GUIContent content = Localization.GetTextContent("Drop Nodes");
			GUIStyle style = ArborEditor.Styles.dropField;
			Rect rect = GUILayoutUtility.GetRect(content, style);

			Event current = Event.current;

			EventType eventType = current.type;

			switch (eventType)
			{
				case EventType.Repaint:
					{
						graphEditor.AddDropNodesListener(rect, DropNodes);

						bool isHover = rect.Contains(current.mousePosition);
						style.Draw(rect, content, false, false, isHover , false);
					}
					break;
			}
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			SubStateMachine subStateMachine = target as SubStateMachine;
			NodeGraph nodeGraph = subStateMachine.subFSM;

			if (graphEditor != null && graphEditor.isDragNodes && !graphEditor.IsDraggingNode(nodeEditor.node))
			{
				DropNodesField();
			}
			else
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