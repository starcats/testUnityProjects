using UnityEngine;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// GameObjectが存在しているかどうかで遷移する。
	/// </summary>
#else
	/// <summary>
	/// GameObject is I will transition on whether exists.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transition/ExistsGameObjectTransition")]
	[BuiltInBehaviour]
	public sealed class ExistsGameObjectTransition : StateBehaviour
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 存在しているかチェックする対象。
		/// </summary>
#else
		/// <summary>
		/// Subject to check that you are there.
		/// </summary>
#endif
		[SerializeField] private GameObject[] _Targets = null;

#if ARBOR_DOC_JA
		/// <summary>
		/// Update時にチェックするかどうか。
		/// </summary>
#else
		/// <summary>
		/// Whether Update at check.
		/// </summary>
#endif
		[SerializeField] private bool _CheckUpdate = false;

#if ARBOR_DOC_JA
		/// <summary>
		/// すべて存在した場合の遷移先。<br />
		/// 遷移メソッド : OnStateBegin, OnStateUpdate
		/// </summary>
#else
		/// <summary>
		/// Transition destination when all are present.<br />
		/// Transition Method : OnStateBegin, OnStateUpdate
		/// </summary>
#endif
		[SerializeField] private StateLink _AllExistsState = new StateLink();

#if ARBOR_DOC_JA
		/// <summary>
		/// すべて存在しなかった場合の遷移先。<br />
		/// 遷移メソッド : OnStateBegin, OnStateUpdate
		/// </summary>
#else
		/// <summary>
		/// Transition destination when all it did not exist.<br />
		/// Transition Method : OnStateBegin, OnStateUpdate
		/// </summary>
#endif
		[SerializeField] private StateLink _AllNothingState = new StateLink();

		#endregion // Serialize fields

		void CheckTransition()
		{
			if (_Targets.Length > 0)
			{
				int existsCount = 0;
				int nothingCount = 0;

				foreach (GameObject target in _Targets)
				{
					if (target != null)
					{
						existsCount++;
					}
					else
					{
						nothingCount++;
					}
                }
				if (existsCount == _Targets.Length)
				{
					Transition(_AllExistsState);
				}
				else if (nothingCount == _Targets.Length)
				{
					Transition(_AllNothingState);
				}
			}
		}

		// Use this for enter state
		public override void OnStateBegin()
		{
			CheckTransition();
        }

		// Update is called once per frame
		public override void OnStateUpdate()
		{
			if (_CheckUpdate)
			{
				CheckTransition();
            }
		}
	}
}
