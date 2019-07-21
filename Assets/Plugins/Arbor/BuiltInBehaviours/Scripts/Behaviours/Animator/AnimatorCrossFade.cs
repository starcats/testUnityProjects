using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Animatorのステートを遷移させる。
	/// </summary>
#else
	/// <summary>
	/// Transit the state of Animator.
	/// </summary>
	/// <remarks></remarks>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Animator/AnimatorCrossFade")]
	[BuiltInBehaviour]
	public sealed class AnimatorCrossFade : AnimatorBase
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
		/// 遷移の継続時間
		/// </summary>
#else
		/// <summary>
		/// Transition duration
		/// </summary>
#endif
		[SerializeField]
		[FormerlySerializedAs("transitionDuration")]
		private float _TransitionDuration = 0f;

#if ARBOR_DOC_JA
		/// <summary>
		/// 現在の遷移先のステートの開始時間。
		/// </summary>
#else
		/// <summary>
		/// Normalized time
		/// </summary>
#endif
		[SerializeField]
		[FormerlySerializedAs("normalizedTime")]
		private float _NormalizedTime = float.NegativeInfinity;

		#endregion // Serialize fields
		
		// Use this for enter state
		public override void OnStateBegin()
		{
			Animator animator = cachedAnimator;
			if (animator != null)
			{
				animator.CrossFade(_StateName, _TransitionDuration, GetLayerIndex(animator,_LayerName), _NormalizedTime);
			}
		}
	}
}