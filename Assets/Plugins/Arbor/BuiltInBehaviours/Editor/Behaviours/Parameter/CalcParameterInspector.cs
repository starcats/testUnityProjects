using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

using Arbor;
using Arbor.StateMachine.StateBehaviours;

namespace ArborEditor.StateMachine.StateBehaviours
{
	[CustomEditor(typeof(CalcParameter))]
	public class CalcParameterInspector : Editor
	{
		ParameterReferenceProperty _ParameterReference;

		private ParameterReferenceProperty GetParameterReference()
		{
			if (_ParameterReference == null)
			{
				_ParameterReference = new ParameterReferenceProperty(serializedObject.FindProperty("reference"));
			}

			return _ParameterReference;
		}

		Parameter.Type GetParameterType()
		{
			ParameterReferenceProperty referenceProperty = GetParameterReference();

			SerializedProperty parameterTypeProperty = serializedObject.FindProperty("_ParameterType");

			ParameterReferenceType parameterReferenceType = referenceProperty.type;
			Parameter.Type parameterType = Parameter.Type.Int;
			switch (parameterReferenceType)
			{
				case ParameterReferenceType.Constant:
					{
						Parameter parameter = referenceProperty.GetParameter();
						if (parameter != null)
						{
							parameterType = parameter.type;
						}
					}
					break;
				case ParameterReferenceType.DataSlot:
					{
						parameterType = EnumUtility.GetValueFromIndex<Parameter.Type>(parameterTypeProperty.enumValueIndex);
					}
					break;
			}

			return parameterType;
		}

		System.Type GetReferenceType()
		{
			ParameterReferenceProperty referenceProperty = GetParameterReference();

			ParameterReferenceType parameterReferenceType = referenceProperty.type;
			System.Type referenceType = null;
			switch (parameterReferenceType)
			{
				case ParameterReferenceType.Constant:
					{
						Parameter parameter = referenceProperty.GetParameter();
						if (parameter != null)
						{
							referenceType = parameter.referenceType;
						}
					}
					break;
				case ParameterReferenceType.DataSlot:
					{
						ClassTypeReferenceProperty referenceTypeProperty = new ClassTypeReferenceProperty(serializedObject.FindProperty("_ReferenceType"));
						referenceType = referenceTypeProperty.type;
					}
					break;
			}

			return referenceType;
		}

		void DeleteOldBranch(Parameter.Type parameterType)
		{
			SerializedProperty valueProperty = null;
			switch (parameterType)
			{
				case Parameter.Type.Int:
					{
						valueProperty = serializedObject.FindProperty("_IntValue");
					}
					break;
				case Parameter.Type.Float:
					{
						valueProperty = serializedObject.FindProperty("_FloatValue");
					}
					break;
				case Parameter.Type.Bool:
					{
						valueProperty = serializedObject.FindProperty("_BoolValue");
					}
					break;
				case Parameter.Type.String:
					{
						valueProperty = serializedObject.FindProperty("_StringValue");
					}
					break;
				case Parameter.Type.GameObject:
					{
						valueProperty = serializedObject.FindProperty("_GameObjectValue");
					}
					break;
				case Parameter.Type.Vector2:
					{
						valueProperty = serializedObject.FindProperty("_Vector2Value");
					}
					break;
				case Parameter.Type.Vector3:
					{
						valueProperty = serializedObject.FindProperty("_Vector3Value");
					}
					break;
				case Parameter.Type.Quaternion:
					{
						valueProperty = serializedObject.FindProperty("_QuaternionValue");
					}
					break;
				case Parameter.Type.Rect:
					{
						valueProperty = serializedObject.FindProperty("_RectValue");
					}
					break;
				case Parameter.Type.Bounds:
					{
						valueProperty = serializedObject.FindProperty("_BoundsValue");
					}
					break;
				case Parameter.Type.Color:
					{
						valueProperty = serializedObject.FindProperty("_ColorValue");
					}
					break;
				case Parameter.Type.Transform:
					{
						valueProperty = serializedObject.FindProperty("_TransformValue");
					}
					break;
				case Parameter.Type.RectTransform:
					{
						valueProperty = serializedObject.FindProperty("_RectTransformValue");
					}
					break;
				case Parameter.Type.Rigidbody:
					{
						valueProperty = serializedObject.FindProperty("_RigidbodyValue");
					}
					break;
				case Parameter.Type.Rigidbody2D:
					{
						valueProperty = serializedObject.FindProperty("_Rigidbody2DValue");
					}
					break;
				case Parameter.Type.Component:
					{
						valueProperty = serializedObject.FindProperty("_ComponentValue");
					}
					break;
				case Parameter.Type.Long:
					{
						valueProperty = serializedObject.FindProperty("_LongValue");
					}
					break;
			}

			if (valueProperty != null)
			{
				foreach (object valueObj in EditorGUITools.GetPropertyObjects(valueProperty))
				{
					EachField<DataSlot>.Find(valueObj, valueObj.GetType(), (s) =>
					{
						s.Disconnect();
					});
				}
			}
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			ParameterReferenceProperty referenceProperty = GetParameterReference();

			SerializedProperty parameterTypeProperty = serializedObject.FindProperty("_ParameterType");

			ClassTypeReferenceProperty referenceTypeProperty = new ClassTypeReferenceProperty(serializedObject.FindProperty("_ReferenceType"));

			Parameter.Type oldParameterType = GetParameterType();
			
			EditorGUI.BeginChangeCheck();
			EditorGUILayout.PropertyField(referenceProperty.property);
			if (EditorGUI.EndChangeCheck())
			{
				Parameter.Type newParameterType = GetParameterType();
				if (newParameterType != oldParameterType)
				{
					DeleteOldBranch(oldParameterType);
				}
				oldParameterType = newParameterType;
			}

			ParameterReferenceType parameterReferenceType = referenceProperty.type;
			if (parameterReferenceType == ParameterReferenceType.DataSlot)
			{
				EditorGUI.BeginChangeCheck();
				EditorGUILayout.PropertyField(parameterTypeProperty);
				if (EditorGUI.EndChangeCheck())
				{
					Parameter.Type newParameterType = GetParameterType();
					if (newParameterType != oldParameterType)
					{
						DeleteOldBranch(oldParameterType);

						referenceTypeProperty.type = null;
					}
					oldParameterType = newParameterType;
				}

				switch (oldParameterType)
				{
					case Parameter.Type.Component:
						{
							System.Type oldReferenceType = referenceTypeProperty.type;

							referenceTypeProperty.property.SetStateData<ClassTypeConstraintAttribute>(ClassTypeConstraintEditorUtility.component);

							EditorGUI.BeginChangeCheck();
							EditorGUILayout.PropertyField(referenceTypeProperty.property);
							if (EditorGUI.EndChangeCheck())
							{
								System.Type referenceType = referenceTypeProperty.type;
								if (referenceType != oldReferenceType)
								{
									DeleteOldBranch(oldParameterType);
								}
								oldReferenceType = referenceType;
							}
						}
						break;
					case Parameter.Type.Enum:
						{
							System.Type oldReferenceType = referenceTypeProperty.type;

							referenceTypeProperty.property.SetStateData<ClassTypeConstraintAttribute>(ClassTypeConstraintEditorUtility.enumField);

							EditorGUI.BeginChangeCheck();
							EditorGUILayout.PropertyField(referenceTypeProperty.property);
							if (EditorGUI.EndChangeCheck())
							{
								System.Type referenceType = referenceTypeProperty.type;
								if (referenceType != oldReferenceType)
								{
									DeleteOldBranch(oldParameterType);
								}
								oldReferenceType = referenceType;
							}
						}
						break;
				}
			}

			Parameter.Type parameterType = GetParameterType();

			SerializedProperty functionProperty = serializedObject.FindProperty("function");

			switch (parameterType)
			{
				case Parameter.Type.Int:
					{
						EditorGUILayout.PropertyField(functionProperty);

						EditorGUILayout.PropertyField(serializedObject.FindProperty("_IntValue"));
					}
					break;
				case Parameter.Type.Long:
					{
						EditorGUILayout.PropertyField(functionProperty);

						EditorGUILayout.PropertyField(serializedObject.FindProperty("_LongValue"));
					}
					break;
				case Parameter.Type.Float:
					{
						EditorGUILayout.PropertyField(functionProperty);

						EditorGUILayout.PropertyField(serializedObject.FindProperty("_FloatValue"));
					}
					break;
				case Parameter.Type.Bool:
					{
						EditorGUILayout.PropertyField(serializedObject.FindProperty("_BoolValue"));
					}
					break;
				case Parameter.Type.String:
					{
						EditorGUILayout.PropertyField(functionProperty);

						EditorGUILayout.PropertyField(serializedObject.FindProperty("_StringValue"));
					}
					break;
				case Parameter.Type.Enum:
					{
						SerializedProperty enumValueProperty = serializedObject.FindProperty("_EnumValue");
						enumValueProperty.SetStateData(GetReferenceType());

						EditorGUILayout.PropertyField(enumValueProperty);
					}
					break;
				case Parameter.Type.GameObject:
					{
						EditorGUILayout.PropertyField(serializedObject.FindProperty("_GameObjectValue"));
					}
					break;
				case Parameter.Type.Vector2:
					{
						EditorGUILayout.PropertyField(serializedObject.FindProperty("_Vector2Value"));
					}
					break;
				case Parameter.Type.Vector3:
					{
						EditorGUILayout.PropertyField(serializedObject.FindProperty("_Vector3Value"));
					}
					break;
				case Parameter.Type.Quaternion:
					{
						EditorGUILayout.PropertyField(serializedObject.FindProperty("_QuaternionValue"));
					}
					break;
				case Parameter.Type.Rect:
					{
						EditorGUILayout.PropertyField(serializedObject.FindProperty("_RectValue"));
					}
					break;
				case Parameter.Type.Bounds:
					{
						EditorGUILayout.PropertyField(serializedObject.FindProperty("_BoundsValue"));
					}
					break;
				case Parameter.Type.Color:
					{
						EditorGUILayout.PropertyField(serializedObject.FindProperty("_ColorValue"));
					}
					break;
				case Parameter.Type.Transform:
					{
						EditorGUILayout.PropertyField(serializedObject.FindProperty("_TransformValue"));
					}
					break;
				case Parameter.Type.RectTransform:
					{
						EditorGUILayout.PropertyField(serializedObject.FindProperty("_RectTransformValue"));
					}
					break;
				case Parameter.Type.Rigidbody:
					{
						EditorGUILayout.PropertyField(serializedObject.FindProperty("_RigidbodyValue"));
					}
					break;
				case Parameter.Type.Rigidbody2D:
					{
						EditorGUILayout.PropertyField(serializedObject.FindProperty("_Rigidbody2DValue"));
					}
					break;
				case Parameter.Type.Component:
					{
						SerializedProperty componentValueProperty = serializedObject.FindProperty("_ComponentValue");
						componentValueProperty.SetStateData(GetReferenceType());
						
						EditorGUILayout.PropertyField(componentValueProperty);
					}
					break;
				case Parameter.Type.Variable:
					{
						Parameter parameter = referenceProperty.GetParameter();
						string valueTypeName = (parameter != null && parameter.valueType != null) ? parameter.valueType.ToString() : "Variable";
						string message = string.Format(Localization.GetWord("CalcParameter.NotSupportVariable"), valueTypeName);
						EditorGUILayout.HelpBox(message, MessageType.Warning);
					}
					break;
			}

			serializedObject.ApplyModifiedProperties();
		}
	}
}

