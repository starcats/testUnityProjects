﻿using UnityEngine;
using System.Collections.Generic;

namespace Arbor
{
	[System.Serializable]
	public class GraphArgumentList
	{
		[SerializeField]
		internal List<GraphArgument> _Arguments = new List<GraphArgument>();

		[SerializeField]
		internal List<FlexibleInt> _IntParameters = new List<FlexibleInt>();

		[SerializeField]
		internal List<FlexibleLong> _LongParameters = new List<FlexibleLong>();

		[SerializeField]
		internal List<FlexibleFloat> _FloatParameters = new List<FlexibleFloat>();

		[SerializeField]
		internal List<FlexibleBool> _BoolParameters = new List<FlexibleBool>();

		[SerializeField]
		internal List<FlexibleEnumAny> _EnumParameters = new List<FlexibleEnumAny>();

		[SerializeField]
		internal List<FlexibleString> _StringParameters = new List<FlexibleString>();

		[SerializeField]
		internal List<FlexibleVector2> _Vector2Parameters = new List<FlexibleVector2>();

		[SerializeField]
		internal List<FlexibleVector3> _Vector3Parameters = new List<FlexibleVector3>();

		[SerializeField]
		internal List<FlexibleQuaternion> _QuaternionParameters = new List<FlexibleQuaternion>();

		[SerializeField]
		internal List<FlexibleRect> _RectParameters = new List<FlexibleRect>();

		[SerializeField]
		internal List<FlexibleBounds> _BoundsParameters = new List<FlexibleBounds>();

		[SerializeField]
		internal List<FlexibleColor> _ColorParameters = new List<FlexibleColor>();

		[SerializeField]
		internal List<FlexibleGameObject> _GameObjectParameters = new List<FlexibleGameObject>();

		[SerializeField]
		internal List<FlexibleComponent> _ComponentParameters = new List<FlexibleComponent>();

		[SerializeField]
		[HideSlotFields]
		internal List<InputSlotTypable> _InputSlots = new List<InputSlotTypable>();

		[SerializeField]
		[HideSlotFields]
		internal List<OutputSlotTypable> _OutputSlots = new List<OutputSlotTypable>();

		string GetInvalidText(GraphArgument argument, Parameter parameter)
		{
			if (parameter == null)
			{
				return "Not found parameter : \"" + argument.parameterName + "\"";
			}

			if (parameter.type != argument.parameterType)
			{
				return "The parameter type has been changed : \"" + argument.parameterName + "\"";
			}

			if ((parameter.type == Parameter.Type.Component || parameter.type == Parameter.Type.Enum) && parameter.referenceType != argument.type)
			{
				return "The reference type of the parameter has been changed : \"" + argument.parameterName + "\"";
			}

			if (parameter.type == Parameter.Type.Variable)
			{
				InputSlotTypable inputSlot = argument.isPublicSet ? _InputSlots[argument.parameterIndex] : null;
				OutputSlotTypable outputSlot = argument.isPublicGet ? _OutputSlots[argument.outputSlotIndex] : null;
				if (inputSlot != null && parameter.valueType != inputSlot.dataType ||
					outputSlot != null && parameter.valueType != outputSlot.dataType)
				{
					return "The type of Variable has been changed : \"" + argument.parameterName + "\"";
				}
			}

			return null;
		}

		public void UpdateInput(NodeGraph nodeGraph,GraphArgumentUpdateTiming updateTiming)
		{
			ParameterContainerInternal parameterContainer = nodeGraph.parameterContainer;
			if (parameterContainer == null)
			{
				return;
			}

			for (int i = 0, count = _Arguments.Count; i < count; ++i)
			{
				GraphArgument argument = _Arguments[i];

				if ((argument.updateTiming & updateTiming) == 0 ||
					!argument.isPublicSet )
				{
					continue;
				}

				Parameter parameter = argument.parameterID != 0? parameterContainer.GetParam(argument.parameterID) : parameterContainer.GetParam(argument.parameterName);

				string invalidText = GetInvalidText(argument, parameter);
				if (!string.IsNullOrEmpty(invalidText))
				{
					Debug.LogWarning(invalidText, nodeGraph);
					continue;
				}

				if (!parameter.isPublicSet)
				{
					Debug.LogWarning("Set of parameter is not public. : \"" + parameter.name + "\"", nodeGraph);
					continue;
				}

				switch (parameter.type)
				{
					case Parameter.Type.Int:
						{
							FlexibleInt intParameter = _IntParameters[argument.parameterIndex];
							parameter.intValue = intParameter.value;
						}
						break;
					case Parameter.Type.Long:
						{
							FlexibleLong longParameter = _LongParameters[argument.parameterIndex];
							parameter.longValue = longParameter.value;
						}
						break;
					case Parameter.Type.Float:
						{
							FlexibleFloat floatParameter = _FloatParameters[argument.parameterIndex];
							parameter.floatValue = floatParameter.value;
						}
						break;
					case Parameter.Type.Bool:
						{
							FlexibleBool boolParameter = _BoolParameters[argument.parameterIndex];
							parameter.boolValue = boolParameter.value;
						}
						break;
					case Parameter.Type.String:
						{
							FlexibleString stringParameter = _StringParameters[argument.parameterIndex];
							parameter.stringValue = stringParameter.value;
						}
						break;
					case Parameter.Type.Enum:
						{
							FlexibleEnumAny enumParameter = _EnumParameters[argument.parameterIndex];
							parameter.intValue = enumParameter.value;
						}
						break;
					case Parameter.Type.GameObject:
						{
							FlexibleGameObject gameObjectParameter = _GameObjectParameters[argument.parameterIndex];
							parameter.gameObjectValue = gameObjectParameter.value;
						}
						break;
					case Parameter.Type.Vector2:
						{
							FlexibleVector2 vector2Parameter = _Vector2Parameters[argument.parameterIndex];
							parameter.vector2Value = vector2Parameter.value;
						}
						break;
					case Parameter.Type.Vector3:
						{
							FlexibleVector3 vector3Parameter = _Vector3Parameters[argument.parameterIndex];
							parameter.vector3Value = vector3Parameter.value;
						}
						break;
					case Parameter.Type.Quaternion:
						{
							FlexibleQuaternion quaternionParameter = _QuaternionParameters[argument.parameterIndex];
							parameter.quaternionValue = quaternionParameter.value;
						}
						break;
					case Parameter.Type.Rect:
						{
							FlexibleRect rectParameter = _RectParameters[argument.parameterIndex];
							parameter.rectValue = rectParameter.value;
						}
						break;
					case Parameter.Type.Bounds:
						{
							FlexibleBounds boundsParameter = _BoundsParameters[argument.parameterIndex];
							parameter.boundsValue = boundsParameter.value;
						}
						break;
					case Parameter.Type.Color:
						{
							FlexibleColor colorParameter = _ColorParameters[argument.parameterIndex];
							parameter.colorValue = colorParameter.value;
						}
						break;
					case Parameter.Type.Transform:
					case Parameter.Type.RectTransform:
					case Parameter.Type.Rigidbody:
					case Parameter.Type.Rigidbody2D:
					case Parameter.Type.Component:
						{
							FlexibleComponent componentParameter = _ComponentParameters[argument.parameterIndex];
							parameter.objectReferenceValue = componentParameter.value;
						}
						break;
					case Parameter.Type.Variable:
						{
							InputSlotTypable inputSlot = _InputSlots[argument.parameterIndex];
							object value = null;
							if (inputSlot.GetValue(ref value))
							{
								parameter.variableValue = value;
							}
						}
						break;
				}
			}
		}

		public void UpdateOutput(NodeGraph nodeGraph)
		{
			ParameterContainerInternal parameterContainer = nodeGraph.parameterContainer;
			if (parameterContainer == null)
			{
				return;
			}

			for (int i = 0, count = _Arguments.Count; i < count; ++i)
			{
				GraphArgument argument = _Arguments[i];

				if (!argument.isPublicGet)
				{
					continue;
				}

				Parameter parameter = argument.parameterID != 0? parameterContainer.GetParam(argument.parameterID) : parameterContainer.GetParam(argument.parameterName);

				string invalidText = GetInvalidText(argument, parameter);
				if (!string.IsNullOrEmpty(invalidText))
				{
					Debug.LogWarning(invalidText, nodeGraph);
					continue;
				}

				if (!parameter.isPublicGet)
				{
					Debug.LogWarning("Get of parameter is not public. : \"" + parameter.name + "\"", nodeGraph);
					continue;
				}

				OutputSlotTypable outputSlot = _OutputSlots[argument.outputSlotIndex];

				if (outputSlot.dataType != parameter.valueType)
				{
					Debug.LogWarning("The type of the parameter has been changed : \"" + argument.parameterName + "\"");
					continue;
				}

				outputSlot.SetValue(parameter.value);
			}
		}
	}
}