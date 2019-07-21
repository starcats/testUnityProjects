using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.StateMachine.StateBehaviours
{
	[AddComponentMenu("")]
	[HideBehaviour()]
	public abstract class AgentMoveBase : AgentIntervalUpdate
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 移動速度
		/// </summary>
#else
		/// <summary>
		/// Moving Speed
		/// </summary>
#endif
		[SerializeField] protected float _Speed = 0f;

		#endregion // Serialize fields
	}
}
