using UnityEngine;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// 強制的にステートを遷移する。
	/// </summary>
#else
	/// <summary>
	/// It will transition to force the state.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transition/GoToTransition")]
	[BuiltInBehaviour]
	public sealed class GoToTransition : StateBehaviour 
	{
#if ARBOR_DOC_JA
		/// <summary>
		/// 遷移呼び出しするメソッド
		/// </summary>
#else
		/// <summary>
		/// Method to call transition
		/// </summary>
#endif
		[Internal.Documentable]
		public enum TransitionMethod
		{
#if ARBOR_DOC_JA
			/// <summary>
			/// OnStateBeginメソッドから遷移する。
			/// </summary>
#else
			/// <summary>
			/// Transition from OnStateBegin method.
			/// </summary>
#endif
			OnStateBegin,

#if ARBOR_DOC_JA
			/// <summary>
			/// OnStateUpdateメソッドから遷移する。
			/// </summary>
#else
			/// <summary>
			/// Transition from OnStateUpdate method.
			/// </summary>
#endif
			OnStateUpdate,

#if ARBOR_DOC_JA
			/// <summary>
			/// OnStateLateUpdateメソッドから遷移する。
			/// </summary>
#else
			/// <summary>
			/// Transition from OnStateLateUpdate method.
			/// </summary>
#endif
			OnStateLateUpdate,
		}

		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 遷移呼び出しするメソッド
		/// </summary>
#else
		/// <summary>
		/// Method to call transition
		/// </summary>
#endif
		[SerializeField]
		private TransitionMethod _TransitionMethod = TransitionMethod.OnStateBegin;

#if ARBOR_DOC_JA
		/// <summary>
		/// 遷移先ステート。<br />
		/// 遷移メソッド : Transition Methodフィールドにより指定。
		/// </summary>
#else
		/// <summary>
		/// Transition destination state.<br />
		/// Transition Method : Set by Transition Method field.
		/// </summary>
#endif
		[SerializeField] private StateLink _NextState = new StateLink();

#endregion // Serialize fields

		void Transition()
		{
			Transition(_NextState);
		}

		// Use this for enter state
		public override void OnStateBegin()
		{
			if (_TransitionMethod == TransitionMethod.OnStateBegin)
			{
				Transition();
			}
		}

		public override void OnStateUpdate()
		{
			if (_TransitionMethod == TransitionMethod.OnStateUpdate)
			{
				Transition();
			}
		}

		public override void OnStateLateUpdate()
		{
			if (_TransitionMethod == TransitionMethod.OnStateLateUpdate)
			{
				Transition();
			}
		}
	}
}
