using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Transformを移動する。
	/// </summary>
#else
	/// <summary>
	/// Moves the transform.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transform/TransformTranslate")]
	[BuiltInBehaviour]
	public class TransformTranslate : StateBehaviour
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 移動するTransform。<br/>
		/// TypeがConstantの時に指定しない場合、ArborFSMがアタッチされているGameObjectのTransformとなる。
		/// </summary>
#else
		/// <summary>
		/// Transform to move.<br/>
		/// If Type is Constant and nothing is specified, ArborFSM is the Transform of the attached GameObject.
		/// </summary>
#endif
		[SerializeField]
		private FlexibleTransform _Transform = new FlexibleTransform();

#if ARBOR_DOC_JA
		/// <summary>
		/// 位置の座標空間
		/// </summary>
#else
		/// <summary>
		/// Coordinate space of position
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
		/// 移動速度
		/// </summary>
#else
		/// <summary>
		/// Moving Speed
		/// </summary>
#endif
		[SerializeField]
		private FlexibleVector3 _Velocity = new FlexibleVector3();

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

		void UpdateTranslate()
		{
			Transform target = cachedTransform;
			if (target != null)
			{
				Vector3 translation = _Velocity.value * Time.deltaTime;
				target.Translate(translation, _Space);
			}
		}

		private void Update()
		{
			if (_UpdateMethodType != UpdateMethodType.Update)
			{
				return;
			}

			UpdateTranslate();
		}

		// OnStateUpdate is called once per frame
		public override void OnStateUpdate()
		{
			if (_UpdateMethodType != UpdateMethodType.StateUpdate)
			{
				return;
			}

			UpdateTranslate();
		}
	}
}