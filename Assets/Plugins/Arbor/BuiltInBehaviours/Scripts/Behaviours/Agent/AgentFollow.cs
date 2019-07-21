using System;
using UnityEngine;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// AgentをTargetに近づくように移動させる。
	/// </summary>
	/// <remarks>
	/// インターバルはMin IntervalとMax Intervalの範囲からランダムに決定する。<br/>
	/// </remarks>
#else
	/// <summary>
	/// Move Agent so that it approaches Target.
	/// </summary>
	/// <remarks>
	/// Intervals are randomly determined from the range of Min Interval and Max Interval.<br/>
	/// </remarks>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Agent/AgentFollow")]
	[BuiltInBehaviour]
	public sealed class AgentFollow : AgentMoveBase
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 停止する距離
		/// </summary>
#else
		/// <summary>
		/// Distance to stop
		/// </summary>
#endif
		[SerializeField] private float _StoppingDistance = 0f;

#if ARBOR_DOC_JA
		/// <summary>
		/// 近づきたい対象のTransform
		/// </summary>
#else
		/// <summary>
		/// The target Transform to be approached
		/// </summary>
#endif
		[SerializeField] private FlexibleTransform _Target = new FlexibleTransform();

#if ARBOR_DOC_JA
		/// <summary>
		/// 移動完了した時のステート遷移<br />
		/// 遷移メソッド : OnStateUpdate
		/// </summary>
#else
		/// <summary>
		/// State transition at the time of movement completion<br />
		/// Transition Method : OnStateUpdate
		/// </summary>
#endif
		[SerializeField] private StateLink _Done = new StateLink();

		#endregion

		protected override void OnUpdateAgent()
		{
			AgentController agentController = cachedAgentController;
			if (agentController != null)
			{
				agentController.Follow(_Speed, _StoppingDistance, _Target.value);
			}
		}

		protected override void OnDone()
		{
			Transition(_Done);
		}
	}
}
