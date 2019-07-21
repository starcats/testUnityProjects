using UnityEngine;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// なんらかのキーが押されているかでステートを遷移する。
	/// </summary>
#else
	/// <summary>
	/// It will transition the state on whether any key is pressed.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transition/Input/AnyKeyTransition")]
	[BuiltInBehaviour]
	public sealed class AnyKeyTransition : StateBehaviour
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 押している状態を判定するかどうか。<br/>
		/// チェックを外すと、入力がない場合に遷移する。
		/// </summary>
#else
		/// <summary>
		/// Whether to judge the pressed state or not.<br/>
		/// When unchecked, it transits when there is no input.
		/// </summary>
#endif
		[SerializeField] private bool _CheckOn = true;

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
			if( Input.anyKey == _CheckOn )
			{
				Transition ( _NextState );
			}	
		}
	}
}
