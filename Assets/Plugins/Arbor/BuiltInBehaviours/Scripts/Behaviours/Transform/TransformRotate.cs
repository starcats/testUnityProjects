using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Transformを回転する。
	/// </summary>
#else
	/// <summary>
	/// Rotate the transform.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transform/TransformRotate")]
	[BuiltInBehaviour]
	public class TransformRotate : StateBehaviour
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 回転するTransform。<br/>
		/// TypeがConstantの時に指定しない場合、ArborFSMがアタッチされているGameObjectのTransformとなる。
		/// </summary>
#else
		/// <summary>
		/// Transform to rotate.<br/>
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
		private Space _Space = Space.Self;

#if ARBOR_DOC_JA
		/// <summary>
		/// 更新メソッドの種類
		/// </summary>
#else
		/// <summary>
		/// Type of update method
		/// </summary>
#endif
		[SerializeField]
		private UpdateMethodType _UpdateMethodType = UpdateMethodType.StateUpdate;

#if ARBOR_DOC_JA
		/// <summary>
		/// 回転速度
		/// </summary>
#else
		/// <summary>
		/// Rotational speed
		/// </summary>
#endif
		[SerializeField]
		private FlexibleVector3 _AngularVelocity = new FlexibleVector3();

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

		void UpdateRotate()
		{
			Transform target = cachedTransform;
			if (target != null)
			{
				Vector3 eulerAngles = _AngularVelocity.value * Time.deltaTime;
				target.Rotate(eulerAngles, _Space);
			}
		}

		private void Update()
		{
			if (_UpdateMethodType != UpdateMethodType.Update)
			{
				return;
			}

			UpdateRotate();
		}

		// OnStateUpdate is called once per frame
		public override void OnStateUpdate()
		{
			if (_UpdateMethodType != UpdateMethodType.StateUpdate)
			{
				return;
			}

			UpdateRotate();
		}
	}
}