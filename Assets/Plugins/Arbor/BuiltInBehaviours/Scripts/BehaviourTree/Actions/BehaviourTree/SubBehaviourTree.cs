using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.BehaviourTree.Actions
{
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
	public class SubBehaviourTree : ActionBehaviour, INodeGraphContainer
	{
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

		private bool _IsFinished = false;
		private bool _Success = false;

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
			behaviourTree.restartOnFinish = false;
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

		protected override void OnStart() 
		{
			_IsFinished = false;
			if (_BehaviourTree != null)
			{
				_ArgumentList.UpdateInput(_BehaviourTree, GraphArgumentUpdateTiming.Enter);

				_BehaviourTree.enabled = true;
				_BehaviourTree.Play();
			}
		}

		protected override void OnExecute() 
		{
			if (_BehaviourTree != null)
			{
				_ArgumentList.UpdateInput(_BehaviourTree, GraphArgumentUpdateTiming.Execute);

				_BehaviourTree.Execute();
				if (_IsFinished)
				{
					_BehaviourTree.Stop();
					_BehaviourTree.enabled = false;

					FinishExecute(_Success);
				}
			}
		}

		protected override void OnEnd() 
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
			_IsFinished = true;
			_Success = success;
		}
	}
}