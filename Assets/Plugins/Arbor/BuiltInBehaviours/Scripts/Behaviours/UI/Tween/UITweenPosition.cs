using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// UIの位置を徐々に変化させる。
	/// </summary>
#else
	/// <summary>
	/// Gradually change position of UI.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("UI/Tween/UITweenPosition")]
	[BuiltInBehaviour]
	public sealed class UITweenPosition : TweenBase
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 対象となるRectTransform。<br/>
		/// TypeがConstantの時に指定しない場合、ArborFSMがアタッチされているGameObjectのRectTransformとなる。
		/// </summary>
#else
		/// <summary>
		/// RectTransform of interest.<br/>
		/// If Type is Constant and nothing is specified, ArborFSM is the RectTransform of the attached GameObject.
		/// </summary>
#endif
		[SerializeField] private FlexibleRectTransform _Target = new FlexibleRectTransform();

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
		/// 開始地点。
		/// </summary>
#else
		/// <summary>
		/// Start point.
		/// </summary>
#endif
		[SerializeField] private FlexibleVector2 _From = new FlexibleVector2();

#if ARBOR_DOC_JA
		/// <summary>
		/// 目標地点。
		/// </summary>
#else
		/// <summary>
		/// Target point.
		/// </summary>
#endif
		[SerializeField] private FlexibleVector2 _To = new FlexibleVector2();

		[SerializeField]
		[HideInInspector]
		private int _SerializeVersion;

		#region old

		[SerializeField, FormerlySerializedAs( "_Target" )]
		[HideInInspector]
		private RectTransform _OldTarget = null;

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
			_Target = (FlexibleRectTransform)_OldTarget;
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

		RectTransform _MyTransform;
		RectTransform _CachedTarget;

		private Vector2 _CachedFromValue;
		private Vector2 _CachedToValue;

		protected override void OnTweenBegin()
		{
			_CachedTarget = _Target.value;
			if (_CachedTarget == null && _Target.type == FlexibleType.Constant)
			{
				if (_MyTransform == null)
				{
					_MyTransform = GetComponent<RectTransform>();
				}

				_CachedTarget = _MyTransform;
			}

			if (_CachedTarget == null)
			{
				return;
			}

			_CachedFromValue = _From.value;
			_CachedToValue = _To.value;

			Vector2 startPosition = _CachedTarget.anchoredPosition;

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
			if (_CachedTarget != null )
			{
				_CachedTarget.anchoredPosition = Vector2.Lerp(_CachedFromValue, _CachedToValue, factor);
            }
		}
	}
}
