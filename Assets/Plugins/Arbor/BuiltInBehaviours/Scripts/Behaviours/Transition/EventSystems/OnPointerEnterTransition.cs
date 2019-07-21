﻿using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// OnPointerEnterが呼ばれたときにステートを遷移する。
	/// </summary>
#else
	/// <summary>
	/// It will transition the state when the OnPointerEnter is called.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transition/EventSystems/OnPointerEnterTransition")]
	[BuiltInBehaviour]
	public sealed class OnPointerEnterTransition : StateBehaviour , IPointerEnterHandler
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 遷移先ステート。<br />
		/// 遷移メソッド : OnPointerEnter
		/// </summary>
#else
		/// <summary>
		/// Transition destination state.<br />
		/// Transition Method : OnPointerEnter
		/// </summary>
#endif
		[SerializeField] private StateLink _NextState = new StateLink();

		#endregion // Serialize fields

		public void OnPointerEnter(PointerEventData data)
		{
			Transition(_NextState);
		}
	}
}
