using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Transformのスケールを設定する。
	/// </summary>
#else
	/// <summary>
	/// Set the scale of Transform.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transform/TransformSetScale")]
	[BuiltInBehaviour]
	public class TransformSetScale : StateBehaviour
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// スケールを設定するTransform。<br/>
		/// TypeがConstantの時に指定しない場合、ArborFSMがアタッチされているGameObjectのTransformとなる。
		/// </summary>
#else
		/// <summary>
		/// Transform to set the scale.<br/>
		/// If Type is Constant and nothing is specified, ArborFSM is the Transform of the attached GameObject.
		/// </summary>
#endif
		[SerializeField]
		private FlexibleTransform _Transform = new FlexibleTransform();

#if ARBOR_DOC_JA
		/// <summary>
		/// スケール
		/// </summary>
#else
		/// <summary>
		/// Scale
		/// </summary>
#endif
		[SerializeField]
		private FlexibleVector3 _Scale = new FlexibleVector3(Vector3.one);

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
			Vector3 scale = _Scale.value;
			Transform target = cachedTransform;
			if (target != null)
			{
				target.localScale = scale;
			}
		}
	}
}