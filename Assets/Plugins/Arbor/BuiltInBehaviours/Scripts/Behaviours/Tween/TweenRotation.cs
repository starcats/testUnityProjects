using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// 向きを徐々に変化させます。
	/// </summary>
#else
	/// <summary>
	/// Gradually change rotaion.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Tween/TweenRotation")]
	[BuiltInBehaviour]
	public sealed class TweenRotation : TweenBase
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
		private FlexibleTransform _Target = new FlexibleTransform();

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
		private FlexibleVector3 _From = new FlexibleVector3();

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
		private FlexibleVector3 _To = new FlexibleVector3();

		[SerializeField]
		[HideInInspector]
		private int _SerializeVersion;

		#region old

		[SerializeField, FormerlySerializedAs( "_Target" )]
		[HideInInspector]
		private Transform _OldTarget = null;

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
			_Target = (FlexibleTransform)_OldTarget;
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

		Transform _MyTransform;
		Transform _CachedTarget;

		private Vector3 _CachedFromValue;
		private Vector3 _CachedToValue;
		
		protected override void OnTweenBegin()
		{
			_CachedTarget = _Target.value;
			if (_CachedTarget == null && _Target.type == FlexibleType.Constant)
			{
				if (_MyTransform == null)
				{
					_MyTransform = GetComponent<Transform>();
				}

				_CachedTarget = _MyTransform;
			}

			if (_CachedTarget == null)
			{
				return;
			}

			_CachedFromValue = _From.value;
			_CachedToValue = _To.value;

			Vector3 startRotation = _CachedTarget.localRotation.eulerAngles;

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
				Vector3 eulerAngles = Vector3.Lerp(_CachedFromValue, _CachedToValue, factor);

				_CachedTarget.localRotation = Quaternion.Euler(eulerAngles);
			}
		}
	}
}
