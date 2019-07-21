using UnityEngine;
using System.Collections;

namespace Arbor.BehaviourTree.Actions
{
#if ARBOR_DOC_JA
	/// <summary>
	/// 時間経過を待つ
	/// </summary>
#else
	/// <summary>
	/// Wait for the passage of time
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Wait")]
	[BuiltInBehaviour]
	public class Wait : ActionBehaviour
	{
#if ARBOR_DOC_JA
		/// <summary>
		/// 時間の種類。
		/// </summary>
#else
		/// <summary>
		/// Type of time.
		/// </summary>
#endif
		[SerializeField]
		private TimeType _TimeType = TimeType.Normal;

#if ARBOR_DOC_JA
		/// <summary>
		/// 待つ秒数
		/// </summary>
#else
		/// <summary>
		/// Number of seconds to wait
		/// </summary>
#endif
		[SerializeField]
		private FlexibleFloat _Seconds = new FlexibleFloat();

		private float _BeginTime;
		private float _DurationTime;

		public float currentTime
		{
			get
			{
				return TimeUtility.CurrentTime(_TimeType);
			}
		}

		public float elapsedTime
		{
			get
			{
				return currentTime - _BeginTime;
			}
		}

		public float duration
		{
			get
			{
				return _DurationTime;
			}
		}

		protected override void OnStart()
		{
			_BeginTime = currentTime;
			_DurationTime = _Seconds.value;
		}

		protected override void OnExecute()
		{
			if (elapsedTime >= _DurationTime)
			{
				FinishExecute(true);
			}
		}
	}
}