using UnityEngine;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// OnTriggerExit2Dが呼び出された際、相手のGameObjectをパラメータに格納します。
	/// </summary>
#else
	/// <summary>
	/// When OnTriggerExit2D is called, it will store an opponent GameObject to the parameter.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Collision2D/OnTriggerExit2DStore")]
	[BuiltInBehaviour]
	public sealed class OnTriggerExit2DStore : StateBehaviour
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
		/// 格納先のパラメータ
		/// </summary>
#else
		/// <summary>
		/// Storage destination parameters
		/// </summary>
#endif
		[SerializeField]
		private GameObjectParameterReference _Parameter = new GameObjectParameterReference();

		#endregion // Serialize fields

		void OnTriggerExit2D(Collider2D collider)
		{
			if (!enabled)
			{
				return;
			}

			if (!_IsCheckTag || collider.tag == _Tag)
			{
				if (_Parameter.parameter != null)
				{
					_Parameter.parameter.gameObjectValue = collider.gameObject;
                }
			}
		}
	}
}
