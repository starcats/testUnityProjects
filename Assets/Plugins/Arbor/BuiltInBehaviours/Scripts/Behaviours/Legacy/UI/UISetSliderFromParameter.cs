using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Sliderの値をParameterから設定します。
	/// </summary>
#else
	/// <summary>
	/// Set the value of Slider from Parameter.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Legacy/UI/UISetSliderFromParameter")]
	[BuiltInBehaviour]
	public sealed class UISetSliderFromParameter : StateBehaviour
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
		[SerializeField] private Slider _Slider;

#if ARBOR_DOC_JA
		/// <summary>
		/// 参照するParameter
		/// </summary>
#else
		/// <summary>
		/// Reference Parameter
		/// </summary>
#endif
		[SerializeField] private FloatParameterReference _Parameter = new FloatParameterReference();

#if ARBOR_DOC_JA
		/// <summary>
		/// パラメータが変更したときに更新するかどうか。
		/// </summary>
#else
		/// <summary>
		/// Whether to update when parameters change.
		/// </summary>
#endif
		[SerializeField] private bool _ChangeTimingUpdate = false;

		#endregion // Serialize fields

		void Awake()
		{
			if (_Slider == null)
			{
				_Slider = GetComponent<Slider>();
			}
		}

		void UpdateSlider()
		{
			if (_Slider != null && _Parameter.parameter != null)
			{
				_Slider.value = _Parameter.parameter.floatValue;
			}
		}

		void OnChangedParameter(Parameter parameter)
		{
			UpdateSlider();
		}

		private Parameter _CachedParameter;
		private Parameter cachedParameter
		{
			get
			{
				if (_CachedParameter == null)
				{
					_CachedParameter = _Parameter.parameter;
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
	}
}
