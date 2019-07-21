using UnityEngine;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// キーが押されたときにステートを遷移する。
	/// </summary>
#else
	/// <summary>
	/// It will transition the state when a key is pressed.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transition/Input/KeyDownTransition")]
	[BuiltInBehaviour]
	public sealed class KeyDownTransition : StateBehaviour
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// キーの指定。
		/// </summary>
#else
		/// <summary>
		/// Specified key.
		/// </summary>
#endif
		[SerializeField] private KeyCode _KeyCode = KeyCode.None;

#if ARBOR_DOC_JA
		/// <summary>
		/// 遷移先ステート。<br />
		/// 遷移メソッド : Update
		/// </summary>
#else
		/// <summary>
		/// Transition destination state.<br />
		/// Transition Method : Update
		/// </summary>
#endif
		[SerializeField] private StateLink _NextState = new StateLink();

		#endregion // Serialize fields

		// Update is called once per frame
		void Update () 
		{
			if( Input.GetKeyDown( _KeyCode ) )
			{
				Transition( _NextState );
			}
		}
	}
}
