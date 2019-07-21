using UnityEngine;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// OnTriggerEnter2Dが呼ばれたときにステートを遷移する。
	/// </summary>
#else
	/// <summary>
	/// It will transition the state when the OnTriggerEnter2D is called.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transition/Collision2D/OnTriggerEnter2DTransition")]
	[BuiltInBehaviour]
	public sealed class OnTriggerEnter2DTransition : StateBehaviour
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
		/// 遷移メソッド : OnTriggerEnter2D
		/// </summary>
#else
		/// <summary>
		/// Transition destination state.<br />
		/// Transition Method : OnTriggerEnter2D
		/// </summary>
#endif
		[SerializeField] private StateLink _NextState = new StateLink();

		#endregion // Serialize fields

		void OnTriggerEnter2D( Collider2D collider )
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
