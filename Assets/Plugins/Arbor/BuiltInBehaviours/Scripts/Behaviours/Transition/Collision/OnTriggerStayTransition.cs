using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// OnTriggerStayが呼ばれたときにステートを遷移する。
	/// </summary>
#else
	/// <summary>
	/// It will transition the state when the OnTriggerStay is called.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transition/Collision/OnTriggerStayTransition")]
	[BuiltInBehaviour]
	public sealed class OnTriggerStayTransition : StateBehaviour
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// タグをチェックするかどうか。
		/// </summary>
#else
		/// <summary>
		/// Whether to check the tag.
		/// </summary>
#endif
		[SerializeField] private bool _IsCheckTag = false;

#if ARBOR_DOC_JA
		/// <summary>
		/// チェックするタグ。
		/// </summary>
#else
		/// <summary>
		/// Tag to be checked.
		/// </summary>
#endif
		[SerializeField] private string _Tag = "Untagged";

#if ARBOR_DOC_JA
		/// <summary>
		/// Colliderの出力。
		/// </summary>
#else
		/// <summary>
		/// Collider output.
		/// </summary>
#endif
		[SerializeField] private OutputSlotCollider _Collider = new OutputSlotCollider();

#if ARBOR_DOC_JA
		/// <summary>
		/// 遷移先ステート。<br />
		/// 遷移メソッド : OnTriggerStay
		/// </summary>
#else
		/// <summary>
		/// Transition destination state.<br />
		/// Transition Method : OnTriggerStay
		/// </summary>
#endif
		[SerializeField] private StateLink _NextState = new StateLink();

		#endregion // Serialize fields

		void OnTriggerStay( Collider collider )
		{
			if( !enabled )
			{
				return;
			}

			if( !_IsCheckTag || _Tag == collider.tag )
			{
				_Collider.SetValue(collider);
				Transition( _NextState );
			}
		}
	}
}
