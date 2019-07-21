using UnityEngine;
using System.Collections.Generic;
using System.Reflection;

namespace Arbor.StateMachine.StateBehaviours
{
	using Arbor.Events;

#if ARBOR_DOC_JA
	/// <summary>
	/// Componentのメソッドを呼び出す。
	/// </summary>
#else
	/// <summary>
	/// Call the method of Component.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Component/InvokeMethod")]
	[BuiltInBehaviour]
	public class InvokeMethod : StateBehaviour
	{
#if ARBOR_DOC_JA
		/// <summary>
		/// OnStateAwakeの時のメソッド呼び出し
		/// </summary>
#else
		/// <summary>
		/// Method call at OnStateAwake
		/// </summary>
#endif
		[SerializeField]
		private ArborEvent _OnStateAwake = new ArborEvent();

#if ARBOR_DOC_JA
		/// <summary>
		/// OnStateBeginの時のメソッド呼び出し
		/// </summary>
#else
		/// <summary>
		/// Method call at OnStateBegin
		/// </summary>
#endif
		[SerializeField]
		private ArborEvent _OnStateBegin = new ArborEvent();

#if ARBOR_DOC_JA
		/// <summary>
		/// OnStateEndの時のメソッド呼び出し
		/// </summary>
#else
		/// <summary>
		/// Method call at OnStateEnd
		/// </summary>
#endif
		[SerializeField]
		private ArborEvent _OnStateEnd = new ArborEvent();

		void Awake()
		{
			LogWarning();
		}

		public override void OnStateAwake()
		{
			_OnStateAwake.Invoke();
		}

		public override void OnStateBegin()
		{
			_OnStateBegin.Invoke();
		}

		public override void OnStateEnd()
		{
			_OnStateEnd.Invoke();
		}

		[System.Diagnostics.Conditional("UNITY_EDITOR")]
		void LogWarning()
		{
			string warningMessage = _OnStateAwake.warningMessage;
			if (!string.IsNullOrEmpty(warningMessage))
			{
				Debug.LogWarningFormat(nodeGraph, "[{0} OnStateAwake Event]\n{1}", this, warningMessage);
			}

			warningMessage = _OnStateBegin.warningMessage;
			if (!string.IsNullOrEmpty(warningMessage))
			{
				Debug.LogWarningFormat(nodeGraph, "[{0} OnStateBegin Event]\n{1}", this, warningMessage);
			}

			warningMessage = _OnStateEnd.warningMessage;
			if (!string.IsNullOrEmpty(warningMessage))
			{
				Debug.LogWarningFormat(nodeGraph, "[{0} OnStateEnd Event]\n{1}", this, warningMessage);
			}
		}
	}
}