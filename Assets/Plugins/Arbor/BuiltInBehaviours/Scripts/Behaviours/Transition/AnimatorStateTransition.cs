using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Animatorのステートを参照して遷移する。
	/// </summary>
#else
	/// <summary>
	/// Transit by referring to the state of Animator.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transition/AnimatorStateTransition")]
	[BuiltInBehaviour]
	public sealed class AnimatorStateTransition : AnimatorBase
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// レイヤー名。
		/// </summary>
#else
		/// <summary>
		/// Layer Name
		/// </summary>
#endif
		[SerializeField]
		[FormerlySerializedAs("layerName")]
		private string _LayerName = string.Empty;

#if ARBOR_DOC_JA
		/// <summary>
		/// ステート名。
		/// </summary>
#else
		/// <summary>
		/// State Name
		/// </summary>
#endif
		[SerializeField]
		[FormerlySerializedAs("stateName")]
		private string _StateName = string.Empty;

#if ARBOR_DOC_JA
		/// <summary>
		/// 遷移先ステート。<br />
		/// 遷移メソッド : OnStateBegin, OnStateUpdate
		/// </summary>
#else
		/// <summary>
		/// Transition destination state.<br />
		/// Transition Method : OnStateBegin, OnStateUpdate
		/// </summary>
#endif
		[SerializeField]
		[FormerlySerializedAs("nextState")]
		private StateLink _NextState = new StateLink();

		#endregion // Serialize fields

		void CheckTransition()
		{
			Animator animator = cachedAnimator;
			if (animator != null )
			{
				int layerIndex = GetLayerIndex(animator, _LayerName);
				if (layerIndex >= 0)
				{
					AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(layerIndex);
					if (stateInfo.IsName(_LayerName + "." + _StateName))
					{
						Transition(_NextState);
					}
				}
			}
		}

		// Use this for enter state
		public override void OnStateBegin()
		{
			CheckTransition();
        }

		// Update is called once per frame
		public override void OnStateUpdate()
		{
			CheckTransition();
        }
	}
}
