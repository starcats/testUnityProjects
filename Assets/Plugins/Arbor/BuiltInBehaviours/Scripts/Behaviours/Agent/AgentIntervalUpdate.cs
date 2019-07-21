using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
	[AddComponentMenu("")]
	[HideBehaviour()]
	public abstract class AgentIntervalUpdate : AgentBase
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 移動先を変更するまでの最小のインターバル(秒)。
		/// </summary>
#else
		/// <summary>
		/// Minimum interval (seconds) before moving destination is changed.
		/// </summary>
#endif
		[SerializeField] private float _MinInterval = 0f;

#if ARBOR_DOC_JA
		/// <summary>
		/// 移動先を変更するまでの最大のインターバル(秒)。
		/// </summary>
#else
		/// <summary>
		/// Maximum interval (seconds) before moving destination is changed.
		/// </summary>
#endif
		[SerializeField] private float _MaxInterval = 0f;

#if ARBOR_DOC_JA
		/// <summary>
		/// ステートから抜けるときに停止するかどうか
		/// </summary>
#else
		/// <summary>
		/// Whether to stop when leaving the state.
		/// </summary>
#endif
		[SerializeField] private bool _StopOnStateEnd = false;

		#endregion // Serialize fields

		private float _Timer;
		
		// Use this for enter state
		public override void OnStateBegin()
		{
			_Timer = 0.0f;
		}

		// Use this for exit state
		public override void OnStateEnd()
		{
			AgentController agentController = cachedAgentController;
			if (_StopOnStateEnd && agentController != null)
			{
				agentController.Stop();
			}
		}

		protected abstract void OnUpdateAgent();
		protected virtual void OnDone()
		{
		}

		// Update is called once per frame
		public override void OnStateUpdate()
		{
			AgentController agentController = cachedAgentController;

			_Timer -= Time.deltaTime;

			if (_Timer <= 0.0f)
			{
				if (agentController != null)
				{
					OnUpdateAgent();
				}
				_Timer = Random.Range(_MinInterval, _MaxInterval);
			}

			if (agentController != null && agentController.isDone)
			{
				OnDone();
			}
		}
	}
}