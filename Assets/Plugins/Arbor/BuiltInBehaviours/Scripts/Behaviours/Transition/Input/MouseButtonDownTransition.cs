using UnityEngine;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// マウスボタンが押されたときにステートを遷移する。
	/// </summary>
#else
	/// <summary>
	/// It will transition the state when the mouse button is pressed.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transition/Input/MouseButtonDownTransition")]
	[BuiltInBehaviour]
	public sealed class MouseButtonDownTransition : StateBehaviour
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// マウスボタンの指定。
		/// </summary>
#else
		/// <summary>
		/// Specified mouse button.
		/// </summary>
#endif
		[SerializeField] private int _Button = 0;

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
			if( Input.GetMouseButtonDown( _Button ) )
			{
				Transition( _NextState );
			}
		}
	}
}
