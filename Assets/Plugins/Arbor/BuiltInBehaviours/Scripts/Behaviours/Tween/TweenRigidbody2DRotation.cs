using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Rigidbody2Dの向きを徐々に変化させる。
	/// </summary>
#else
	/// <summary>
	/// Gradually change rotaion of Rigidbody2D.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Tween/TweenRigidbody2DRotation")]
	[BuiltInBehaviour]
	public sealed class TweenRigidbody2DRotation : TweenBase
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
		/// 開始向き。
		/// </summary>
#else
		/// <summary>
		/// Start orientation.
		/// </summary>
#endif
		[SerializeField]
		private FlexibleFloat _From = new FlexibleFloat();

#if ARBOR_DOC_JA
		/// <summary>
		/// 目標向き。
		/// </summary>
#else
		/// <summary>
		/// Goal orientation.
		/// </summary>
#endif
		[SerializeField]
		private FlexibleFloat _To = new FlexibleFloat();

		[SerializeField]
		[HideInInspector]
		private int _SerializeVersion;

		#region old

		[SerializeField, FormerlySerializedAs( "_Target" )]
		[HideInInspector]
		private Rigidbody2D _OldTarget = null;

		[SerializeField, FormerlySerializedAs( "_From" )]
		[HideInInspector]
		private float _OldFrom = 0f;

		[SerializeField, FormerlySerializedAs( "_To" )]
		[HideInInspector]
		private float _OldTo = 0f;

		#endregion // old

		#endregion // Serialize fields

		void SerializeVer1()
		{
			_Target = (FlexibleRigidbody2D)_OldTarget;
			_From = (FlexibleFloat)_OldFrom;
			_To = (FlexibleFloat)_OldTo;
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

		private float _CachedFromValue;
		private float _CachedToValue;
		
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

			float startRotation = _CachedTarget.rotation;

			switch (_TweenMoveType)
			{
				case TweenMoveType.Absolute:
					break;
				case TweenMoveType.Relative:
					_CachedFromValue += startRotation;
					_CachedToValue += startRotation;
					break;
				case TweenMoveType.ToAbsolute:
					_CachedFromValue = startRotation;
					break;
			}
		}

		protected override void OnTweenUpdate (float factor)
		{
			if (_CachedTarget != null)
			{
				_CachedTarget.MoveRotation(Mathf.Lerp(_CachedFromValue, _CachedToValue, factor));
			}
		}
	}
}
