using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Behaviourのアクティブを切り替える。
	/// </summary>
#else
	/// <summary>
	/// Activate Behaviour.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Component/ActivateBehaviour")]
	[BuiltInBehaviour]
	public sealed class ActivateBehaviour : StateBehaviour
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// アクティブを切り替えるBehaviour
		/// </summary>
#else
		/// <summary>
		/// Behaviour to switch the active.
		/// </summary>
#endif
		[SerializeField]
		[SlotType(typeof(Behaviour))]
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

		public Behaviour target
		{
			get
			{
				return _Target.value as Behaviour;
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