using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Animatorのレイヤーのウェイトを設定する。
	/// </summary>
#else
	/// <summary>
	/// Set weight of Animator's layer.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Animator/AnimatorSetLayerWeight")]
	[BuiltInBehaviour]
	public sealed class AnimatorSetLayerWeight : AnimatorBase
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
		/// ウェイト
		/// </summary>
#else
		/// <summary>
		/// Weight
		/// </summary>
#endif
		[SerializeField]
		[FormerlySerializedAs("weight")]
		private float _Weight = 0f;

		#endregion // Serialize fields
		
		// Use this for enter state
		public override void OnStateBegin()
		{
			Animator animator = cachedAnimator;
			if (animator != null)
			{
				animator.SetLayerWeight(GetLayerIndex(animator,_LayerName), _Weight);
			}
		}
	}
}