using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Rigidbody2Dの位置を徐々に変化させる。
	/// </summary>
#else
	/// <summary>
	/// Gradually change position of Rigidbody2D.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Tween/TweenRigidbody2DPosition")]
	[BuiltInBehaviour]
	public sealed class TweenRigidbody2DPosition : TweenBase{
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
		private FlexibleVector2 _From = new FlexibleVector2();

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
		private FlexibleVector2 _To = new FlexibleVector2();

		[SerializeField]
		[HideInInspector]
		private int _SerializeVersion;

		#region old

		[SerializeField, FormerlySerializedAs( "_Target" )]
		[HideInInspector]
		private Rigidbody2D _OldTarget = null;

		[SerializeField, FormerlySerializedAs( "_From" )]
		[HideInInspector]
		private Vector2 _OldFrom = Vector2.zero;

		[SerializeField, FormerlySerializedAs( "_To" )]
		[HideInInspector]
		private Vector2 _OldTo = Vector2.zero;

		#endregion // old

		#endregion // Serialize fields

		void SerializeVer1()
		{
			_Target = (FlexibleRigidbody2D)_OldTarget;
			_From = (FlexibleVector2)_OldFrom;
			_To = (FlexibleVector2)_OldTo;
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

		Rigidbody2D _MyRigidbody2D;
		Rigidbody2D _CachedTarget;

		private Vector2 _CachedFromValue;
		private Vector2 _CachedToValue;
		
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
				if (_MyRigidbody2D == null)
				{
					_MyRigidbody2D = GetComponent<Rigidbody2D>();
				}

				_CachedTarget = _MyRigidbody2D;
			}

			if (_CachedTarget == null)
			{
				return;
			}

			_CachedFromValue = _From.value;
			_CachedToValue = _To.value;

			Vector2 startPosition = _CachedTarget.position;

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
				_CachedTarget.MovePosition(Vector2.Lerp(_CachedFromValue, _CachedToValue, factor));
			}
		}
	}
}
