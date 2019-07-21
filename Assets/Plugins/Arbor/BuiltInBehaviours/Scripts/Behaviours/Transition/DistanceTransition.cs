using UnityEngine;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// 対象のGameObjectとの距離によってステートを遷移する。
	/// </summary>
#else
	/// <summary>
	/// It will transition the state by the distance between the target of GameObject.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transition/DistanceTransition")]
	[BuiltInBehaviour]
	public sealed class DistanceTransition : StateBehaviour
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 比較対象のTransform。
		/// </summary>
#else
		/// <summary>
		/// Transform to be compared.
		/// </summary>
#endif
		[SerializeField] private FlexibleTransform _Target = new FlexibleTransform();

#if ARBOR_DOC_JA
		/// <summary>
		/// Targetとの距離。
		/// </summary>
#else
		/// <summary>
		/// The distance between the Target.
		/// </summary>
#endif
		[SerializeField] private float _Distance = 0f;

#if ARBOR_DOC_JA
		/// <summary>
		/// Distanceよりも近い場合の遷移先ステート。<br />
		/// 遷移メソッド : OnStateUpdate
		/// </summary>
#else
		/// <summary>
		/// Transition destination state if it is closer than the Distance.<br />
		/// Transition Method : OnStateUpdate
		/// </summary>
#endif
		[SerializeField] private StateLink _NearState = new StateLink();

#if ARBOR_DOC_JA
		/// <summary>
		/// Distanceよりも遠い場合の遷移先ステート。<br />
		/// 遷移メソッド : OnStateUpdate
		/// </summary>
#else
		/// <summary>
		/// Transition destination state if it is farther away than the Distance.<br />
		/// Transition Method : OnStateUpdate
		/// </summary>
#endif
		[SerializeField] private StateLink _FarState = new StateLink();

		#endregion // Serialize fields

		Transform _Transform;

		void Start()
		{
			_Transform = transform;
		}

		public override void OnStateUpdate() 
		{
			if( _Target.value == null )
			{
				return;
			}

			float distance = (_Transform.position- _Target.value.position).sqrMagnitude;

			if( distance <= _Distance * _Distance )
			{
				Transition( _NearState );
			}
			else
			{
				Transition( _FarState );
			}
		}
	}
}
