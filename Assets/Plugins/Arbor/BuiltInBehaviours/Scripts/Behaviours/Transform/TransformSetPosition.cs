using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Transformの位置を設定する。
	/// </summary>
#else
	/// <summary>
	/// Set the position of Transform.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transform/TransformSetPosition")]
	[BuiltInBehaviour]
	public class TransformSetPosition : StateBehaviour
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 位置を設定するTransform。<br/>
		/// TypeがConstantの時に指定しない場合、ArborFSMがアタッチされているGameObjectのTransformとなる。
		/// </summary>
#else
		/// <summary>
		/// Transform to set the position.<br/>
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
		private Space _Space = Space.World;

#if ARBOR_DOC_JA
		/// <summary>
		/// 位置
		/// </summary>
#else
		/// <summary>
		/// Position
		/// </summary>
#endif
		[SerializeField]
		private FlexibleVector3 _Position = new FlexibleVector3();

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
			Vector3 position = _Position.value;
			Transform target = cachedTransform;
			if (target != null)
			{
				switch (_Space)
				{
					case Space.World:
						target.position = position;
						break;
					case Space.Self:
						target.localPosition = position;
						break;
				}
			}
		}
	}
}