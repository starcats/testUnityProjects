using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Rigidbodyの位置を徐々に変化させる。
	/// </summary>
#else
	/// <summary>
	/// Gradually change position of Rigidbody.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Tween/TweenRigidbodyPosition")]
	[BuiltInBehaviour]
	public sealed class TweenRigidbodyPosition : TweenBase
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 対象となるTransform。<br/>
		/// TypeがConstantの時に指定しない場合、ArborFSMがアタッチされているGameObjectのTransformとなる。
		/// </summary>
#else
		/// <summary>
		/// Transform of interest.<br/>
		/// If Type is Constant and nothing is specified, ArborFSM is the Transform of the attached GameObject.
		/// </summary>
#endif
		[SerializeField]
		private FlexibleRigidbody _Target = new FlexibleRigidbody();

#if ARBOR_DOC_JA
		/// <summary>
		/// 開始した状態からの相対的な変化かどうか。
		/// </summary>
#else
		/// <summary>
		/// Whether the relative change from the start state.
		/// </summary>
#endif
		[SerializeField]
		[FormerlySerializedAs("_Relative")]
		private TweenMoveType _TweenMoveType = TweenMoveType.Absolute;

#if ARBOR_DOC_JA
		/// <summary>
		/// 開始位置。
		/// </summary>
#else
		/// <summary>
		/// Starting position.
		/// </summary>
#endif
		[SerializeField]
		private FlexibleVector3 _From = new FlexibleVector3();

#if ARBOR_DOC_JA
		/// <summary>
		/// 目標位置。
		/// </summary>
#else
		/// <summary>
		/// Target position.
		/// </summary>
#endif
		[SerializeField]
		private FlexibleVector3 _To = new FlexibleVector3();

		[SerializeField]
		[HideInInspector]
		private int _SerializeVersion;

		#region old

		[SerializeField, FormerlySerializedAs( "_Target" )]
		[HideInInspector]
		private Rigidbody _OldTarget = null;

		[SerializeField, FormerlySerializedAs( "_From" )]
		[HideInInspector]
		private Vector3 _OldFrom = Vector3.zero;

		[SerializeField, FormerlySerializedAs( "_To" )]
		[HideInInspector]
		private Vector3 _OldTo = Vector3.zero;

		#endregion // old

		#endregion // Serialize fields

		void SerializeVer1()
		{
			_Target = (FlexibleRigidbody)_OldTarget;
			_From = (FlexibleVector3)_OldFrom;
			_To = (FlexibleVector3)_OldTo;
		}

		public override void OnBeforeSerialize()
		{
			base.OnBeforeSerialize();

			if (_SerializeVersion == 0)
			{
				SerializeVer1();
				_SerializeVersion = 1;
			}
		}

		public override void OnAfterDeserialize()
		{
			base.OnAfterDeserialize();

			if (_SerializeVersion == 0)
			{
				SerializeVer1();
				_SerializeVersion = 1;
			}
		}

		Rigidbody _MyRigidbody;
		Rigidbody _CachedTarget;

		private Vector3 _CachedFromValue;
		private Vector3 _CachedToValue;

		public override bool fixedUpdate
		{
			get
			{
				return true;
			}
		}
		
		protected override void OnTweenBegin()
		{
			_CachedTarget = _Target.value;
			if (_CachedTarget == null && _Target.type == FlexibleType.Constant)
			{
				if (_MyRigidbody == null)
				{
					_MyRigidbody = GetComponent<Rigidbody>();
				}

				_CachedTarget = _MyRigidbody;
			}

			if (_CachedTarget == null)
			{
				return;
			}

			_CachedFromValue = _From.value;
			_CachedToValue = _To.value;

			Vector3 startPosition = _CachedTarget.position;

			switch (_TweenMoveType)
			{
				case TweenMoveType.Absolute:
					break;
				case TweenMoveType.Relative:
					_CachedFromValue += startPosition;
					_CachedToValue += startPosition;
					break;
				case TweenMoveType.ToAbsolute:
					_CachedFromValue = startPosition;
					break;
			}
		}

		protected override void OnTweenUpdate (float factor)
		{
			if (_CachedTarget != null)
			{
				_CachedTarget.MovePosition(Vector3.Lerp(_CachedFromValue, _CachedToValue, factor));
			}
		}
	}
}
