using UnityEngine;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// OnTriggerExitが呼ばれたときにステートを遷移する。
	/// </summary>
#else
	/// <summary>
	/// It will transition the state when the OnTriggerExit is called.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transition/Collision/OnTriggerExitTransition")]
	[BuiltInBehaviour]
	public sealed class OnTriggerExitTransition : StateBehaviour
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
		/// 遷移メソッド : OnTriggerExit
		/// </summary>
#else
		/// <summary>
		/// Transition destination state.<br />
		/// Transition Method : OnTriggerExit
		/// </summary>
#endif
		[SerializeField] private StateLink _NextState = new StateLink();

		#endregion // Serialize fields

		void OnTriggerExit( Collider collider )
		{
			if( !enabled )
			{
				return;
			}

			if( !_IsCheckTag || collider.tag == _Tag )
			{
				_Collider.SetValue(collider);
				Transition( _NextState );
			}
		}
	}
}
