using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.BehaviourTree.Decorators
{
#if ARBOR_DOC_JA
	/// <summary>
	/// ノードに入ったタイミングから指定時間経過すると失敗を返す。
	/// </summary>
#else
	/// <summary>
	/// When a specified time elapses from the timing of entering the node, it returns failure.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("TimeLimit")]
	[BuiltInBehaviour]
	public class TimeLimit : Decorator 
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
		/// タイムリミットの秒数
		/// </summary>
#else
		/// <summary>
		/// Time limit in seconds
		/// </summary>
#endif
		[SerializeField]
		private FlexibleFloat _Seconds = new FlexibleFloat();

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

		private float _BeginTime;
		private float _DurationTime;

		protected override void OnStart() 
		{
			_BeginTime = currentTime;
			_DurationTime = _Seconds.value;
		}

		protected override bool OnConditionCheck() 
		{
			return elapsedTime <= _DurationTime;
		}
	}
}