using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// 時間経過後にステートを遷移する。
	/// </summary>
#else
	/// <summary>
	/// It will transition the state after the lapse of time.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transition/TimeTransition")]
	[BuiltInBehaviour]
	public sealed class TimeTransition : StateBehaviour, INodeBehaviourSerializationCallbackReceiver
	{
		#region Serialize fields

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
		public TimeType _TimeType = TimeType.Normal;

#if ARBOR_DOC_JA
		/// <summary>
		/// 遷移するまでの秒数。
		/// </summary>
#else
		/// <summary>
		/// The number of seconds until the transition.
		/// </summary>
#endif
		[SerializeField] public FlexibleFloat _Seconds = new FlexibleFloat(0.0f);

#if ARBOR_DOC_JA
		/// <summary>
		/// 遷移先ステート。<br />
		/// 遷移メソッド : OnStateUpdate
		/// </summary>
#else
		/// <summary>
		/// Transition destination state.<br />
		/// Transition Method : OnStateUpdate
		/// </summary>
#endif
		[SerializeField] private StateLink _NextState = new StateLink();

		[SerializeField]
		[HideInInspector]
		private int _SerializeVersion = 0;

		#region old

		[FormerlySerializedAs("_Seconds")]
		[SerializeField]
		[HideInInspector]
		private float _OldSeconds = 0;

		#endregion

		#endregion // Serialize fields

		float _BeginTime = 0.0f;
		float _Duration = 0.0f;

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
				return _Duration;
			}
		}

		public override void OnStateBegin()
		{
			_BeginTime = currentTime;
			_Duration = _Seconds.value;
		}

		public override void OnStateUpdate()
		{
			if (elapsedTime >= _Duration)
			{
				Transition(_NextState);
			}
		}

		void SerializeVer1()
		{
			_Seconds = (FlexibleFloat)_OldSeconds;
		}

		void INodeBehaviourSerializationCallbackReceiver.OnBeforeSerialize()
		{
			if (_SerializeVersion == 0)
			{
				SerializeVer1();
				_SerializeVersion = 1;
			}
		}

		void INodeBehaviourSerializationCallbackReceiver.OnAfterDeserialize()
		{
			if (_SerializeVersion == 0)
			{
				SerializeVer1();
			}
		}
	}
}
