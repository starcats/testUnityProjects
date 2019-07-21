﻿using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Parameterの値を演算して変更する。
	/// </summary>
#else
	/// <summary>
	/// Change by calculating the value of the Parameter.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Parameter/CalcParameter")]
	[BuiltInBehaviour]
	public sealed class CalcParameter : StateBehaviour, INodeBehaviourSerializationCallbackReceiver
	{
		#region enum

		[Internal.Documentable]
		public enum Function
		{
#if ARBOR_DOC_JA
			/// <summary>
			/// 値を代入する。
			/// </summary>
#else
			/// <summary>
			/// Substitute values.
			/// </summary>
#endif
			Assign,

#if ARBOR_DOC_JA
			/// <summary>
			/// 値を加算する。<br/>
			/// 減算したい場合は負値を指定する。
			/// </summary>
#else
			/// <summary>
			/// Add values.<br/>
			/// To subtract it, specify a negative value.
			/// </summary>
#endif
			Add,
		}

#endregion // enum

#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 参照するパラメータ。
		/// </summary>
#else
		/// <summary>
		/// Parameters to be referenced.
		/// </summary>
#endif
		public ParameterReference reference = new ParameterReference();

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
		private Parameter.Type _ParameterType = Parameter.Type.Int;

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
		private ClassTypeReference _ReferenceType = new ClassTypeReference();

#if ARBOR_DOC_JA
		/// <summary>
		/// 演算するタイプ(Int、Float、Stringのみ)。
		/// </summary>
#else
		/// <summary>
		/// Type to calculate (Int, Float, String only).
		/// </summary>
#endif
		public Function function;

#if ARBOR_DOC_JA
		/// <summary>
		/// 演算するInt値
		/// </summary>
#else
		/// <summary>
		/// Int value to be computed
		/// </summary>
#endif
		[SerializeField]
		private FlexibleInt _IntValue = new FlexibleInt();

#if ARBOR_DOC_JA
		/// <summary>
		/// 演算するLong値
		/// </summary>
#else
		/// <summary>
		/// Long value to be computed
		/// </summary>
#endif
		[SerializeField]
		private FlexibleLong _LongValue = new FlexibleLong();

#if ARBOR_DOC_JA
		/// <summary>
		/// 演算するFloat値
		/// </summary>
#else
		/// <summary>
		/// Float value to be computed
		/// </summary>
#endif
		[SerializeField]
		private FlexibleFloat _FloatValue = new FlexibleFloat();

#if ARBOR_DOC_JA
		/// <summary>
		/// 演算するBool値
		/// </summary>
#else
		/// <summary>
		/// Bool value to be computed
		/// </summary>
#endif
		[SerializeField]
		private FlexibleBool _BoolValue = new FlexibleBool();

#if ARBOR_DOC_JA
		/// <summary>
		/// 演算するString値
		/// </summary>
#else
		/// <summary>
		/// String value to be computed
		/// </summary>
#endif
		[SerializeField]
		private FlexibleString _StringValue = new FlexibleString();

#if ARBOR_DOC_JA
		/// <summary>
		/// 演算するEnum値
		/// </summary>
#else
		/// <summary>
		/// Enum value to be computed
		/// </summary>
#endif
		[SerializeField]
		private FlexibleEnumAny _EnumValue = new FlexibleEnumAny();

#if ARBOR_DOC_JA
		/// <summary>
		/// 演算するGameObject値
		/// </summary>
#else
		/// <summary>
		/// GameObject value to be computed
		/// </summary>
#endif
		[SerializeField]
		private FlexibleGameObject _GameObjectValue = new FlexibleGameObject();

#if ARBOR_DOC_JA
		/// <summary>
		/// 演算するVector2値
		/// </summary>
#else
		/// <summary>
		/// Vector2 value to be computed
		/// </summary>
#endif
		[SerializeField]
		private FlexibleVector2 _Vector2Value = new FlexibleVector2();

#if ARBOR_DOC_JA
		/// <summary>
		/// 演算するVector3値
		/// </summary>
#else
		/// <summary>
		/// Vector3 value to be computed
		/// </summary>
#endif
		[SerializeField]
		private FlexibleVector3 _Vector3Value = new FlexibleVector3();

#if ARBOR_DOC_JA
		/// <summary>
		/// 演算するQuaternion値
		/// </summary>
#else
		/// <summary>
		/// Quaternion value to be computed
		/// </summary>
#endif
		[SerializeField]
		private FlexibleQuaternion _QuaternionValue = new FlexibleQuaternion();

#if ARBOR_DOC_JA
		/// <summary>
		/// 演算するRect値
		/// </summary>
#else
		/// <summary>
		/// Rect value to be computed
		/// </summary>
#endif
		[SerializeField]
		private FlexibleRect _RectValue = new FlexibleRect();

#if ARBOR_DOC_JA
		/// <summary>
		/// 演算するBounds値
		/// </summary>
#else
		/// <summary>
		/// Bounds value to be computed
		/// </summary>
#endif
		[SerializeField]
		private FlexibleBounds _BoundsValue = new FlexibleBounds();

#if ARBOR_DOC_JA
		/// <summary>
		/// 演算するColor値
		/// </summary>
#else
		/// <summary>
		/// Color value to be computed
		/// </summary>
#endif
		[SerializeField]
		private FlexibleColor _ColorValue = new FlexibleColor();

#if ARBOR_DOC_JA
		/// <summary>
		/// 演算するTransform値
		/// </summary>
#else
		/// <summary>
		/// Transform value to be computed
		/// </summary>
#endif
		[SerializeField]
		private FlexibleTransform _TransformValue = new FlexibleTransform();

#if ARBOR_DOC_JA
		/// <summary>
		/// 演算するRectTransform値
		/// </summary>
#else
		/// <summary>
		/// RectTransform value to be computed
		/// </summary>
#endif
		[SerializeField]
		private FlexibleRectTransform _RectTransformValue = new FlexibleRectTransform();

#if ARBOR_DOC_JA
		/// <summary>
		/// 演算するRigidbody値
		/// </summary>
#else
		/// <summary>
		/// Rigidbody value to be computed
		/// </summary>
#endif
		[SerializeField]
		private FlexibleRigidbody _RigidbodyValue = new FlexibleRigidbody();

#if ARBOR_DOC_JA
		/// <summary>
		/// 演算するRigidbody2D値
		/// </summary>
#else
		/// <summary>
		/// Rigidbody2D value to be computed
		/// </summary>
#endif
		[SerializeField]
		private FlexibleRigidbody2D _Rigidbody2DValue = new FlexibleRigidbody2D();

#if ARBOR_DOC_JA
		/// <summary>
		/// 演算するComponent値
		/// </summary>
#else
		/// <summary>
		/// Component value to be computed
		/// </summary>
#endif
		[SerializeField]
		private FlexibleComponent _ComponentValue = new FlexibleComponent();

		[SerializeField]
		[HideInInspector]
		private int _SerializeVersion = 0;

#region old

		[FormerlySerializedAs( "intValue" )]
		[SerializeField]
		[HideInInspector]
		private int _OldIntValue = 0;

		[FormerlySerializedAs( "floatValue" )]
		[SerializeField]
		[HideInInspector]
		private float _OldFloatValue = 0f;

		[FormerlySerializedAs( "boolValue" )]
		[SerializeField]
		[HideInInspector]
		private bool _OldBoolValue = false;

#endregion // old

#endregion // Serialize fields

		public Parameter.Type parameterType
		{
			get
			{
				return _ParameterType;
			}
		}

		public System.Type referenceType
		{
			get
			{
				return _ReferenceType;
			}
		}

		public int intValue
		{
			get
			{
				return _IntValue.value;
			}
		}

		public long longValue
		{
			get
			{
				return _LongValue.value;
			}
		}

		public float floatValue
		{
			get
			{
				return _FloatValue.value;
			}
		}

		public bool boolValue
		{
			get
			{
				return _BoolValue.value;
			}
		}

		public string stringValue
		{
			get
			{
				return _StringValue.value;
			}
		}

		public int enumValue
		{
			get
			{
				return _EnumValue.value;
			}
		}

		public GameObject gameObjectValue
		{
			get
			{
				return _GameObjectValue.value;
			}
		}

		public Vector2 vector2Value
		{
			get
			{
				return _Vector2Value.value;
			}
		}

		public Vector3 vector3Value
		{
			get
			{
				return _Vector3Value.value;
			}
		}

		public Quaternion quaternionValue
		{
			get
			{
				return _QuaternionValue.value;
			}
		}

		public Rect rectValue
		{
			get
			{
				return _RectValue.value;
			}
		}

		public Bounds boundsValue
		{
			get
			{
				return _BoundsValue.value;
			}
		}

		public Color colorValue
		{
			get
			{
				return _ColorValue.value;
			}
		}

		public Transform transformValue
		{
			get
			{
				return _TransformValue.value;
			}
		}

		public RectTransform rectTransformValue
		{
			get
			{
				return _RectTransformValue.value;
			}
		}

		public Rigidbody rigidbodyValue
		{
			get
			{
				return _RigidbodyValue.value;
			}
		}

		public Rigidbody2D rigidbody2DValue
		{
			get
			{
				return _Rigidbody2DValue.value;
			}
		}

		public Component componentValue
		{
			get
			{
				return _ComponentValue.value;
			}
		}

		void SerializeVer1()
		{
			_IntValue = (FlexibleInt)_OldIntValue;
			_FloatValue = (FlexibleFloat)_OldFloatValue;
			_BoolValue = (FlexibleBool)_OldBoolValue;
		}

		void INodeBehaviourSerializationCallbackReceiver.OnBeforeSerialize()
		{
			if (_SerializeVersion == 0)
			{
				SerializeVer1();
                _SerializeVersion = 1;
			}
		}

		void INodeBehaviourSerializationCallbackReceiver.OnAfterDeserialize()
		{
			if (_SerializeVersion == 0)
			{
				SerializeVer1();
			}
		}

		// Use this for enter state
		public override void OnStateBegin()
		{
			Parameter parameter = reference.parameter;

			if (parameter == null)
			{
				return;
			}

			switch (parameter.type)
			{
				case Parameter.Type.Int:
					{
						int value = parameter.intValue;
                        switch (function)
						{
							case Function.Assign:
								value = intValue;
								break;
							case Function.Add:
								value += intValue;
								break;
						}
						parameter.intValue = value;
					}
					break;
				case Parameter.Type.Long:
					{
						long value = parameter.longValue;
						switch (function)
						{
							case Function.Assign:
								value = longValue;
								break;
							case Function.Add:
								value += longValue;
								break;
						}
						parameter.longValue = value;
					}
					break;
				case Parameter.Type.Float:
					{
						float value = parameter.floatValue;
						switch (function)
						{
							case Function.Assign:
								value = floatValue;
								break;
							case Function.Add:
								value += floatValue;
								break;
						}
						parameter.floatValue = value;
					}
					break;
				case Parameter.Type.Bool:
					{
						parameter.boolValue = boolValue;
					}
					break;
				case Parameter.Type.String:
					{
						string value = parameter.stringValue;
						switch (function)
						{
							case Function.Assign:
								value = stringValue;
								break;
							case Function.Add:
								value += stringValue;
								break;
						}
						parameter.stringValue = value;
					}
					break;
				case Parameter.Type.Enum:
					{
						parameter.intValue = enumValue;
					}
					break;
				case Parameter.Type.GameObject:
					{
						parameter.gameObjectValue = gameObjectValue;
					}
					break;
				case Parameter.Type.Vector2:
					{
						parameter.vector2Value = vector2Value;
					}
					break;
				case Parameter.Type.Vector3:
					{
						parameter.vector3Value = vector3Value;
					}
					break;
				case Parameter.Type.Quaternion:
					{
						parameter.quaternionValue = quaternionValue;
					}
					break;
				case Parameter.Type.Rect:
					{
						parameter.rectValue = rectValue;
					}
					break;
				case Parameter.Type.Bounds:
					{
						parameter.boundsValue = boundsValue;
					}
					break;
				case Parameter.Type.Color:
					{
						parameter.colorValue = colorValue;
					}
					break;
				case Parameter.Type.Transform:
					{
						parameter.objectReferenceValue = transformValue;
					}
					break;
				case Parameter.Type.RectTransform:
					{
						parameter.objectReferenceValue = rectTransformValue;
					}
					break;
				case Parameter.Type.Rigidbody:
					{
						parameter.objectReferenceValue = rigidbodyValue;
					}
					break;
				case Parameter.Type.Rigidbody2D:
					{
						parameter.objectReferenceValue = rigidbody2DValue;
					}
					break;
				case Parameter.Type.Component:
					{
						parameter.objectReferenceValue = componentValue;
					}
					break;
			}
		}
	}
}
