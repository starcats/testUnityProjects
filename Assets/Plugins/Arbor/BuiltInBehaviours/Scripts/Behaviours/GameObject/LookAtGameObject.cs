using UnityEngine;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// 指定したTransformを注視する。
	/// </summary>
#else
	/// <summary>
	/// We will watch the specified Transform.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("GameObject/LookAtGameObject")]
	[BuiltInBehaviour]
	public sealed class LookAtGameObject : StateBehaviour
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 注視するTransform。<br/>
		/// TypeがConstantの時に指定しない場合、ArborFSMがアタッチされているGameObjectのTransformとなる。
		/// </summary>
#else
		/// <summary>
		/// The gaze to Transform.<br/>
		/// If Type is Constant and nothing is specified, ArborFSM is the Transform of the attached GameObject.
		/// </summary>
#endif
		[SerializeField] private FlexibleTransform _Transform = new FlexibleTransform();

#if ARBOR_DOC_JA
		/// <summary>
		/// 注視先のTransform。
		/// </summary>
#else
		/// <summary>
		/// Gaze destination of Transform.
		/// </summary>
#endif
		[SerializeField] private FlexibleTransform _Target = new FlexibleTransform();

#if ARBOR_DOC_JA
		/// <summary>
		/// 注視先TransformのX座標を使用するかどうか。
		/// </summary>
#else
		/// <summary>
		/// Whether to use the X position of the target Transform.
		/// </summary>
#endif
		[SerializeField] private bool _UsePositionX = true;

#if ARBOR_DOC_JA
		/// <summary>
		/// 注視先TransformのY座標を使用するかどうか。
		/// </summary>
#else
		/// <summary>
		/// Whether to use the Y position of the target Transform.
		/// </summary>
#endif
		[SerializeField] private bool _UsePositionY = true;

#if ARBOR_DOC_JA
		/// <summary>
		/// 注視先TransformのZ座標を使用するかどうか。
		/// </summary>
#else
		/// <summary>
		/// Whether to use the Z position of the target Transform.
		/// </summary>
#endif
		[SerializeField] private bool _UsePositionZ = true;

#if ARBOR_DOC_JA
		/// <summary>
		/// LateUpdateの時に適用するかどうか。
		/// </summary>
#else
		/// <summary>
		/// Whether to apply at the time of the LateUpdate.
		/// </summary>
#endif
		[SerializeField] private bool _ApplyLateUpdate = false;

		#endregion // Serialize fields

		public Transform target
		{
			get
			{
				return _Target.value;
			}
		}

		private Transform _MyTransform;
		public Transform cachedTransform
		{
			get
			{
				Transform t = _Transform.value;

				if ( t == null && _Transform.type == FlexibleType.Constant )
				{
					if( _MyTransform == null )
					{
						_MyTransform = transform;
					}

					t = _MyTransform;
				}
				return t;
			}
		}

		void LookAt()
		{
			Transform t = cachedTransform;
			if ( t != null && target != null)
			{
				Vector3 position = target.position;
				if (!_UsePositionX)
				{
					position.x = t.position.x;
				}
				if (!_UsePositionY)
				{
					position.y = t.position.y;
				}
				if (!_UsePositionZ)
				{
					position.z = t.position.z;
				}
				t.LookAt(position);
			}
		}

		// Use this for enter state
		public override void OnStateBegin()
		{
			LookAt();
        }

		void LateUpdate()
		{
			if (_ApplyLateUpdate)
			{
				LookAt();
			}
		}
	}
}
