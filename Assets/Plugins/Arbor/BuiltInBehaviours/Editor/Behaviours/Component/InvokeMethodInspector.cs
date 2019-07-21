using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;

namespace ArborEditor.StateMachine.StateBehaviours
{
	using Arbor;
	using Arbor.StateMachine.StateBehaviours;

	[CustomEditor(typeof(InvokeMethod))]
	public class InvokeMethodInspector : NodeBehaviourEditor
	{
		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			EditorGUILayout.PropertyField(serializedObject.FindProperty("_OnStateAwake"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("_OnStateBegin"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("_OnStateEnd"));

			serializedObject.ApplyModifiedProperties();
		}
	}
}