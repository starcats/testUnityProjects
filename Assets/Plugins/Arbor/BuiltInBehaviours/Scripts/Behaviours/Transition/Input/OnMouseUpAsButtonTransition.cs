using UnityEngine;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// OnMouseUpAdButtonが呼ばれたときにステートを遷移する。
	/// </summary>
#else
	/// <summary>
	/// It will transition the state when the OnMouseUpAdButton is called.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transition/Input/OnMouseUpAsButtonTransition")]
	[BuiltInBehaviour]
	public sealed class OnMouseUpAsButtonTransition : StateBehaviour
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 遷移先ステート。<br />
		/// 遷移メソッド : OnMouseUpAdButton
		/// </summary>
#else
		/// <summary>
		/// Transition destination state.<br />
		/// Transition Method : OnMouseUpAdButton
		/// </summary>
#endif
		[SerializeField] private StateLink _NextState = new StateLink();

		#endregion // Serialize fields

		void OnMouseUpAdButton()
		{
			Transition(_NextState);
		}
	}
}
