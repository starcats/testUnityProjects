using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// ArborFSMを再生する。
	/// </summary>
#else
	/// <summary>
	/// Play ArborFSM.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("StateMachine/PlayStateMachine")]
	[BuiltInBehaviour]
	public class PlayStateMachine : StateBehaviour
	{
#if ARBOR_DOC_JA
		/// <summary>
		/// 再生開始するArborFSM
		/// </summary>
#else
		/// <summary>
		/// Start playback ArborFSM
		/// </summary>
#endif
		[SlotType(typeof(ArborFSM))]
		[SerializeField]
		private FlexibleComponent _StateMachine = new FlexibleComponent();

		// Use this for enter state
		public override void OnStateBegin()
		{
			ArborFSM stateMachine = _StateMachine.value as ArborFSM;
			if (stateMachine != null)
			{
				stateMachine.Play();
			}
		}
	}
}