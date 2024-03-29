﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.BehaviourTree.Actions
{
#if ARBOR_DOC_JA
	/// <summary>
	/// ArborFSMを停止する。
	/// </summary>
#else
	/// <summary>
	/// Stop ArborFSM
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("StateMachine/StopStateMachine")]
	[BuiltInBehaviour]
	public class StopStateMachine : ActionBehaviour
	{
#if ARBOR_DOC_JA
		/// <summary>
		/// 再生停止するArborFSM
		/// </summary>
#else
		/// <summary>
		/// ArborFSM to stop playback
		/// </summary>
#endif
		[SlotType(typeof(ArborFSM))]
		[SerializeField]
		private FlexibleComponent _StateMachine = new FlexibleComponent();

		protected override void OnExecute()
		{
			ArborFSM stateMachine = _StateMachine.value as ArborFSM;
			if (stateMachine != null)
			{
				stateMachine.Stop();
				FinishExecute(true);
			}
			else
			{
				FinishExecute(false);
			}
		}
	}
}