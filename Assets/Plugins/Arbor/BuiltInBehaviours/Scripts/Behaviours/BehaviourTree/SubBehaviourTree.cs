﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.StateMachine.StateBehaviours
{
	using Arbor.BehaviourTree;

#if ARBOR_DOC_JA
	/// <summary>
	/// 子階層のBehaviourTreeを再生する
	/// </summary>
#else
	/// <summary>
	/// Play a child hierarchy Behavior Tree
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("BehaviourTree/SubBehaviourTree")]
	[BuiltInBehaviour]
	public class SubBehaviourTree : StateBehaviour, INodeGraphContainer 
	{
		/// <summary>
		/// Behaviour Tree
		/// </summary>
		[SerializeField]
		[HideInInspector]
		private BehaviourTree _BehaviourTree;

#if ARBOR_DOC_JA
		/// <summary>
		/// グラフの引数(パラメータがある場合のみ)<br/>
		/// <list type="bullet">
		/// <item><description>+ボタンから、パラメータを選択して作成。</description></item>
		/// <item><description>パラメータを選択し、-ボタンをクリックで削除。</description></item>
		/// </list>
		/// </summary>
#else
		/// <summary>
		/// Arguments of the graph(Only when there are parameters)<br/>
		/// <list type="bullet">
		/// <item><description>From the + button, select the parameter to create.</description></item>
		/// <item><description>Select the parameter and delete it by clicking the - button.</description></item>
		/// </list>
		/// </summary>
#endif
		[SerializeField]
		private GraphArgumentList _ArgumentList = new GraphArgumentList();

#if ARBOR_DOC_JA
		/// <summary>
		/// 成功時の遷移<br />
		/// 遷移メソッド : OnFinishNodeGraph
		/// </summary>
#else
		/// <summary>
		/// Transition on success<br />
		/// Transition Method : OnFinishNodeGraph
		/// </summary>
#endif
		[SerializeField]
		private StateLink _SuccessLink = new StateLink();

#if ARBOR_DOC_JA
		/// <summary>
		/// 失敗時の遷移<br />
		/// 遷移メソッド : OnFinishNodeGraph
		/// </summary>
#else
		/// <summary>
		/// Transition on failure<br />
		/// Transition Method : OnFinishNodeGraph
		/// </summary>
#endif
		[SerializeField]
		private StateLink _FailureLink = new StateLink();

		public BehaviourTree subBT
		{
			get
			{
				return _BehaviourTree;
			}
		}

		protected override void OnCreated()
		{
			BehaviourTree behaviourTree = NodeGraph.Create<BehaviourTree>(gameObject);

			ComponentUtility.RecordObject(behaviourTree, "Add BehaviourTree");
#if !ARBOR_DEBUG
			behaviourTree.hideFlags = HideFlags.HideInInspector | HideFlags.HideInHierarchy;
#endif
			behaviourTree.playOnStart = false;
			behaviourTree.updateSettings.type = UpdateType.Manual;
			behaviourTree.ownerBehaviour = this;
			behaviourTree.enabled = false;

			ComponentUtility.RecordObject(this, "Add BehaviourTree");
			_BehaviourTree = behaviourTree;
		}

		protected override void OnPreDestroy()
		{
			if (_BehaviourTree != null)
			{
				NodeGraph.Destroy(_BehaviourTree);
			}
		}

		void OnEnable()
		{
			if (_BehaviourTree != null && _BehaviourTree.playState != PlayState.Stopping )
			{
				_BehaviourTree.enabled = true;
			}
		}

		void OnDisable()
		{
			if (_BehaviourTree != null && _BehaviourTree.playState != PlayState.Stopping )
			{
				_BehaviourTree.enabled = false;
			}
		}

		// Use this for enter state
		public override void OnStateBegin()
		{
			if (_BehaviourTree != null)
			{
				_ArgumentList.UpdateInput(_BehaviourTree, GraphArgumentUpdateTiming.Enter);

				_BehaviourTree.enabled = true;
				_BehaviourTree.Play();
			}
		}

		public override void OnStateUpdate()
		{
			if(_BehaviourTree != null )
			{
				_ArgumentList.UpdateInput(_BehaviourTree, GraphArgumentUpdateTiming.Execute);

				_BehaviourTree.Execute();
			}
		}

		// Use this for exit state
		public override void OnStateEnd() 
		{
			if (_BehaviourTree != null)
			{
				_BehaviourTree.Stop();
				_BehaviourTree.enabled = false;

				_ArgumentList.UpdateOutput(_BehaviourTree);
			}
		}

		int INodeGraphContainer.GetNodeGraphCount()
		{
			return 1;
		}

		T INodeGraphContainer.GetNodeGraph<T>(int index)
		{
			return _BehaviourTree as T;
		}

		void INodeGraphContainer.SetNodeGraph(int index, NodeGraph graph)
		{
			_BehaviourTree = graph as BehaviourTree;
		}

		void INodeGraphContainer.OnFinishNodeGraph(NodeGraph graph,bool success)
		{
			if (success)
			{
				Transition(_SuccessLink);
			}
			else
			{
				Transition(_FailureLink);
			}
		}
	}
}