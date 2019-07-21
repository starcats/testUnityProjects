using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// ArborFSMを停止する。
	/// </summary>
#else
	/// <summary>
	/// Stop ArborFSM.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("StateMachine/StopStateMachine")]
	[BuiltInBehaviour]
	public class StopStateMachine : StateBehaviour
	{
#if ARBOR_DOC_JA
		/// <summary>
		/// 停止するArborFSM
		/// </summary>
#else
		/// <summary>
		/// ArborFSM to stop playback
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
				stateMachine.Stop();
			}
		}
	}
}