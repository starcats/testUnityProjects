using UnityEngine;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// キーが押されているかでステートを遷移する。
	/// </summary>
#else
	/// <summary>
	/// It will transition the state on whether is Key pressed.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transition/Input/KeyTransition")]
	[BuiltInBehaviour]
	public sealed class KeyTransition : StateBehaviour
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
			if( Input.GetKey( _KeyCode ) )
			{
				Transition( _NextState );
			}
		}
	}
}
