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
	[AddBehaviourMenu("BehaviourTree/StopBehaviourTree")]
	[BuiltInBehaviour]
	public class StopBehaviourTree : ActionBehaviour
	{
#if ARBOR_DOC_JA
		/// <summary>
		/// 再生停止するBehaviourTree
		/// </summary>
#else
		/// <summary>
		/// BehaviourTree to stop playback
		/// </summary>
#endif
		[SlotType(typeof(BehaviourTree))]
		[SerializeField]
		private FlexibleComponent _BehaviourTree = new FlexibleComponent();

		protected override void OnExecute()
		{
			BehaviourTree behaviourTree = _BehaviourTree.value as BehaviourTree;
			if (behaviourTree != null)
			{
				behaviourTree.Stop();
				FinishExecute(true);
			}
			else
			{
				FinishExecute(false);
			}
		}
	}
}