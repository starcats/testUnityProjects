﻿using UnityEngine;
using System.Collections;

namespace Arbor.BehaviourTree.Composites
{
#if ARBOR_DOC_JA
	/// <summary>
	/// 子ノードのうち一つをランダムに実行し、実行結果をそのまま返す。
	/// </summary>
#else
	/// <summary>
	/// Execute one of the child nodes randomly and return the execution result as it is.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("RandomExecutor")]
	[BuiltInBehaviour]
	public class RandomExecutor : CompositeBehaviour
	{
		public override int GetBeginIndex()
		{
			return Random.Range(0, compositeNode.childrenLink.Count);
		}

		public override bool CanExecute(NodeStatus childStatus)
		{
			return childStatus == NodeStatus.Running;
		}
	}
}
