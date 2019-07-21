using System;
using UnityEngine;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// AgentをTargetから逃げるように移動させる。
	/// </summary>
	/// <remarks>
	/// インターバルはMin IntervalとMax Intervalの範囲からランダムに決定する。<br/>
	/// </remarks>
#else
	/// <summary>
	/// Move the Agent to escape from Target.
	/// </summary>
	/// <remarks>
	/// Intervals are randomly determined from the range of Min Interval and Max Interval.<br/>
	/// </remarks>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Agent/AgentEscape")]
	[BuiltInBehaviour]
	public sealed class AgentEscape : AgentMoveBase
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 離れる距離
		/// </summary>
#else
		/// <summary>
		/// Distance away
		/// </summary>
#endif
		[SerializeField] private float _Distance = 0f;

#if ARBOR_DOC_JA
		/// <summary>
		/// 逃げたい対象のTransform
		/// </summary>
#else
		/// <summary>
		/// Transform of object to escape
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
				agentController.Escape(_Speed, _Distance, _Target.value);
			}
		}

		protected override void OnDone()
		{
			Transition(_Done);
		}
	}
}
