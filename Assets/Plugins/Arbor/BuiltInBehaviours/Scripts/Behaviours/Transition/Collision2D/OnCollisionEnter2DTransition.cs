using UnityEngine;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// OnCollisionEnter2Dが呼ばれたときにステートを遷移する。
	/// </summary>
#else
	/// <summary>
	/// It will transition the state when the OnCollisionEnter2D is called.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transition/Collision2D/OnCollisionEnter2DTransition")]
	[BuiltInBehaviour]
	public sealed class OnCollisionEnter2DTransition : StateBehaviour
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
		/// Collision2Dの出力。
		/// </summary>
#else
		/// <summary>
		/// Collision2D output.
		/// </summary>
#endif
		[SerializeField] private OutputSlotCollision2D _Collision2D = new OutputSlotCollision2D();

#if ARBOR_DOC_JA
		/// <summary>
		/// 遷移先ステート。<br />
		/// 遷移メソッド : OnCollisionEnter2D
		/// </summary>
#else
		/// <summary>
		/// Transition destination state.<br />
		/// Transition Method : OnCollisionEnter2D
		/// </summary>
#endif
		[SerializeField] private StateLink _NextState = new StateLink();

		#endregion // Serialize fields

		void OnCollisionEnter2D( Collision2D collision )
		{
			if( !enabled )
			{
				return;
			}

			if( !_IsCheckTag || _Tag == collision.gameObject.tag )
			{
				_Collision2D.SetValue(collision);
				Transition ( _NextState );
			}
		}
	}
}
