using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// OnPointerClickが呼ばれたときにステートを遷移する。
	/// </summary>
#else
	/// <summary>
	/// It will transition the state when the OnPointerClick is called.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transition/EventSystems/OnPointerClickTransition")]
	[BuiltInBehaviour]
	public sealed class OnPointerClickTransition : StateBehaviour , IPointerClickHandler
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// ボタンをチェックするかどうか。
		/// </summary>
#else
		/// <summary>
		/// Whether to check the button.
		/// </summary>
#endif
		[SerializeField] private bool _CheckButton = false;

#if ARBOR_DOC_JA
		/// <summary>
		/// チェックするボタン。
		/// </summary>
#else
		/// <summary>
		/// Button to check.
		/// </summary>
#endif
		[SerializeField] private PointerEventData.InputButton _Button = PointerEventData.InputButton.Left;

#if ARBOR_DOC_JA
		/// <summary>
		/// 遷移先ステート。<br />
		/// 遷移メソッド : OnPointerClick
		/// </summary>
#else
		/// <summary>
		/// Transition destination state.<br />
		/// Transition Method : OnPointerClick
		/// </summary>
#endif
		[SerializeField] private StateLink _NextState = new StateLink();

		#endregion // Serialize fields

		public void OnPointerClick(PointerEventData data)
		{
			if (!_CheckButton || data.button == _Button)
			{
				Transition(_NextState);
			}
		}
	}
}
