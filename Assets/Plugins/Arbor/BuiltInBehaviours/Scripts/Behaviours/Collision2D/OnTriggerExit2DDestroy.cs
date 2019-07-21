using UnityEngine;
using System.Collections;

using Arbor.ObjectPooling;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// OnTriggerExit2Dが呼ばれた際に、相手のGameObjectを破棄する。
	/// </summary>
#else
	/// <summary>
	/// When OnTriggerExit2D is called, it will destroy an opponent GameObject.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Collision2D/OnTriggerExit2DDestroy")]
	[BuiltInBehaviour]
	public sealed class OnTriggerExit2DDestroy : StateBehaviour
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

		#endregion // Serialize fields

		void OnTriggerExit2D(Collider2D collider)
		{
			if (!enabled)
			{
				return;
			}

			if (!_IsCheckTag || collider.tag == _Tag)
			{
				ObjectPool.Destroy(collider.gameObject);
			}
		}
	}
}
