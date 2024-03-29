﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.BehaviourTree.Actions
{
#if ARBOR_DOC_JA
	/// <summary>
	/// ArborFSMを再生する。
	/// </summary>
#else
	/// <summary>
	/// Play ArborFSM
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("StateMachine/PlayStateMachine")]
	[BuiltInBehaviour]
	public class PlayStateMachine : ActionBehaviour
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

		protected override void OnExecute()
		{
			ArborFSM stateMachine = _StateMachine.value as ArborFSM;
			if (stateMachine != null)
			{
				stateMachine.Play();
				FinishExecute(true);
			}
			else
			{
				FinishExecute(false);
			}
		}
	}
}