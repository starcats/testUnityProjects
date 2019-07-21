using UnityEngine;
using UnityEditor;
using System.Collections;

using Arbor;
using Arbor.StateMachine.StateBehaviours;

namespace ArborEditor.StateMachine.StateBehaviours
{
	public class TweenBaseInspector : Editor
	{
		TweenBase _Target;

		protected virtual void OnEnable()
		{
			_Target = target as TweenBase;
		}

		protected void DrawBase()
		{
			SerializedProperty typeProperty = serializedObject.FindProperty("_Type");

            EditorGUILayout.PropertyField( typeProperty );
			EditorGUILayout.PropertyField( serializedObject.FindProperty( "_Duration" ) );
			EditorGUILayout.PropertyField( serializedObject.FindProperty( "_Curve" ) );
			if (!_Target.fixedUpdate && !_Target.forceRealtime)
			{
				EditorGUILayout.PropertyField(serializedObject.FindProperty("_UseRealtime"));
			}
			
			TweenBase.Type type = EnumUtility.GetValueFromIndex<TweenBase.Type>(typeProperty.enumValueIndex);
			if (type != TweenBase.Type.Once)
			{
				SerializedProperty repeatUntilTransition = serializedObject.FindProperty("_RepeatUntilTransition");
                EditorGUILayout.PropertyField(repeatUntilTransition);

				SerializedProperty primitiveTypeProperty = repeatUntilTransition.FindPropertyRelative("_Type");
				FlexiblePrimitiveType primitiveType = EnumUtility.GetValueFromIndex<FlexiblePrimitiveType>(primitiveTypeProperty.enumValueIndex);
				switch (primitiveType)
				{
					case FlexiblePrimitiveType.Constant:
						{
							SerializedProperty valueProperty = repeatUntilTransition.FindPropertyRelative("_Value");
							valueProperty.intValue = Mathf.Max(valueProperty.intValue, 1);
						}
						break;
					case FlexiblePrimitiveType.Random:
						{
							SerializedProperty minProperty = repeatUntilTransition.FindPropertyRelative("_MinRange");
							minProperty.intValue = Mathf.Max(minProperty.intValue, 1);

							SerializedProperty maxProperty = repeatUntilTransition.FindPropertyRelative("_MaxRange");
							maxProperty.intValue = Mathf.Max(maxProperty.intValue, 1);
						}
						break;
				}

				if (Application.isPlaying && _Target.stateMachine.currentState == _Target.state)
				{
					Rect r = EditorGUILayout.BeginVertical();
					EditorGUI.ProgressBar(r, (float)_Target.repeatCount / (float)_Target.repeatUntilTransition , _Target.repeatCount.ToString() );
					GUILayout.Space(16);
					EditorGUILayout.EndVertical();
				}
            }
		}

		public override bool RequiresConstantRepaint()
		{
			return Application.isPlaying && _Target.stateMachine.currentState == _Target.state;
		}
	}
}
