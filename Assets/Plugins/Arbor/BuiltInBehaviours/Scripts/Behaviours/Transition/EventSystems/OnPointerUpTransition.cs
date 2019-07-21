using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// OnPointerUpが呼ばれたときにステートを遷移する。
	/// </summary>
#else
	/// <summary>
	/// It will transition the state when the OnPointerUp is called.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transition/EventSystems/OnPointerUpTransition")]
	[BuiltInBehaviour]
	public sealed class OnPointerUpTransition : StateBehaviour , IPointerUpHandler
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
		/// 遷移メソッド : OnPointerUp
		/// </summary>
#else
		/// <summary>
		/// Transition destination state.<br />
		/// Transition Method : OnPointerUp
		/// </summary>
#endif
		[SerializeField] private StateLink _NextState = new StateLink();

		#endregion // Serialize fields

		public void OnPointerUp(PointerEventData data)
		{
			if (!_CheckButton || data.button == _Button)
			{
				Transition(_NextState);
			}
		}
	}
}
