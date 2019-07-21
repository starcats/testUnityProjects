using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// スライダーの値によって遷移する。
	/// </summary>
#else
	/// <summary>
	/// It will transition by the value of the slider.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transition/UI/UISliderTransition")]
	[BuiltInBehaviour]
	public sealed class UISliderTransition : StateBehaviour, INodeBehaviourSerializationCallbackReceiver
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 判定をするスライダー
		/// </summary>
#else
		/// <summary>
		/// Slider to the judgment
		/// </summary>
#endif
		[SerializeField]
		[SlotType(typeof(Slider))]
		private FlexibleComponent _Slider = new FlexibleComponent();

#if ARBOR_DOC_JA
		/// <summary>
		/// スライダーが変更されたタイミングで遷移するかどうか。
		/// </summary>
#else
		/// <summary>
		/// Whether slider transitions with the changed timing.
		/// </summary>
#endif
		[SerializeField] private bool _ChangeTimingTransition = false;

#if ARBOR_DOC_JA
		/// <summary>
		/// 遷移をする閾値。
		/// </summary>
#else
		/// <summary>
		/// Threshold for the transition.
		/// </summary>
#endif
		[SerializeField] private float _Threshold = 0f;

#if ARBOR_DOC_JA
		/// <summary>
		/// Thresholdよりも低かった場合の遷移先。<br />
		/// 遷移メソッド : OnStateBegin, Slider.onValueChanged
		/// </summary>
#else
		/// <summary>
		/// Transition destination when it was lower than Threshold.<br />
		/// Transition Method : OnStateBegin, Slider.onValueChanged
		/// </summary>
#endif
		[SerializeField] private StateLink _LessState = new StateLink();

#if ARBOR_DOC_JA
		/// <summary>
		/// Thresholdよりも高かった場合の遷移先。<br />
		/// 遷移メソッド : OnStateBegin, Slider.onValueChanged
		/// </summary>
#else
		/// <summary>
		/// Transition destination when it is higher than Threshold.<br />
		/// Transition Method : OnStateBegin, Slider.onValueChanged
		/// </summary>
#endif
		[SerializeField] private StateLink _GreaterState = new StateLink();

		[SerializeField]
		[HideInInspector]
		private int _SerializeVersion;

		#region old

		[FormerlySerializedAs("_Slider")]
		[SerializeField]
		[HideInInspector]
		private Slider _OldSlider = null;

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
		
		void Transition(float value)
		{
			if (value <= _Threshold)
			{
				Transition(_LessState);
			}
			else
			{
				Transition(_GreaterState);
			}
		}

		// Use this for enter state
		public override void OnStateBegin()
		{
			Slider slider = cachedSlider;
			if (slider != null)
			{
				if (!_ChangeTimingTransition)
				{
					Transition(slider.value);
				}
				else
				{
					slider.onValueChanged.AddListener(Transition);
				}
			}
		}

		// Use this for exit state
		public override void OnStateEnd()
		{
			Slider slider = cachedSlider;
			if (slider != null)
			{
				if (_ChangeTimingTransition)
				{
					slider.onValueChanged.RemoveListener(Transition);
				}
			}
		}

		void SerializeVer1()
		{
			_Slider = (FlexibleComponent)_OldSlider;
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
