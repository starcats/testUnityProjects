using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Toggleの値をParameterに設定する。
	/// </summary>
#else
	/// <summary>
	/// The value of the Toggle set to Parameter.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Parameter/SetBoolParameterFromUIToggle")]
	[BuiltInBehaviour]
	public sealed class SetBoolParameterFromUIToggle : StateBehaviour
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
		[SerializeField] private BoolParameterReference _Parameter = new BoolParameterReference();

#if ARBOR_DOC_JA
		/// <summary>
		/// 参照するToggle
		/// </summary>
#else
		/// <summary>
		/// See to Toggle
		/// </summary>
#endif
		[SerializeField] private Toggle _Toggle = null;

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

		void UpdateParameter(bool value)
		{
			if ( _Parameter.parameter != null && _Parameter.parameter.type == Parameter.Type.Bool)
			{
				_Parameter.parameter.boolValue = value;
			}
		}

		// Use this for enter state
		public override void OnStateBegin()
		{
			if (_Toggle != null )
			{
				UpdateParameter(_Toggle.isOn);

				if (_ChangeTimingUpdate)
				{
					_Toggle.onValueChanged.AddListener(UpdateParameter);
				}
			}
		}

		public override void OnStateEnd()
		{
			if (_ChangeTimingUpdate)
			{
				_Toggle.onValueChanged.RemoveListener(UpdateParameter);
			}
		}
	}
}
