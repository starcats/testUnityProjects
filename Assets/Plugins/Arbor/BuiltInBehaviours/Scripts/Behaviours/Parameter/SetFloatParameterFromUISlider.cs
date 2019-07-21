using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Sliderの値をParameterに設定する。
	/// </summary>
#else
	/// <summary>
	/// Set the value of the Slider to Parameter.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Parameter/SetFloatParameterFromUISlider")]
	[BuiltInBehaviour]
	public sealed class SetFloatParameterFromUISlider : StateBehaviour
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 設定するパラメータ
		/// </summary>
#else
		/// <summary>
		/// Parameters to be set
		/// </summary>
#endif
		[SerializeField] private FloatParameterReference _Parameter = new FloatParameterReference();

#if ARBOR_DOC_JA
		/// <summary>
		/// 参照するSlider
		/// </summary>
#else
		/// <summary>
		/// See to Slider
		/// </summary>
#endif
		[SerializeField] private Slider _Slider = null;

#if ARBOR_DOC_JA
		/// <summary>
		/// 変更時に更新するかどうか。
		/// </summary>
#else
		/// <summary>
		/// Whether to update at the time of the change.
		/// </summary>
#endif
		[SerializeField] private bool _ChangeTimingUpdate = false;

		#endregion // Serialize fields

		void UpdateParameter(float value)
		{
			if ( _Parameter.parameter != null && _Parameter.parameter.type == Parameter.Type.Float)
			{
				_Parameter.parameter.floatValue = value;
			}
		}

		// Use this for enter state
		public override void OnStateBegin()
		{
			if (_Slider != null )
			{
				UpdateParameter(_Slider.value);

				if (_ChangeTimingUpdate)
				{
					_Slider.onValueChanged.AddListener(UpdateParameter);
				}
			}
		}

		public override void OnStateEnd()
		{
			if (_ChangeTimingUpdate)
			{
				_Slider.onValueChanged.RemoveListener(UpdateParameter);
			}
		}
	}
}
