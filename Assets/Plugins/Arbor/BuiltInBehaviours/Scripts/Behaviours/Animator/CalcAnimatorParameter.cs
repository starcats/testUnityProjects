using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// AnimatorのParameterを演算して変更する。
	/// </summary>
#else
	/// <summary>
	/// Calculate and change the parameter of Animator.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Animator/CalcAnimatorParameter")]
	[BuiltInBehaviour]
	public sealed class CalcAnimatorParameter : StateBehaviour, INodeBehaviourSerializationCallbackReceiver
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
		/// 参照するAnimatorとParameter名。
		/// </summary>
#else
		/// <summary>
		/// Reference Animator and Parameter name.
		/// </summary>
#endif
		[FormerlySerializedAs("reference")]
		[SerializeField]
		private AnimatorParameterReference _Reference = new AnimatorParameterReference();

#if ARBOR_DOC_JA
		/// <summary>
		/// 演算するタイプ(Int、Floatのみ)。
		/// </summary>
#else
		/// <summary>
		/// Type to calculate (Int, Float only).
		/// </summary>
#endif
		[FormerlySerializedAs("function")]
		[SerializeField]
		private Function _Function = Function.Assign;

#if ARBOR_DOC_JA
		/// <summary>
		/// 演算するfloat値
		/// </summary>
#else
		/// <summary>
		/// float value to be computed
		/// </summary>
#endif
		[SerializeField]
		private FlexibleFloat _FloatValue = new FlexibleFloat();

#if ARBOR_DOC_JA
		/// <summary>
		/// 演算するint値
		/// </summary>
#else
		/// <summary>
		/// int value to be computed
		/// </summary>
#endif
		[SerializeField]
		private FlexibleInt _IntValue = new FlexibleInt();

#if ARBOR_DOC_JA
		/// <summary>
		/// 演算するbool値。<br/>
		/// bool値の場合はこの値をそのまま代入する。
		/// </summary>
#else
		/// <summary>
		/// bool value to compute.<br/>
		/// In case of bool value, substitute this value as it is.
		/// </summary>
#endif
		[SerializeField]
		private FlexibleBool _BoolValue = new FlexibleBool();

		[SerializeField]
		[HideInInspector]
		private int _SerializeVersion;

#region old

		[FormerlySerializedAs( "floatValue" )]
		[SerializeField]
		[HideInInspector]
		private float _OldFloatValue = 0f;

		[FormerlySerializedAs( "intValue" )]
		[SerializeField]
		[HideInInspector]
		private int _OldIntValue = 0;

		[FormerlySerializedAs( "boolValue" )]
		[SerializeField]
		[HideInInspector]
		private bool _OldBoolValue = false;

#endregion // old

#endregion // Serialize fields

		public float floatValue
		{
			get
			{
				return _FloatValue.value;
			}
		}

		public int intValue
		{
			get
			{
				return _IntValue.value;
			}
		}

		public bool boolValue
		{
			get
			{
				return _BoolValue.value;
			}
		}

		void SerializeVer1()
		{
			_FloatValue = (FlexibleFloat)_OldFloatValue;
			_IntValue = (FlexibleInt)_OldIntValue;
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

		private int _ParameterID;

		void Awake()
		{
			_ParameterID = Animator.StringToHash(_Reference.name);
        }

		// Use this for enter state
		public override void OnStateBegin()
		{
			if (_Reference.animator == null)
			{
				return;
			}

			switch (_Reference.type)
			{
				case 1:// Float
					{
						float value = _Reference.animator.GetFloat(_ParameterID);
						switch (_Function)
						{
							case Function.Assign:
								value = floatValue;
								break;
							case Function.Add:
								value += floatValue;
								break;
						}
						_Reference.animator.SetFloat(_ParameterID, value);
					}
					break;
				case 3:// Int
					{
						int value = _Reference.animator.GetInteger(_ParameterID);
						switch (_Function)
						{
							case Function.Assign:
								value = intValue;
								break;
							case Function.Add:
								value += intValue;
								break;
						}
						_Reference.animator.SetInteger(_ParameterID, value);
					}
					break;
				case 4:// Bool
					{
						_Reference.animator.SetBool(_ParameterID, boolValue);
					}
					break;
				case 9:// Trigger
					{
						_Reference.animator.SetTrigger(_ParameterID);
					}
					break;
			}
		}
	}
}
