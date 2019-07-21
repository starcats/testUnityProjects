﻿using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// パラメータの状態チェッククラス
	/// </summary>
#else
	/// <summary>
	/// Condition check class of Parameter
	/// </summary>
#endif
	[System.Serializable]
	[Arbor.Internal.Documentable]
	public class ParameterCondition
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// パラメータの参照
		/// </summary>
#else
		/// <summary>
		/// Parameter reference
		/// </summary>
#endif
		[SerializeField]
		internal ParameterReference _Reference = new ParameterReference();

#if ARBOR_DOC_JA
		/// <summary>
		/// 参照するパラメータのタイプ。reference.typeがParameterReferenceType.Constant以外の時に使用する。
		/// </summary>
#else
		/// <summary>
		/// Parameters to be referenced. Used when reference.type is other than ParameterReferenceType.Constant.
		/// </summary>
#endif
		[SerializeField]
		internal Parameter.Type _ParameterType = Parameter.Type.Int;

#if ARBOR_DOC_JA
		/// <summary>
		/// 参照するパラメータの型。reference.typeがParameterReferenceType.Constant以外の時に使用する。
		/// </summary>
#else
		/// <summary>
		/// Parameters to be referenced type. Used when reference.type is other than ParameterReferenceType.Constant.
		/// </summary>
#endif
		[SerializeField]
		internal ClassTypeReference _ReferenceType = new ClassTypeReference();

#if ARBOR_DOC_JA
		/// <summary>
		/// 比較タイプ
		/// </summary>
#else
		/// <summary>
		/// Compare type
		/// </summary>
#endif
		[SerializeField]
		internal CompareType _CompareType = CompareType.Equals;

		[SerializeField]
		internal int _ParameterIndex = 0;

		#endregion // Serialize fields

		[System.NonSerialized]
		private ParameterConditionList _Owner = null;

		public ParameterConditionList owner
		{
			get
			{
				return _Owner;
			}
			internal set
			{
				_Owner = value;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// パラメータへの参照。
		/// </summary>
#else
		/// <summary>
		/// Reference to parameter.
		/// </summary>
#endif
		public ParameterReference reference
		{
			get
			{
				return _Reference;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 参照するパラメータのタイプ。reference.typeがParameterReferenceType.Constant以外の時に使用する。
		/// </summary>
#else
		/// <summary>
		/// Parameters to be referenced. Used when reference.type is other than ParameterReferenceType.Constant.
		/// </summary>
#endif
		public Parameter.Type parameterType
		{
			get
			{
				return _ParameterType;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 参照するパラメータの型。reference.typeがParameterReferenceType.Constant以外の時に使用する。
		/// </summary>
#else
		/// <summary>
		/// Parameters to be referenced type. Used when reference.type is other than ParameterReferenceType.Constant.
		/// </summary>
#endif
		public System.Type referenceType
		{
			get
			{
				return _ReferenceType;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 比較タイプ
		/// </summary>
#else
		/// <summary>
		/// Compare type
		/// </summary>
#endif
		public CompareType compareType
		{
			get
			{
				return _CompareType;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 比較対象のint値
		/// </summary>
#else
		/// <summary>
		/// The int value to be compared
		/// </summary>
#endif
		public int intValue
		{
			get
			{
				FlexibleInt intParameter = owner._IntParameters[_ParameterIndex];
				return intParameter.value;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 比較対象のlong値
		/// </summary>
#else
		/// <summary>
		/// The long value to be compared
		/// </summary>
#endif
		public long longValue
		{
			get
			{
				FlexibleLong longParameter = owner._LongParameters[_ParameterIndex];
				return longParameter.value;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 比較対象のfloat値
		/// </summary>
#else
		/// <summary>
		/// The float value to be compared
		/// </summary>
#endif
		public float floatValue
		{
			get
			{
				FlexibleFloat floatParameter = owner._FloatParameters[_ParameterIndex];
				return floatParameter.value;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 比較対象のbool値
		/// </summary>
#else
		/// <summary>
		/// The bool value to be compared
		/// </summary>
#endif
		public bool boolValue
		{
			get
			{
				FlexibleBool boolParameter = owner._BoolParameters[_ParameterIndex];
				return boolParameter.value;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 比較対象のstring値
		/// </summary>
#else
		/// <summary>
		/// The string value to be compared
		/// </summary>
#endif
		public string stringValue
		{
			get
			{
				FlexibleString stringParameter = owner._StringParameters[_ParameterIndex];
				return stringParameter.value;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 比較対象のEnum値
		/// </summary>
#else
		/// <summary>
		/// The enum value to be compared
		/// </summary>
#endif
		public int enumValue
		{
			get
			{
				FlexibleEnumAny enumParameter = owner._EnumParameters[_ParameterIndex];
				return enumParameter.value;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 比較対象のGameObject値
		/// </summary>
#else
		/// <summary>
		/// The GameObject value to be compared
		/// </summary>
#endif
		public GameObject gameObjectValue
		{
			get
			{
				FlexibleGameObject gameObjectParameter = owner._GameObjectParameters[_ParameterIndex];
				return gameObjectParameter.value;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 比較対象のVector2値
		/// </summary>
#else
		/// <summary>
		/// The Vector2 value to be compared
		/// </summary>
#endif
		public Vector2 vector2Value
		{
			get
			{
				FlexibleVector2 vector2Parameter = owner._Vector2Parameters[_ParameterIndex];
				return vector2Parameter.value;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 比較対象のVector3値
		/// </summary>
#else
		/// <summary>
		/// The Vector3 value to be compared
		/// </summary>
#endif
		public Vector3 vector3Value
		{
			get
			{
				FlexibleVector3 vector3Parameter = owner._Vector3Parameters[_ParameterIndex];
				return vector3Parameter.value;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 比較対象のQuaternion値
		/// </summary>
#else
		/// <summary>
		/// The Quaternion value to be compared
		/// </summary>
#endif
		public Quaternion quaternionValue
		{
			get
			{
				FlexibleQuaternion quaternionParameter = owner._QuaternionParameters[_ParameterIndex];
				return quaternionParameter.value;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 比較対象のRect値
		/// </summary>
#else
		/// <summary>
		/// The Rect value to be compared
		/// </summary>
#endif
		public Rect rectValue
		{
			get
			{
				FlexibleRect rectParameter = owner._RectParameters[_ParameterIndex];
				return rectParameter.value;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 比較対象のBounds値
		/// </summary>
#else
		/// <summary>
		/// The Bounds value to be compared
		/// </summary>
#endif
		public Bounds boundsValue
		{
			get
			{
				FlexibleBounds boundsParameter = owner._BoundsParameters[_ParameterIndex];
				return boundsParameter.value;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 比較対象のColor値
		/// </summary>
#else
		/// <summary>
		/// The Color value to be compared
		/// </summary>
#endif
		public Color colorValue
		{
			get
			{
				FlexibleColor colorParameter = owner._ColorParameters[_ParameterIndex];
				return colorParameter.value;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 比較対象のTransform値
		/// </summary>
#else
		/// <summary>
		/// The Transform value to be compared
		/// </summary>
#endif
		public Transform transformValue
		{
			get
			{
				return componentValue as Transform;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 比較対象のRectTransform値
		/// </summary>
#else
		/// <summary>
		/// The RectTransform value to be compared
		/// </summary>
#endif
		public RectTransform rectTransformValue
		{
			get
			{
				return componentValue as RectTransform;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 比較対象のRigidbody値
		/// </summary>
#else
		/// <summary>
		/// The Rigidbody value to be compared
		/// </summary>
#endif
		public Rigidbody rigidbodyValue
		{
			get
			{
				return componentValue as Rigidbody;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 比較対象のRigidbody2D値
		/// </summary>
#else
		/// <summary>
		/// The Rigidbody2D value to be compared
		/// </summary>
#endif
		public Rigidbody2D rigidbody2DValue
		{
			get
			{
				return componentValue as Rigidbody2D;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 比較対象のComponent値
		/// </summary>
#else
		/// <summary>
		/// The Component value to be compared
		/// </summary>
#endif
		public Component componentValue
		{
			get
			{
				FlexibleComponent componentParameter = owner._ComponentParameters[_ParameterIndex];
				return componentParameter.value;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 条件チェック
		/// </summary>
		/// <returns>条件が一致する場合はtrueを返す。</returns>
#else
		/// <summary>
		/// Condition check
		/// </summary>
		/// <returns>Returns true if the conditions match.</returns>
#endif
		public bool CheckCondition()
		{
			Parameter parameter = _Reference.parameter;
			if (parameter == null)
			{
				return true;
			}

			switch (parameter.type)
			{
				case Parameter.Type.Int:
					{
						int intValue = this.intValue;
						switch (_CompareType)
						{
							case CompareType.Greater:
								if ( parameter.intValue > intValue )
								{
									return true;
								}
								break;
							case CompareType.GreaterOrEquals:
								if (parameter.intValue >= intValue)
								{
									return true;
								}
								break;
							case CompareType.Less:
								if ( parameter.intValue < intValue )
								{
									return true;
								}
								break;
							case CompareType.LessOrEquals:
								if (parameter.intValue <= intValue)
								{
									return true;
								}
								break;
							case CompareType.Equals:
								if ( parameter.intValue == intValue )
								{
									return true;
								}
								break;
							case CompareType.NotEquals:
								if ( parameter.intValue != intValue )
								{
									return true;
								}
								break;
						}
					}
					break;
				case Parameter.Type.Long:
					{
						long longValue = this.longValue;
						switch (_CompareType)
						{
							case CompareType.Greater:
								if (parameter.longValue > longValue)
								{
									return true;
								}
								break;
							case CompareType.GreaterOrEquals:
								if (parameter.longValue >= longValue)
								{
									return true;
								}
								break;
							case CompareType.Less:
								if (parameter.longValue < longValue)
								{
									return true;
								}
								break;
							case CompareType.LessOrEquals:
								if (parameter.longValue <= longValue)
								{
									return true;
								}
								break;
							case CompareType.Equals:
								if (parameter.longValue == longValue)
								{
									return true;
								}
								break;
							case CompareType.NotEquals:
								if (parameter.longValue != longValue)
								{
									return true;
								}
								break;
						}
					}
					break;
				case Parameter.Type.Float:
					{
						float floatValue = this.floatValue;
						switch (_CompareType)
						{
							case CompareType.Greater:
								if ( parameter.floatValue > floatValue )
								{
									return true;
								}
								break;
							case CompareType.GreaterOrEquals:
								if (parameter.floatValue >= floatValue)
								{
									return true;
								}
								break;
							case CompareType.Less:
								if ( parameter.floatValue < floatValue )
								{
									return true;
								}
								break;
							case CompareType.LessOrEquals:
								if (parameter.floatValue <= floatValue)
								{
									return true;
								}
								break;
							case CompareType.Equals:
								if ( parameter.floatValue == floatValue )
								{
									return true;
								}
								break;
							case CompareType.NotEquals:
								if ( parameter.floatValue != floatValue )
								{
									return true;
								}
								break;
						}
					}
					break;
				case Parameter.Type.Bool:
					{
						bool boolValue = this.boolValue;
						if ( parameter.boolValue == boolValue )
						{
							return true;
						}
					}
					break;
				case Parameter.Type.String:
					{
						string stringValue = this.stringValue;
						switch (_CompareType)
						{
							case CompareType.Greater:
								if (parameter.stringValue.CompareTo(stringValue) > 0 )
								{
									return true;
								}
								break;
							case CompareType.GreaterOrEquals:
								if (parameter.stringValue.CompareTo(stringValue) >= 0)
								{
									return true;
								}
								break;
							case CompareType.Less:
								if (parameter.stringValue.CompareTo(stringValue) < 0 )
								{
									return true;
								}
								break;
							case CompareType.LessOrEquals:
								if (parameter.stringValue.CompareTo(stringValue) <= 0)
								{
									return true;
								}
								break;
							case CompareType.Equals:
								if (parameter.stringValue.Equals(stringValue) )
								{
									return true;
								}
								break;
							case CompareType.NotEquals:
								if (!parameter.stringValue.Equals(stringValue))
								{
									return true;
								}
								break;
						}
					}
					break;
				case Parameter.Type.Enum:
					{
						int enumValue = this.enumValue;
						if (parameter.intValue == enumValue)
						{
							return true;
						}
					}
					break;
				case Parameter.Type.GameObject:
					{
						GameObject gameObjectValue = this.gameObjectValue;
						if (parameter.gameObjectValue == gameObjectValue)
						{
							return true;
						}
					}
					break;
				case Parameter.Type.Vector2:
					{
						Vector2 vector2Value = this.vector2Value;
						if (parameter.vector2Value == vector2Value)
						{
							return true;
						}
					}
					break;
				case Parameter.Type.Vector3:
					{
						Vector3 vector3Value = this.vector3Value;
						if (parameter.vector3Value == vector3Value)
						{
							return true;
						}
					}
					break;
				case Parameter.Type.Quaternion:
					{
						Quaternion quaternionValue = this.quaternionValue;
						if (parameter.quaternionValue == quaternionValue)
						{
							return true;
						}
					}
					break;
				case Parameter.Type.Rect:
					{
						Rect rectValue = this.rectValue;
						if (parameter.rectValue == rectValue)
						{
							return true;
						}
					}
					break;
				case Parameter.Type.Bounds:
					{
						Bounds boundsValue = this.boundsValue;
						if (parameter.boundsValue == boundsValue)
						{
							return true;
						}
					}
					break;
				case Parameter.Type.Color:
					{
						Color colorValue = this.colorValue;
						if (parameter.colorValue == colorValue)
						{
							return true;
						}
					}
					break;
				case Parameter.Type.Transform:
				case Parameter.Type.RectTransform:
				case Parameter.Type.Rigidbody:
				case Parameter.Type.Rigidbody2D:
				case Parameter.Type.Component:
					{
						Component componentValue = this.componentValue;
						if (parameter.objectReferenceValue == componentValue)
						{
							return true;
						}
					}
					break;
			}

			return false;
		}
	}
}