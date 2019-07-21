using UnityEngine;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Rigidbodyに力を加える。
	/// </summary>
#else
	/// <summary>
	/// We will apply a force to Rigidbody.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Physics/AddForceRigidbody")]
	[BuiltInBehaviour]
	public sealed class AddForceRigidbody : StateBehaviour
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
		[SerializeField] private FlexibleRigidbody _Target = new FlexibleRigidbody();

#if ARBOR_DOC_JA
		/// <summary>
		///前方向を基準とした各軸の角度。
		/// </summary>
#else
		/// <summary>
		/// Angle of each axis with reference to the front direction.
		/// </summary>
#endif
		[SerializeField]
		private Vector3 _Angle = Vector3.zero;

#if ARBOR_DOC_JA
		/// <summary>
		/// 加える力。
		/// </summary>
#else
		/// <summary>
		/// Force applied.
		/// </summary>
#endif
		[SerializeField]
		private float _Power = 0f;

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
		private ForceMode _ForceMode = ForceMode.Force;

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
				Vector3 force = Quaternion.Euler(_Angle) * Vector3.forward * _Power;
				switch (_Space)
				{
					case Space.World:
						target.AddForce(force, _ForceMode);
						break;
					case Space.Self:
						target.AddRelativeForce(force, _ForceMode);
						break;
				}
				
			}
		}
	}
}
