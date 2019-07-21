using UnityEngine;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// GameObjectを名前で検索してパラメータに格納する。
	/// </summary>
#else
	/// <summary>
	/// GameObject search by the name is then stored in the parameter.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("GameObject/FindGameObject")]
	[BuiltInBehaviour]
	public sealed class FindGameObject : StateBehaviour
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
		/// 検索する名前
		/// </summary>
#else
		/// <summary>
		/// Search for name
		/// </summary>
#endif
		[SerializeField]
		private string _Name = string.Empty;

#endregion // Serialize fields

		public override void OnStateBegin()
		{
			GameObject findObject = GameObject.Find( _Name );

			_Output.SetValue( findObject );

			if (_Reference.parameter != null)
			{
				_Reference.parameter.gameObjectValue = findObject;
            }
		}
	}
}
