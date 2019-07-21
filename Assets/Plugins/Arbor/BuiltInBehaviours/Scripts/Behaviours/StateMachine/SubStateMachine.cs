using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// 子階層のArborFSMを再生する。
	/// </summary>
#else
	/// <summary>
	/// Play a child hierarchy ArborFSM.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("StateMachine/SubStateMachine")]
	[BuiltInBehaviour]
	public sealed class SubStateMachine : StateBehaviour, INodeGraphContainer
	{
		[SerializeField]
		[HideInInspector]
		private ArborFSM _StateMachine;

#if ARBOR_DOC_JA
		/// <summary>
		/// トリガーを子FSMに受け渡すフラグ
		/// </summary>
#else
		/// <summary>
		/// Flag to pass trigger to child FSM
		/// </summary>
#endif
		[SerializeField]
		private bool _PassThroughTrigger = true;

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

		public ArborFSM subFSM
		{
			get
			{
				return _StateMachine;
			}
		}

		protected override void OnCreated()
		{
			ArborFSM stateMachine = NodeGraph.Create<ArborFSM>(gameObject);

			ComponentUtility.RecordObject(stateMachine, "Add ArborFSM");
#if !ARBOR_DEBUG
			stateMachine.hideFlags = HideFlags.HideInInspector | HideFlags.HideInHierarchy;
#endif
			stateMachine.playOnStart = false;
			stateMachine.updateSettings.type = UpdateType.Manual;
			stateMachine.ownerBehaviour = this;
			stateMachine.enabled = false;

			ComponentUtility.RecordObject(this, "Add ArborFSM");
			_StateMachine = stateMachine;
		}

		protected override void OnPreDestroy()
		{
			if (_StateMachine != null)
			{
				NodeGraph.Destroy(_StateMachine);
			}
		}

		void OnEnable()
		{
			if (_StateMachine != null && _StateMachine.playState != PlayState.Stopping )
			{
				_StateMachine.enabled = true;
			}
		}

		void OnDisable()
		{
			if (_StateMachine != null && _StateMachine.playState != PlayState.Stopping )
			{
				_StateMachine.enabled = false;
			}
		}

		// Use this for enter state
		public override void OnStateBegin()
		{
			if (_StateMachine != null)
			{
				_ArgumentList.UpdateInput(_StateMachine, GraphArgumentUpdateTiming.Enter);

				_StateMachine.enabled = true;
				_StateMachine.Play();
			}
		}

		public override void OnStateUpdate()
		{
			if (_StateMachine != null)
			{
				_ArgumentList.UpdateInput(_StateMachine, GraphArgumentUpdateTiming.Execute);

				_StateMachine.ExecuteUpdate();
			}
		}

		public override void OnStateLateUpdate()
		{
			if (_StateMachine != null)
			{
				_ArgumentList.UpdateInput(_StateMachine, GraphArgumentUpdateTiming.Execute);

				_StateMachine.ExecuteLateUpdate();
			}
		}

		// Use this for exit state
		public override void OnStateEnd() 
		{
			if (_StateMachine != null)
			{
				_StateMachine.Stop();
				_StateMachine.enabled = false;

				_ArgumentList.UpdateOutput(_StateMachine);
			}
		}

		public override void OnStateTrigger(string message)
		{
			if (_PassThroughTrigger && _StateMachine != null)
			{
				_StateMachine.SendTrigger(message);
			}
		}

		int INodeGraphContainer.GetNodeGraphCount()
		{
			return 1;
		}

		T INodeGraphContainer.GetNodeGraph<T>(int index)
		{
			return _StateMachine as T;
		}

		void INodeGraphContainer.SetNodeGraph(int index, NodeGraph graph)
		{
			_StateMachine = graph as ArborFSM;
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