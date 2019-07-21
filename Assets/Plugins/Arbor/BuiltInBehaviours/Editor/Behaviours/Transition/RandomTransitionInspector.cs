using UnityEngine;
using UnityEditor;
using System.Collections;

using Arbor.StateMachine.StateBehaviours;

namespace ArborEditor.StateMachine.StateBehaviours
{
	[CustomEditor(typeof(RandomTransition))]
	public class RandomTransitionInspector : Editor
	{
		private RandomTransition _RandomTransition;
		private SerializedProperty _LinksProperty;
		private ListGUI _LinksList;
		private float _TotalWeight;

		private void OnEnable()
		{
			_RandomTransition = target as RandomTransition;

			_LinksProperty = serializedObject.FindProperty( "_Links" );

			_LinksList = new ListGUI( _LinksProperty );

			_LinksList.drawChild = OnDrawChild;
		}

		void OnDrawChild( SerializedProperty property )
		{
			SerializedProperty weightProperty = property.FindPropertyRelative( "weight" );

			EditorGUILayout.LabelField( property.displayName );

			EditorGUILayout.PropertyField( weightProperty );

			float r = ( _TotalWeight != 0.0f ) ? weightProperty.floatValue / _TotalWeight : 0.0f;

			EditorGUILayout.LabelField( "Probability",string.Format("{0:P1}", r ) );
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			_TotalWeight = _RandomTransition.GetTotalWeight();

			_LinksList.OnGUI();

			serializedObject.ApplyModifiedProperties();
		}
	}
}
