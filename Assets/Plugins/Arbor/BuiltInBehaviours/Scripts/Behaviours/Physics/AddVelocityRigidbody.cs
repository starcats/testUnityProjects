using UnityEngine;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Rigidbodyのvelocityを加算する。
	/// </summary>
#else
	/// <summary>
	/// It will add the velocity of Rigidbody.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Physics/AddVelocityRigidbody")]
	[BuiltInBehaviour]
	public sealed class AddVelocityRigidbody : StateBehaviour
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 対象となるRigidbody。<br/>
		/// TypeがConstantの時に指定しない場合、ArborFSMを割り当ててあるGameObjectのRigidbody。
		/// </summary>
#else
		/// <summary>
		/// Rigidbody of interest.<br/>
		/// If Type is Constant and nothing is specified, Rigidbody of GameObject to which ArborFSM is assigned.
		/// </summary>
#endif
		[SerializeField]
		private FlexibleRigidbody _Target = new FlexibleRigidbody();

#if ARBOR_DOC_JA
		/// <summary>
		/// 前方向を基準とした各軸の角度。
		/// </summary>
#else
		/// <summary>
		/// Angle of each axis with reference to the front direction.
		/// </summary>
#endif
		[SerializeField] private Vector3 _Angle = Vector3.zero;

#if ARBOR_DOC_JA
		/// <summary>
		/// 加える速さ。
		/// </summary>
#else
		/// <summary>
		/// Speed added.
		/// </summary>
#endif
		[SerializeField] private float _Speed = 0f;

#if ARBOR_DOC_JA
		/// <summary>
		/// 速度を加える空間。
		/// </summary>
#else
		/// <summary>
		/// Space to add velocity.
		/// </summary>
#endif
		[SerializeField]
		private Space _Space = Space.Self;

		#endregion // Serialize fields

		private Rigidbody _MyRigidbody;
		public Rigidbody cachedTarget
		{
			get
			{
				Rigidbody rb = _Target.value;
				if( rb == null && _Target.type == FlexibleType.Constant )
				{
					if( _MyRigidbody == null )
					{
						_MyRigidbody = GetComponent<Rigidbody>();
					}

					rb = _MyRigidbody;
				}
				return rb;
			}
		}

		// Use this for enter state
		public override void OnStateBegin()
		{
			Rigidbody target = cachedTarget;
			if ( target != null)
			{
				Vector3 direction = Quaternion.Euler(_Angle) * (_Space == Space.Self ? target.transform.forward : Vector3.forward);
				target.velocity += direction.normalized * _Speed;
            }
		}
	}
}
