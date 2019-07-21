using UnityEngine;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// OnCollisionStayが呼ばれたときにステートを遷移する。
	/// </summary>
#else
	/// <summary>
	/// It will transition the state when the OnCollisionStay is called.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transition/Collision/OnCollisionStayTransition")]
	[BuiltInBehaviour]
	public sealed class OnCollisionStayTransition : StateBehaviour
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
		[SerializeField]
		private bool _IsCheckTag = false;

#if ARBOR_DOC_JA
		/// <summary>
		/// チェックするタグ。
		/// </summary>
#else
		/// <summary>
		/// Tag to be checked.
		/// </summary>
#endif
		[SerializeField]
		private string _Tag = "Untagged";

#if ARBOR_DOC_JA
		/// <summary>
		/// Collisionの出力。
		/// </summary>
#else
		/// <summary>
		/// Collision output.
		/// </summary>
#endif
		[SerializeField]
		private OutputSlotCollision _Collision = new OutputSlotCollision();

#if ARBOR_DOC_JA
		/// <summary>
		/// 遷移先ステート。<br />
		/// 遷移メソッド : OnCollisionStay
		/// </summary>
#else
		/// <summary>
		/// Transition destination state.<br />
		/// Transition Method : OnCollisionStay
		/// </summary>
#endif
		[SerializeField]
		private StateLink _NextState = new StateLink();

		#endregion // Serialize fields

		void OnCollisionStay(Collision collision)
		{
			if (!enabled)
			{
				return;
			}

			if (!_IsCheckTag || collision.gameObject.tag == _Tag)
			{
				_Collision.SetValue(collision);
				Transition(_NextState);
			}
		}
	}
}
