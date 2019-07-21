using UnityEngine;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// OnTriggerExit2Dが呼ばれたときにステートを遷移する。
	/// </summary>
#else
	/// <summary>
	/// It will transition the state when the OnTriggerExit2D is called.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transition/Collision2D/OnTriggerExit2DTransition")]
	[BuiltInBehaviour]
	public sealed class OnTriggerExit2DTransition : StateBehaviour
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
		/// Collider2Dの出力。
		/// </summary>
#else
		/// <summary>
		/// Collider2D output.
		/// </summary>
#endif
		[SerializeField] private OutputSlotCollider2D _Collider2D = new OutputSlotCollider2D();

#if ARBOR_DOC_JA
		/// <summary>
		/// 遷移先ステート。<br />
		/// 遷移メソッド : OnTriggerExit2D
		/// </summary>
#else
		/// <summary>
		/// Transition destination state.<br />
		/// Transition Method : OnTriggerExit2D
		/// </summary>
#endif
		[SerializeField] private StateLink _NextState = new StateLink();

		#endregion // Serialize fields

		void OnTriggerExit2D( Collider2D collider )
		{
			if( !enabled )
			{
				return;
			}
			
			if( !_IsCheckTag || _Tag == collider.tag )
			{
				_Collider2D.SetValue(collider);
				Transition ( _NextState );
			}
		}
	}
}
