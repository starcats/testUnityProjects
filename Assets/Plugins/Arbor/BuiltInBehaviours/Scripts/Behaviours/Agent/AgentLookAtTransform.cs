using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// 指定Trasnformの方向へ回転する。
	/// </summary>
	/// <remarks>
	/// インターバルはMin IntervalとMax Intervalの範囲からランダムに決定する。<br/>
	/// </remarks>
#else
	/// <summary>
	/// Rotates in the direction of the specified Transform.
	/// </summary>
	/// <remarks>
	/// Intervals are randomly determined from the range of Min Interval and Max Interval.<br/>
	/// </remarks>
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
		/// Transform of target
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
				agentController.LookAt(_AngularSpeed.value, _Target.value);
			}
		}

		protected override void OnDone()
		{
			Transition(_Done);
		}
	}
}
