using UnityEngine;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Rigidbody2Dのvelocityを加算する。
	/// </summary>
#else
	/// <summary>
	/// It will add the velocity of Rigidbody2D.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Physics2D/AddVelocityRigidbody2D")]
	[BuiltInBehaviour]
	public sealed class AddVelocityRigidbody2D : StateBehaviour
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 対象となるRigidbody2D。<br/>
		/// TypeがConstantの時に指定しない場合、ArborFSMを割り当ててあるGameObjectのRigidbody2D。
		/// </summary>
#else
		/// <summary>
		/// Rigidbody2D of interest.<br/>
		/// If Type is Constant and nothing is specified, Rigidbody2D of GameObject to which ArborFSM is assigned.
		/// </summary>
#endif
		[SerializeField]
		private FlexibleRigidbody2D _Target = new FlexibleRigidbody2D();

#if ARBOR_DOC_JA
		/// <summary>
		/// 上方向を基準とした角度。
		/// </summary>
#else
		/// <summary>
		/// Angle with reference to the upward direction.
		/// </summary>
#endif
		[SerializeField] private float _Angle = 0f;

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

		private Rigidbody2D _MyRigidbody2D;
		public Rigidbody2D cachedTarget
		{
			get
			{
				Rigidbody2D rb2d = _Target.value;
				if( rb2d == null && _Target.type == FlexibleType.Constant )
				{
					if( _MyRigidbody2D == null )
					{
						_MyRigidbody2D = GetComponent<Rigidbody2D>();
					}

					rb2d = _MyRigidbody2D;
				}
				return rb2d;
			}
		}

		// Use this for enter state
		public override void OnStateBegin()
		{
			Rigidbody2D target = cachedTarget;
			if ( target != null)
			{
				Vector2 direction = Quaternion.Euler(0.0f, 0.0f, _Angle) * (_Space == Space.Self ? (Vector2)target.transform.up : Vector2.up);
				target.velocity += direction.normalized * _Speed;
            }
		}
	}
}
