using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Sliderの値を設定します。
	/// </summary>
#else
	/// <summary>
	/// Set the value of Slider.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("UI/UISetSlider")]
	[BuiltInBehaviour]
	public sealed class UISetSlider : StateBehaviour, INodeBehaviourSerializationCallbackReceiver
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 対象となるSlider。<br/>
		/// 指定しない場合は、ArborFSMと同じGameObjectに割り当てられているSlider。
		/// </summary>
#else
		/// <summary>
		/// Slider of interest.<br/>
		/// If not specified, Slider of GameObject that ArborFSM is assigned a target.
		/// </summary>
#endif
		[SerializeField]
		[SlotType(typeof(Slider))]
		private FlexibleComponent _Slider = new FlexibleComponent();

#if ARBOR_DOC_JA
		/// <summary>
		/// 設定する値。
		/// </summary>
#else
		/// <summary>
		/// The value to be set.
		/// </summary>
#endif
		[SerializeField]
		private FlexibleFloat _Value = new FlexibleFloat();

#if ARBOR_DOC_JA
		/// <summary>
		/// パラメータが変更したときに更新するかどうか(ValueがParameterの時のみ)。
		/// </summary>
#else
		/// <summary>
		/// Whether to update when parameters change(Only when Value is Parameter).
		/// </summary>
#endif
		[SerializeField]
		private bool _ChangeTimingUpdate = false;

		[SerializeField]
		[HideInInspector]
		private int _SerializeVersion = 0;

		#region old

		[SerializeField]
		[FormerlySerializedAs("_Slider")]
		[HideInInspector]
		private Slider _OldSlider = null;

		[SerializeField]
		[FormerlySerializedAs("_Value")]
		[HideInInspector]
		private float _OldValue = 0;

		#endregion // old

		#endregion // Serialize fields

		private Slider _MySlider;
		public Slider cachedSlider
		{
			get
			{
				Slider slider = _Slider.value as Slider;
				if (slider == null && _Slider.type == FlexibleType.Constant)
				{
					if (_MySlider == null)
					{
						_MySlider = GetComponent<Slider>();
					}

					slider = _MySlider;
				}
				return slider;
			}
		}
		
		void UpdateSlider()
		{
			Slider slider = cachedSlider;
			if (slider != null )
			{
				slider.value = _Value.value;
			}
		}

		private Parameter _CachedParameter;
		private Parameter cachedParameter
		{
			get
			{
				if (_CachedParameter == null && _Value.type == FlexiblePrimitiveType.Parameter)
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
			UpdateSlider();
		}
		
		void OnChangedParameter(Parameter parameter)
		{
			UpdateSlider();
		}

		void SerializeVer1()
		{
			_Slider = (FlexibleComponent)_OldSlider;
			_Value = (FlexibleFloat)_OldValue;
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
