﻿using UnityEngine;
using UnityEngine.Serialization;
#if UNITY_5_5_OR_NEWER
using UnityEngine.AI;
#endif
using System.Collections;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// NavMeshAgentをラップしたAI用移動コンポーネント。<br />
	/// 主に組み込みBehaviourのAgentを介して使用する。
	/// </summary>
#else
	/// <summary>
	/// AI for the movement component that wraps the NavMeshAgent.<br />
	/// Used mainly through built-in Behavior's Agent.
	/// </summary>
#endif
	[AddComponentMenu("Arbor/AgentController",40)]
	[BuiltInComponent]
	[HelpURL( ArborReferenceUtility.componentUrl + "agentcontroller.html")]
	public sealed class AgentController : MonoBehaviour , ISerializationCallbackReceiver
	{
		enum Status
		{
			Stopping,
			Moving,
			Rotating,
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 移動ベクトルのタイプ
		/// </summary>
#else
		/// <summary>
		/// Type of movement vector
		/// </summary>
#endif
		[Internal.Documentable]
		public enum MovementType
		{
#if ARBOR_DOC_JA
			/// <summary>
			/// NavMeshAgent.velocityの値をそのまま使用する。
			/// </summary>
#else
			/// <summary>
			/// Use the value of NavMeshAgent.velocity as it is.
			/// </summary>
#endif
			NotChange,

#if ARBOR_DOC_JA
			/// <summary>
			/// NavMeshAgent.velocityを正規化した値を使用する。
			/// </summary>
#else
			/// <summary>
			/// Use the normalized value of NavMeshAgent.velocity.
			/// </summary>
#endif
			Normalize,

#if ARBOR_DOC_JA
			/// <summary>
			/// NavMeshAgent.velocityをNavMeshAgent.speedで割った値を使用する。
			/// </summary>
#else
			/// <summary>
			/// Use the value obtained by dividing NavMeshAgent.velocity by NavMeshAgent.speed.
			/// </summary>
#endif
			DivSpeed,

#if ARBOR_DOC_JA
			/// <summary>
			/// NavMeshAgent.velocityをMovementDivValueで割った値を使用する。
			/// </summary>
#else
			/// <summary>
			/// Use the value obtained by dividing NavMeshAgent.velocity by MovementDivValue.
			/// </summary>
#endif
			DivValue,
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// Turnのタイプ
		/// </summary>
#else
		/// <summary>
		/// Type of Turn
		/// </summary>
#endif
		[Internal.Documentable]
		public enum TurnType
		{
#if ARBOR_DOC_JA
			/// <summary>
			/// 向きベクトルのX値を使う。
			/// </summary>
#else
			/// <summary>
			/// Use the X value of the orientation vector.
			/// </summary>
#endif
			UseX,

#if ARBOR_DOC_JA
			/// <summary>
			/// 向きベクトルのXZ値からラジアン角を計算する。
			/// </summary>
#else
			/// <summary>
			/// Calculate the radian angle from the XZ value of the direction vector.
			/// </summary>
#endif
			RadianAngle,
		}

		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 制御したいNavMeshAgent。
		/// </summary>
#else
		/// <summary>
		/// NavMeshAgent you want to control.
		/// </summary>
#endif
		[SerializeField] private NavMeshAgent _Agent;

#if ARBOR_DOC_JA
		/// <summary>
		/// 制御したいAnimator。
		/// </summary>
#else
		/// <summary>
		/// Animator you want to control.
		/// </summary>
#endif
		[SerializeField] private Animator _Animator;

#if ARBOR_DOC_JA
		/// <summary>
		/// Agentが移動中かどうかをAnimatorへ設定するためのboolパラメータを指定する。
		/// </summary>
#else
		/// <summary>
		/// Specify the bool parameter for setting to the Animator whether or not the Agent is moving.
		/// </summary>
#endif
		[SerializeField] private string _MovingParameter = string.Empty;

#if ARBOR_DOC_JA
		/// <summary>
		/// 移動中と判定する速度の閾値
		/// </summary>
#else
		/// <summary>
		/// Threshold value of the speed of moving
		/// </summary>
#endif
		[SerializeField] private float _MovingSpeedThreshold = 0f;

#if ARBOR_DOC_JA
		/// <summary>
		/// 移動速度をAnimatorへ設定するためのfloatパラメータを指定する。
		/// </summary>
#else
		/// <summary>
		/// Specify the float parameter for setting the moving speed to Animator.
		/// </summary>
#endif
		[SerializeField] private string _SpeedParameter = string.Empty;

#if ARBOR_DOC_JA
		/// <summary>
		/// Agentに設定しているspeedで割るかどうか。
		/// </summary>
#else
		/// <summary>
		/// Whether or not to divide by the speed set for Agent.
		/// </summary>
#endif
		[SerializeField] private bool _IsDivAgentSpeed = false;

#if ARBOR_DOC_JA
		/// <summary>
		/// 移動速度のダンプ時間。
		/// </summary>
#else
		/// <summary>
		/// Dump time of moving speed.
		/// </summary>
#endif
		[SerializeField] private float _SpeedDampTime = 0.0f;

#if ARBOR_DOC_JA
		/// <summary>
		/// 移動ベクトルのタイプ。
		/// </summary>
#else
		/// <summary>
		/// Type of movement vector.
		/// </summary>
#endif
		[SerializeField]
		private MovementType _MovementType = MovementType.Normalize;

#if ARBOR_DOC_JA
		/// <summary>
		/// velocityに対して割る値。(_MovementTypeがMovementType.DivValueの時のみ使用)
		/// </summary>
		/// <remarks>0を指定した場合は無効。</remarks>
#else
		/// <summary>
		/// The value to divide for velocity. (Used only when _MovementType is MovementType.DivValue)
		/// </summary>
		/// <remarks>Disable If you specify 0.</remarks>
#endif
		[SerializeField]
		private float _MovementDivValue = 1.0f;

#if ARBOR_DOC_JA
		/// <summary>
		/// Agentのローカル空間での移動ベクトルのX値をAnimatorへ設定ためのfloatパラメータを指定する。
		/// </summary>
#else
		/// <summary>
		/// Specify the float parameter for setting the X value of the moving vector in the Agent's local space to Animator.
		/// </summary>
#endif
		[SerializeField] private string _MovementXParameter = string.Empty;

#if ARBOR_DOC_JA
		/// <summary>
		/// 移動方向ベクトルのX値のダンプ時間。
		/// </summary>
#else
		/// <summary>
		/// Dump time of X value of moving direction vector.
		/// </summary>
#endif
		[SerializeField] private float _MovementXDampTime = 0.0f;

#if ARBOR_DOC_JA
		/// <summary>
		/// Agentのローカル空間での移動方向ベクトルのY値をAnimatorへ設定ためのfloatパラメータを指定する。
		/// </summary>
#else
		/// <summary>
		/// Specify the float parameter for setting the Y value of the moving direction vector in the Agent's local space to Animator.
		/// </summary>
#endif
		[SerializeField] private string _MovementYParameter = string.Empty;

#if ARBOR_DOC_JA
		/// <summary>
		/// 移動方向ベクトルのY値のダンプ時間。
		/// </summary>
#else
		/// <summary>
		/// Dump time of Y value of moving direction vector.
		/// </summary>
#endif
		[SerializeField] private float _MovementYDampTime = 0.0f;
		
#if ARBOR_DOC_JA
		/// <summary>
		/// Agentのローカル空間での移動方向ベクトルのZ値をAnimatorへ設定ためのfloatパラメータを指定する。
		/// </summary>
#else
		/// <summary>
		/// Specify the float parameter for setting the Z value of the moving direction vector in the Agent's local space to Animator.
		/// </summary>
#endif
		[SerializeField] private string _MovementZParameter = string.Empty;

#if ARBOR_DOC_JA
		/// <summary>
		/// 移動方向ベクトルのZ値のダンプ時間。
		/// </summary>
#else
		/// <summary>
		/// Dump time of Z value of moving direction vector.
		/// </summary>
#endif
		[SerializeField] private float _MovementZDampTime = 0.0f;

#if ARBOR_DOC_JA
		/// <summary>
		/// ターン方向をAnimatorへ設定するためのfloatパラメータを指定する。
		/// </summary>
#else
		/// <summary>
		/// Specify the float parameter for setting the turn direction to Animator.
		/// </summary>
#endif
		[SerializeField] private string _TurnParameter = string.Empty;

#if ARBOR_DOC_JA
		/// <summary>
		/// Turnのタイプ
		/// </summary>
#else
		/// <summary>
		/// Type of Turn.
		/// </summary>
#endif
		[SerializeField]
		private TurnType _TurnType = TurnType.RadianAngle;

#if ARBOR_DOC_JA
		/// <summary>
		/// ターン方向のダンプ時間。
		/// </summary>
#else
		/// <summary>
		/// Dump time in the turn direction.
		/// </summary>
#endif
		[SerializeField] private float _TurnDampTime = 0.0f;

		[HideInInspector]
		[SerializeField]
		private int _SerializeVersion = 0;

		[FormerlySerializedAs("_SpeedParameter")]
		[HideInInspector]
		[SerializeField]
		private AnimatorFloatParameterReference _SpeedParameterOld = new AnimatorFloatParameterReference();

		#endregion // Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 制御したいNavMeshAgent。
		/// </summary>
#else
		/// <summary>
		/// NavMeshAgent you want to control.
		/// </summary>
#endif
		public NavMeshAgent agent
		{
			get
			{
				return _Agent;
			}
			set
			{
				_Agent = value;
				if (_Agent != null)
				{
					_Transform = _Agent.transform;
				}
				else
				{
					_Transform = null;
				}
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 制御したいAnimator。
		/// </summary>
#else
		/// <summary>
		/// Animator you want to control.
		/// </summary>
#endif
		public Animator animator
		{
			get
			{
				return _Animator;
			}
			set
			{
				_Animator = animator;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// Agentが移動中かどうかをAnimatorへ設定するためのboolパラメータを指定する。
		/// </summary>
#else
		/// <summary>
		/// Specify the bool parameter for setting to the Animator whether or not the Agent is moving.
		/// </summary>
#endif
		public string movingParameter
		{
			get
			{
				return _MovingParameter;
			}
			set
			{
				_MovingParameter = value;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 移動中と判定する速度の閾値
		/// </summary>
#else
		/// <summary>
		/// Threshold value of the speed of moving
		/// </summary>
#endif
		public float movingSpeedThreshold
		{
			get
			{
				return _MovingSpeedThreshold;
			}
			set
			{
				_MovingSpeedThreshold = value;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 移動速度をAnimatorへ設定するためのfloatパラメータを指定する。
		/// </summary>
#else
		/// <summary>
		/// Specify the float parameter for setting the moving speed to Animator.
		/// </summary>
#endif
		public string speedParameter
		{
			get
			{
				return _SpeedParameter;
			}
			set
			{
				_SpeedParameter = value;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// Agentに設定しているspeedで割るかどうか。
		/// </summary>
#else
		/// <summary>
		/// Whether or not to divide by the speed set for Agent.
		/// </summary>
#endif
		public bool isDivAgentSpeed
		{
			get
			{
				return _IsDivAgentSpeed;
			}
			set
			{
				_IsDivAgentSpeed = value;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 移動速度のダンプ時間。
		/// </summary>
#else
		/// <summary>
		/// Dump time of moving speed.
		/// </summary>
#endif
		public float speedDampTime
		{
			get
			{
				return _SpeedDampTime;
			}
			set
			{
				_SpeedDampTime = value;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 移動ベクトルのタイプ。
		/// </summary>
#else
		/// <summary>
		/// Type of movement vector.
		/// </summary>
#endif
		public MovementType movementType
		{
			get
			{
				return _MovementType;
			}
			set
			{
				_MovementType = value;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// velocityに対して割る値。(_MovementTypeがMovementType.DivValueの時のみ使用)
		/// </summary>
		/// <remarks>0を指定した場合は無効。</remarks>
#else
		/// <summary>
		/// The value to divide for velocity. (Used only when _MovementType is MovementType.DivValue)
		/// </summary>
		/// <remarks>Disable If you specify 0.</remarks>
#endif
		public float movementDivValue
		{
			get
			{
				return _MovementDivValue;
			}
			set
			{
				_MovementDivValue = value;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// Agentのローカル空間での移動ベクトルのX値をAnimatorへ設定ためのfloatパラメータを指定する。
		/// </summary>
#else
		/// <summary>
		/// Specify the float parameter for setting the X value of the moving vector in the Agent's local space to Animator.
		/// </summary>
#endif
		public string movementXParameter
		{
			get
			{
				return _MovementXParameter;
			}
			set
			{
				_MovementXParameter = value;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 移動方向ベクトルのX値のダンプ時間。
		/// </summary>
#else
		/// <summary>
		/// Dump time of X value of moving direction vector.
		/// </summary>
#endif
		public float movementXDampTime
		{
			get
			{
				return _MovementXDampTime;
			}
			set
			{
				_MovementXDampTime = value;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// Agentのローカル空間での移動方向ベクトルのY値をAnimatorへ設定ためのfloatパラメータを指定する。
		/// </summary>
#else
		/// <summary>
		/// Specify the float parameter for setting the Y value of the moving direction vector in the Agent's local space to Animator.
		/// </summary>
#endif
		public string movementYParameter
		{
			get
			{
				return _MovementYParameter;
			}
			set
			{
				_MovementYParameter = value;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 移動方向ベクトルのY値のダンプ時間。
		/// </summary>
#else
		/// <summary>
		/// Dump time of Y value of moving direction vector.
		/// </summary>
#endif
		public float movementYDampTime
		{
			get
			{
				return _MovementYDampTime;
			}
			set
			{
				_MovementYDampTime = value;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// Agentのローカル空間での移動方向ベクトルのZ値をAnimatorへ設定ためのfloatパラメータを指定する。
		/// </summary>
#else
		/// <summary>
		/// Specify the float parameter for setting the Z value of the moving direction vector in the Agent's local space to Animator.
		/// </summary>
#endif
		public string movementZParameter
		{
			get
			{
				return _MovementZParameter;
			}
			set
			{
				_MovementZParameter = value;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 移動方向ベクトルのZ値のダンプ時間。
		/// </summary>
#else
		/// <summary>
		/// Dump time of Z value of moving direction vector.
		/// </summary>
#endif
		public float movementZDampTime
		{
			get
			{
				return _MovementZDampTime;
			}
			set
			{
				_MovementZDampTime = value;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// ターン方向をAnimatorへ設定するためのfloatパラメータを指定する。
		/// </summary>
#else
		/// <summary>
		/// Specify the float parameter for setting the turn direction to Animator.
		/// </summary>
#endif
		public string turnParameter
		{
			get
			{
				return _TurnParameter;
			}
			set
			{
				_TurnParameter = value;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// Turnのタイプ
		/// </summary>
#else
		/// <summary>
		/// Type of Turn.
		/// </summary>
#endif
		public TurnType turnType
		{
			get
			{
				return _TurnType;
			}
			set
			{
				_TurnType = value;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// ターン方向のダンプ時間。
		/// </summary>
#else
		/// <summary>
		/// Dump time in the turn direction.
		/// </summary>
#endif
		public float turnDampTime
		{
			get
			{
				return _TurnDampTime;
			}
			set
			{
				_TurnDampTime = value;
			}
		}

		public Transform agentTransform
		{
			get
			{
				return _Transform;
			}
		}

		private Vector3 _StartPosition;

#if ARBOR_DOC_JA
		/// <summary>
		/// 移動完了したかどうか。
		/// </summary>
#else
		/// <summary>
		/// Whether the move is complete or not.
		/// </summary>
#endif
		public bool isDone
		{
			get
			{
				switch (_Status)
				{
					case Status.Stopping:
						return true;
					case Status.Moving:
						return !_Agent.pathPending && (_Agent.remainingDistance <= _Agent.stoppingDistance || Mathf.Approximately(_Agent.remainingDistance, _Agent.stoppingDistance)) && !(_Agent.hasPath && isMoving);
					case Status.Rotating:
						{
							float angle = Quaternion.Angle(_LookRotation, _Transform.rotation);
							return angle <= 0.1f;
						}
				}
				return true;
			}
		}

		private Status _Status = Status.Stopping;

		private Transform _Transform;

		private bool _IsMoving = false;

		private Vector3 _Direction = Vector3.zero;
		private Quaternion _LookRotation = Quaternion.identity;
		private float _AngularSpeed = 0.0f;
		
		private float GetFloat(string name)
		{
			if (_Animator != null && !string.IsNullOrEmpty(name) )
			{
				return _Animator.GetFloat(name);
			}
			return 0.0f;
		}

		private void SetFloat(string name, float value)
		{
			if (_Animator != null && !string.IsNullOrEmpty(name))
			{
				_Animator.SetFloat(name, value);
			}
		}

		private void SetBool(string name, bool value)
		{
			if (_Animator != null && !string.IsNullOrEmpty(name))
			{
				_Animator.SetBool(name, value);
			}
		}

		private void SetFloat(string name, float value, float dampTime, float deltaTime)
		{
			if (_Animator != null && !string.IsNullOrEmpty(name))
			{
				_Animator.SetFloat(name,value,dampTime,deltaTime);
			}
		}

		private bool IsMovingAnimator()
		{
			return Mathf.Abs(GetFloat(_SpeedParameter)) >= 0.01f ||
				Mathf.Abs(GetFloat(_MovementXParameter)) >= 0.01f ||
				Mathf.Abs(GetFloat(_MovementYParameter)) >= 0.01f ||
				Mathf.Abs(GetFloat(_MovementZParameter)) >= 0.01f ||
				Mathf.Abs(GetFloat(_TurnParameter)) >= 0.01f;
		}

		private bool IsMoving()
		{
			return _Status == Status.Moving && (!Mathf.Approximately(_Agent.velocity.magnitude, 0.0f) || IsMovingAnimator());
		}

		public bool isMoving
		{
			get
			{
				return _IsMoving;
			}
		}

		void Awake()
		{
			if (_Agent == null)
			{
				_Agent = GetComponent<NavMeshAgent>();
			}

			_Transform = _Agent.transform;
			_StartPosition = _Transform.position;
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 指定半径内をうろつく
		/// </summary>
		/// <param name="center">中心</param>
		/// <param name="speed">移動速度</param>
		/// <param name="radius">開始位置からの半径</param>
#else
		/// <summary>
		/// Wander within specified radius
		/// </summary>
		/// <param name="center">Center</param>
		/// <param name="speed">Movement speed</param>
		/// <param name="radius">Radius from the starting position</param>
#endif
		public void Patrol(Vector3 center,float speed, float radius)
		{
			float angle = Random.Range(-180.0f, 180.0f);

			Vector3 axis = Vector3.up;

			Quaternion rotate = Quaternion.AngleAxis(angle, axis);

			Vector3 dir = rotate * Vector3.forward * Random.Range(0.0f, radius);

			_Agent.speed = speed;
			_Agent.stoppingDistance = 0.0f;
			_Agent.SetDestination(center + dir);
			_Status = Status.Moving;
			Resume();
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 開始位置から指定半径内をうろつく
		/// </summary>
		/// <param name="speed">移動速度</param>
		/// <param name="radius">開始位置からの半径</param>
#else
		/// <summary>
		/// Wander within the specified radius from the start position
		/// </summary>
		/// <param name="speed">Movement speed</param>
		/// <param name="radius">Radius from the starting position</param>
#endif
		public void Patrol(float speed, float radius)
		{
			Patrol(_StartPosition, speed, radius);
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 指定した位置へ近づく
		/// </summary>
		/// <param name="speed">移動速度</param>
		/// <param name="stoppingDistance">停止距離</param>
		/// <param name="targetPosition">目標地点</param>
#else
		/// <summary>
		/// It approaches the specified position
		/// </summary>
		/// <param name="speed">Movement speed</param>
		/// <param name="stoppingDistance">Stopping distance</param>
		/// <param name="targetPosition">Objective point</param>
#endif
		public void Follow(float speed, float stoppingDistance, Vector3 targetPosition)
		{
			_Agent.speed = speed;
			_Agent.stoppingDistance = stoppingDistance;
			_Agent.SetDestination(targetPosition);
			_Status = Status.Moving;
			Resume();
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 指定したTransformの位置へ近づく
		/// </summary>
		/// <param name="speed">移動速度</param>
		/// <param name="stoppingDistance">停止距離</param>
		/// <param name="target">目標地点</param>
#else
		/// <summary>
		/// Approach to the position of the specified Transform
		/// </summary>
		/// <param name="speed">Movement speed</param>
		/// <param name="stoppingDistance">Stopping distance</param>
		/// <param name="target">Objective point</param>
#endif
		public void Follow(float speed, float stoppingDistance, Transform target)
		{
			if( target == null )
			{
				return;
			}
			Follow(speed, stoppingDistance, target.position);
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 指定した位置から遠ざかる
		/// </summary>
		/// <param name="speed">移動速度</param>
		/// <param name="distance">遠ざかる距離</param>
		/// <param name="targetPosition">対象</param>
#else
		/// <summary>
		/// Keep away from specified position
		/// </summary>
		/// <param name="speed">Movement speed</param>
		/// <param name="distance">Distance away</param>
		/// <param name="targetPosition">Target</param>
#endif
		public void Escape(float speed, float distance, Vector3 targetPosition)
		{
			Vector3 dir = _Transform.position - targetPosition;

			if (dir.magnitude >= distance)
			{
				return;
			}

			Vector3 pos = dir.normalized * distance + targetPosition;

			_Agent.speed = speed;
			_Agent.stoppingDistance = 0.0f;
			if (!_Agent.SetDestination(pos))
			{
				pos = -dir.normalized * distance + _Transform.position;

				_Agent.SetDestination(pos);
			}
			_Status = Status.Moving;
			Resume();
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 指定したTransformから遠ざかる
		/// </summary>
		/// <param name="speed">移動速度</param>
		/// <param name="distance">遠ざかる距離</param>
		/// <param name="target">対象</param>
#else
		/// <summary>
		/// Away from the specified Transform
		/// </summary>
		/// <param name="speed">Movement speed</param>
		/// <param name="distance">Distance away</param>
		/// <param name="target">Target</param>
#endif
		public void Escape(float speed, float distance, Transform target)
		{
			if( target == null )
			{
				return;
			}

			Escape(speed, distance, target.position);
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 指定した位置の方向へ回転する。
		/// </summary>
		/// <param name="angularSpeed">角速度</param>
		/// <param name="targetPosition">対象</param>
#else
		/// <summary>
		/// Rotate in the direction of the specified position.
		/// </summary>
		/// <param name="angularSpeed">angular speed</param>
		/// <param name="targetPosition">Target</param>
#endif
		public void LookAt(float angularSpeed, Vector3 targetPosition)
		{
			Stop();

			_AngularSpeed = angularSpeed;

			Vector3 direction = (targetPosition - _Transform.position);
			if (Mathf.Approximately(direction.sqrMagnitude, 0.0f))
			{
				_Direction = _Transform.forward;
			}
			else
			{
				_Direction = direction.normalized;
			}

			_Direction.y = 0f;
			_LookRotation = Quaternion.LookRotation(_Direction);
			
			_Status = Status.Rotating;
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 指定したTransformの方向へ回転する。
		/// </summary>
		/// <param name="angularSpeed">角速度</param>
		/// <param name="target">対象</param>
#else
		/// <summary>
		/// Rotates in the direction of the specified Transform.
		/// </summary>
		/// <param name="angularSpeed">angular speed</param>
		/// <param name="target">Target</param>
#endif
		public void LookAt(float angularSpeed, Transform target)
		{
			if (target == null)
			{
				return;
			}

			LookAt(angularSpeed, target.position);
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 移動を再開する。
		/// </summary>
#else
		/// <summary>
		/// Resume movement.
		/// </summary>
#endif
		public void Resume()
		{
#if UNITY_5_6_OR_NEWER
			_Agent.isStopped = false;
#else
			_Agent.Resume();
#endif
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 停止する。
		/// </summary>
#else
		/// <summary>
		/// Stop.
		/// </summary>
#endif
		public void Stop()
		{
			_Status = Status.Stopping;

#if UNITY_5_6_OR_NEWER
			_Agent.isStopped = true;
#else
			_Agent.Stop();
#endif
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 指定された位置にエージェントをワープします。
		/// </summary>
		/// <param name="newPosition">エージェントをワープさせる位置</param>
		/// <returns>経路の割り当てに成功した場合 true</returns>
#else
		/// <summary>
		/// Warps agent to the provided position.
		/// </summary>
		/// <param name="newPosition">New position to warp the agent to.</param>
		/// <returns>True if agent is successfully warped, otherwise false.</returns>
#endif
		public bool Warp(Vector3 newPosition)
		{
			return _Agent.Warp(newPosition);
		}
		
		void Update()
		{
			bool currentMoving = IsMoving();
			if (_IsMoving != currentMoving)
			{
				_IsMoving = currentMoving;

				if (!_IsMoving)
				{
					if (_Animator != null)
					{
						SetBool(_MovingParameter, false);
						SetFloat(_SpeedParameter, 0.0f);
						SetFloat(_MovementXParameter, 0.0f);
						SetFloat(_MovementYParameter, 0.0f);
						SetFloat(_MovementZParameter, 0.0f);
						SetFloat(_TurnParameter, 0.0f);
					}
				}
			}

			float deltaTime = Time.deltaTime;

			if (_IsMoving)
			{
				Vector3 velocity = _Agent.desiredVelocity;

				float speed = velocity.magnitude;

				bool moving = speed > _MovingSpeedThreshold;

				float agentSpeed = _Agent.speed;

				if (_IsDivAgentSpeed && agentSpeed != 0.0f)
				{
					speed /= agentSpeed;
				}

				velocity = _Transform.InverseTransformDirection(velocity);

				Vector3 movement = Vector3.zero;

				switch (_MovementType)
				{
					case MovementType.NotChange:
						movement = velocity;
						break;
					case MovementType.Normalize:
						movement = velocity.normalized;
						break;
					case MovementType.DivSpeed:
						if (agentSpeed != 0.0f)
						{
							movement = velocity / agentSpeed;
						}
						break;
					case MovementType.DivValue:
						if (_MovementDivValue != 0.0f)
						{
							movement = velocity / _MovementDivValue;
						}
						break;
				}

				velocity.Normalize();

				float turn = 0.0f;
				switch (_TurnType)
				{
					case TurnType.UseX:
						turn = velocity.x;
						break;
					case TurnType.RadianAngle:
						turn = Mathf.Atan2(velocity.x, velocity.z);
						break;
				}

				if (_Animator != null)
				{
					SetBool(_MovingParameter, moving);
					SetFloat(_SpeedParameter, speed, _SpeedDampTime, deltaTime);
					SetFloat(_MovementXParameter, movement.x, _MovementXDampTime, deltaTime);
					SetFloat(_MovementYParameter, movement.y, _MovementYDampTime, deltaTime);
					SetFloat(_MovementZParameter, movement.z, _MovementZDampTime, deltaTime);
					SetFloat(_TurnParameter, turn, _TurnDampTime, deltaTime);
				}
			}

			if (_Status == Status.Rotating)
			{
				_Transform.rotation = Quaternion.RotateTowards(_Transform.rotation, _LookRotation, Time.deltaTime * _AngularSpeed);

				Vector3 direction = _Transform.InverseTransformDirection(_Direction);

				float turn = 0.0f;
				switch (_TurnType)
				{
					case TurnType.UseX:
						turn = direction.x;
						break;
					case TurnType.RadianAngle:
						turn = Mathf.Atan2(direction.x, direction.z);
						break;
				}

				if (_Animator != null)
				{
					_Animator.SetFloat(_TurnParameter, turn, _TurnDampTime, deltaTime);
				}
			}
		}

		void SerializeVer1()
		{
			_Animator = _SpeedParameterOld.animator;
			_SpeedParameter = _SpeedParameterOld.name;
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
			if (_SerializeVersion == 0)
			{
				SerializeVer1();
				_SerializeVersion = 1;
			}
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			if (_SerializeVersion == 0)
			{
				SerializeVer1();
			}
		}
	}
}
