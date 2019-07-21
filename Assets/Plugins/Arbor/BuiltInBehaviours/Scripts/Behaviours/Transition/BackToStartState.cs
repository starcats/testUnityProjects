using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// 開始ステートへ戻る。
	/// </summary>
#else
	/// <summary>
	/// Back to the start state.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transition/BackToStartState")]
	[BuiltInBehaviour]
	public sealed class BackToStartState : StateBehaviour
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 遷移するタイミング。
		/// </summary>
#else
		/// <summary>
		/// Transition timing.
		/// </summary>
#endif
		[SerializeField]
		private TransitionTiming _TransitionTiming = TransitionTiming.LateUpdateOverwrite;

#endregion // Serialize fields

		// Use this for enter state
		public override void OnStateBegin()
		{
			stateMachine.Transition(stateMachine.startStateID, _TransitionTiming);
		}
	}
}