using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Toggleを設定します。
	/// </summary>
#else
	/// <summary>
	/// Set the Toggle.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("UI/UISetToggle")]
	[BuiltInBehaviour]
	public sealed class UISetToggle : StateBehaviour, INodeBehaviourSerializationCallbackReceiver
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 対象となるToggle。<br/>
		/// 指定しない場合は、ArborFSMと同じGameObjectに割り当てられているToggle。
		/// </summary>
#else
		/// <summary>
		/// Toggle of interest.<br/>
		/// If not specified, Toggle of GameObject that ArborFSM is assigned a target.
		/// </summary>
#endif
		[SerializeField]
		[SlotType(typeof(Toggle))]
		private FlexibleComponent _Toggle = new FlexibleComponent();

#if ARBOR_DOC_JA
		/// <summary>
		/// 設定するトグルの状態。
		/// </summary>
#else
		/// <summary>
		/// Set toggle the state.
		/// </summary>
#endif
		[SerializeField]
		private FlexibleBool _Value = new FlexibleBool();

#if ARBOR_DOC_JA
		/// <summary>
		/// パラメータが変更したときに更新するかどうか(ValueがParameterの時のみ)。
		/// </summary>
#else
		/// <summary>
		/// Whether to update when parameters change(ValueがParameterの時のみ).
		/// </summary>
#endif
		[SerializeField]
		private bool _ChangeTimingUpdate = false;

		[SerializeField]
		[HideInInspector]
		private int _SerializeVersion = 0;

		#region old

		[SerializeField]
		[FormerlySerializedAs("_Toggle")]
		[HideInInspector]
		private Toggle _OldToggle = null;

		[SerializeField]
		[FormerlySerializedAs("_Value")]
		[HideInInspector]
		private bool _OldValue = false;

		#endregion // old

		#endregion // Serialize fields

		private Toggle _MyToggle;
		public Toggle cachedToggle
		{
			get
			{
				Toggle toggle = _Toggle.value as Toggle;
				if (toggle == null && _Toggle.type == FlexibleType.Constant)
				{
					if (_MyToggle == null)
					{
						_MyToggle = GetComponent<Toggle>();
					}

					toggle = _MyToggle;
				}
				return toggle;
			}
		}
		
		void UpdateToggle()
		{
			Toggle toggle = cachedToggle;
			if (toggle != null )
			{
				toggle.isOn = _Value.value;
			}
		}

		private Parameter _CachedParameter;
		private Parameter cachedParameter
		{
			get
			{
				if (_CachedParameter == null && _Value.type == FlexiblePrimitiveType.Parameter )
				{
					_CachedParameter = _Value.parameter;
				}
				return _CachedParameter;
			}
		}

		private bool _IsSettedOnChanged;

		void SetOnChanged()
		{
			if (_IsSettedOnChanged)
			{
				ReleaseOnChanged();
				_CachedParameter = null;
			}

			Parameter parameter = cachedParameter;
			if (parameter != null && _ChangeTimingUpdate)
			{
				parameter.onChanged += OnChangedParameter;
				_IsSettedOnChanged = true;
			}
		}

		void ReleaseOnChanged()
		{
			Parameter parameter = cachedParameter;
			if (parameter != null && _IsSettedOnChanged)
			{
				parameter.onChanged -= OnChangedParameter;
				_IsSettedOnChanged = false;
			}
		}

		void OnEnable()
		{
			SetOnChanged();
		}

		void OnDisable()
		{
			ReleaseOnChanged();
		}

		protected override void OnValidate()
		{
			base.OnValidate();

			if (Application.isPlaying && isActiveAndEnabled && _IsSettedOnChanged)
			{
				SetOnChanged();
			}
		}

		// Use this for enter state
		public override void OnStateBegin()
		{
			UpdateToggle();
		}
		
		void OnChangedParameter(Parameter parameter)
		{
			UpdateToggle();
		}

		void SerializeVer1()
		{
			_Toggle = (FlexibleComponent)_OldToggle;
			_Value = (FlexibleBool)_OldValue;
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
	}
}
