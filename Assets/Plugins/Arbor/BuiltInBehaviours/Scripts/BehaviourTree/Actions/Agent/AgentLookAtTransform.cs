﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.BehaviourTree.Actions
{
#if ARBOR_DOC_JA
	/// <summary>
	/// AgentをTargetの方向へ回転させる。
	/// </summary>
#else
	/// <summary>
	/// Rotate the Agent in the direction of Target.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Agent/AgentLookAtTransform")]
	[BuiltInBehaviour]
	public class AgentLookAtTransform : AgentRotateBase
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 対象のTransform
		/// </summary>
#else
		/// <summary>
		/// Target Transform
		/// </summary>
#endif
		[SerializeField]
		private FlexibleTransform _TargetTransform = new FlexibleTransform();

		#endregion // Serialize fields

		protected override void OnExecute()
		{
			AgentController agentController = cachedAgentController;
			if (agentController != null)
			{
				agentController.LookAt(_AngularSpeed.value, _TargetTransform.value);

				if (agentController.isDone)
				{
					FinishExecute(true);
				}
			}
			else
			{
				FinishExecute(false);
			}
		}
	}
}