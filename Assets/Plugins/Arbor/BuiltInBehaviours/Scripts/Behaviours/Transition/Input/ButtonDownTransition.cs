using UnityEngine;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// ボタンが押されたときにステートを遷移する。
	/// </summary>
#else
	/// <summary>
	/// It will transition the state when the button is pressed.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transition/Input/ButtonDownTransition")]
	[BuiltInBehaviour]
	public sealed class ButtonDownTransition : StateBehaviour
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// ボタンの名前。
		/// </summary>
#else
		/// <summary>
		/// The name of the button.
		/// </summary>
#endif
		[SerializeField] private string _ButtonName = "Fire1";

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
			if( Input.GetButtonDown( _ButtonName ) )
			{
				Transition( _NextState );
			}	
		}
	}
}
