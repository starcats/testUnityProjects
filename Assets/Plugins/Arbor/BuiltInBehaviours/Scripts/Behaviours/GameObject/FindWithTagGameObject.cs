using UnityEngine;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// GameObjectをタグで検索してパラメータに格納する。
	/// </summary>
#else
	/// <summary>
	/// GameObject the searches in the tag and then stored in the parameter.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("GameObject/FindWithTagGameObject")]
	[BuiltInBehaviour]
	public sealed class FindWithTagGameObject : StateBehaviour
	{
		#region Serialize fields

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
		private GameObjectParameterReference _Reference = new GameObjectParameterReference();

#if ARBOR_DOC_JA
		/// <summary>
		/// GameObjectを出力。
		/// </summary>
#else
		/// <summary>
		/// Output GameObject
		/// </summary>
#endif
		[SerializeField]
		private OutputSlotGameObject _Output = new OutputSlotGameObject();

#if ARBOR_DOC_JA
		/// <summary>
		/// 検索するタグ
		/// </summary>
#else
		/// <summary>
		/// Search tag
		/// </summary>
#endif
		[SerializeField]
		private string _Tag = "Untagged";

		#endregion // Serialize fields

		public override void OnStateBegin()
		{
			GameObject findObject = GameObject.FindWithTag( _Tag );

			_Output.SetValue( findObject );

			if (_Reference.parameter != null)
			{
				_Reference.parameter.gameObjectValue = findObject;
            }
		}
	}
}
