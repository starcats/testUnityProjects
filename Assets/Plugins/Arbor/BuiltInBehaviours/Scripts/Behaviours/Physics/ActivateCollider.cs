using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Colliderのアクティブを切り替える。
	/// </summary>
#else
	/// <summary>
	/// Activate Collider.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Physics/ActivateCollider")]
	[BuiltInBehaviour]
	public sealed class ActivateCollider : StateBehaviour
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// アクティブを切り替えるCollider
		/// </summary>
#else
		/// <summary>
		/// Collider to switch the active.
		/// </summary>
#endif
		[SerializeField]
		[SlotType(typeof(Collider))]
		private FlexibleComponent _Target = new FlexibleComponent();

#if ARBOR_DOC_JA
		/// <summary>
		/// ステート開始時のアクティブ切り替え。
		/// </summary>
#else
		/// <summary>
		/// Active switching at the state start.
		/// </summary>
#endif
		[SerializeField]
		private bool _BeginActive = false;

#if ARBOR_DOC_JA
		/// <summary>
		/// ステート終了時のアクティブ切り替え。
		/// </summary>
#else
		/// <summary>
		/// Active switching at the state end.
		/// </summary>
#endif
		[SerializeField]
		private bool _EndActive = false;

		#endregion // Serialize fields

		public Collider target
		{
			get
			{
				return _Target.value as Collider;
			}
		}

		public override void OnStateBegin()
		{
			if (target != null)
			{
				target.enabled = _BeginActive;
			}
		}

		public override void OnStateEnd()
		{
			if (target != null)
			{
				target.enabled = _EndActive;
			}
		}
	}
}