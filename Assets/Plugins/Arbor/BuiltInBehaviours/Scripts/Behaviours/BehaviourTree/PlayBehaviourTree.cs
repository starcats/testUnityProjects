using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.StateMachine.StateBehaviours
{
	using Arbor.BehaviourTree;

#if ARBOR_DOC_JA
	/// <summary>
	/// BehaviourTreeを再生する
	/// </summary>
#else
	/// <summary>
	/// Play BehaviourTree
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("BehaviourTree/PlayBehaviourTree")]
	[BuiltInBehaviour]
	public class PlayBehaviourTree : StateBehaviour
	{
#if ARBOR_DOC_JA
		/// <summary>
		/// 再生開始するBehaviourTree
		/// </summary>
#else
		/// <summary>
		/// Start playback BehaviourTree
		/// </summary>
#endif
		[SlotType(typeof(BehaviourTree))]
		[SerializeField]
		private FlexibleComponent _BehaviourTree = new FlexibleComponent();

		// Use this for enter state
		public override void OnStateBegin()
		{
			BehaviourTree behaviourTree = _BehaviourTree.value as BehaviourTree;
			if (behaviourTree != null)
			{
				behaviourTree.Play();
			}
		}
	}
}