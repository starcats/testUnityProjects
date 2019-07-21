using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.BehaviourTree.Decorators
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Cooldownが追加されているノードが終了したタイミングから指定時間経過後に再度アクティブにする
	/// </summary>
#else
	/// <summary>
	/// Reactivate again after the specified time has elapsed from the timing when Cooldown is exited from the added node.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Cooldown")]
	[BuiltInBehaviour]
	public class Cooldown : Decorator
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
		/// クールダウンの秒数
		/// </summary>
#else
		/// <summary>
		/// Cool down seconds
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

		protected override bool OnConditionCheck()
		{
			if (!treeNode.isActive)
			{
				return elapsedTime >= _DurationTime;
			}

			return true;
		}

		protected override void OnEnd()
		{
			_BeginTime = TimeUtility.CurrentTime(_TimeType);
			_DurationTime = _Seconds.value;
		}
	}
}