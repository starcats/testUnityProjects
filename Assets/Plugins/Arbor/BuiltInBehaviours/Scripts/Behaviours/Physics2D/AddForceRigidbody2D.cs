using UnityEngine;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Rigidbody2Dに力を加える。
	/// </summary>
#else
	/// <summary>
	/// We will apply a force to Rigidbody2D.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Physics2D/AddForceRigidbody2D")]
	[BuiltInBehaviour]
	public sealed class AddForceRigidbody2D : StateBehaviour
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
		[SerializeField] private FlexibleRigidbody2D _Target = new FlexibleRigidbody2D();

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
		/// 加える力。
		/// </summary>
#else
		/// <summary>
		/// Force applied.
		/// </summary>
#endif
		[SerializeField] private float _Power = 0f;

#if ARBOR_DOC_JA
		/// <summary>
		/// 力を適用する方法のためのオプション。
		/// </summary>
#else
		/// <summary>
		/// Option for how to apply a force.
		/// </summary>
#endif
		[SerializeField]
		private ForceMode2D _ForceMode = ForceMode2D.Force;

#if ARBOR_DOC_JA
		/// <summary>
		/// 力を適用する空間。
		/// </summary>
#else
		/// <summary>
		/// Space to apply force.
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
				Vector2 force = Quaternion.Euler(0.0f, 0.0f, _Angle) * Vector2.up * _Power;
				switch (_Space)
				{
					case Space.Self:
						target.AddRelativeForce(force, _ForceMode);
						break;
					case Space.World:
						target.AddForce(force, _ForceMode);
						break;
				}
            }
		}
	}
}
