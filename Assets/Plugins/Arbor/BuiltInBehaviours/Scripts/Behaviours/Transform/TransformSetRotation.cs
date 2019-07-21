using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Transformの回転を設定する。
	/// </summary>
#else
	/// <summary>
	/// Set the rotation of Transform.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transform/TransformSetRotation")]
	[BuiltInBehaviour]
	public class TransformSetRotation : StateBehaviour
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 回転を設定するTransform。<br/>
		/// TypeがConstantの時に指定しない場合、ArborFSMがアタッチされているGameObjectのTransformとなる。
		/// </summary>
#else
		/// <summary>
		/// Transform to set the rotation.<br/>
		/// If Type is Constant and nothing is specified, ArborFSM is the Transform of the attached GameObject.
		/// </summary>
#endif
		[SerializeField]
		private FlexibleTransform _Transform = new FlexibleTransform();

#if ARBOR_DOC_JA
		/// <summary>
		/// 回転の座標空間
		/// </summary>
#else
		/// <summary>
		/// Coordinate space of rotation
		/// </summary>
#endif
		[SerializeField]
		private Space _Space = Space.World;

#if ARBOR_DOC_JA
		/// <summary>
		/// 回転
		/// </summary>
#else
		/// <summary>
		/// Rotation
		/// </summary>
#endif
		[SerializeField]
		private FlexibleVector3 _Rotation = new FlexibleVector3();

		#endregion // Serialize fields

		private Transform _MyTransform;
		public Transform cachedTransform
		{
			get
			{
				Transform t = _Transform.value;

				if (t == null && _Transform.type == FlexibleType.Constant)
				{
					if (_MyTransform == null)
					{
						_MyTransform = transform;
					}

					t = _MyTransform;
				}
				return t;
			}
		}

		// Use this for enter state
		public override void OnStateBegin()
		{
			Quaternion rotation = Quaternion.Euler(_Rotation.value);
			Transform target = cachedTransform;
			if (target != null)
			{
				switch (_Space)
				{
					case Space.World:
						target.rotation = rotation;
						break;
					case Space.Self:
						target.localRotation = rotation;
						break;
				}
			}
		}
	}
}