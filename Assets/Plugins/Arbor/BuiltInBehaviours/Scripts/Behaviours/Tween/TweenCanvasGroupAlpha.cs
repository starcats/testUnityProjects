﻿using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// CanvasGroupのAlphaを徐々に変化させる。
	/// </summary>
#else
	/// <summary>
	/// Gradually change Alpha of Canvas Group.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Tween/TweenCanvasGroupAlpha")]
	[BuiltInBehaviour]
	public sealed class TweenCanvasGroupAlpha : TweenBase
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 対象となるCanvasGroup。<br/>
		/// 指定しない場合は、ArborFSMが割り当てられているGameObjectのCanvasGroup。
		/// </summary>
#else
		/// <summary>
		/// CanvasGroup of interest.<br/>
		/// If not specified, CanvasGroup of GameObject that ArborFSM is assigned a target.
		/// </summary>
#endif
		[SerializeField]
		[SlotType(typeof(CanvasGroup))]
		private FlexibleComponent _Target = new FlexibleComponent();

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
		private TweenMoveType _TweenMoveType = TweenMoveType.Absolute;

#if ARBOR_DOC_JA
		/// <summary>
		/// 開始アルファ。
		/// </summary>
#else
		/// <summary>
		/// Start alpha.
		/// </summary>
#endif
		[SerializeField]
		private FlexibleFloat _From = new FlexibleFloat();

#if ARBOR_DOC_JA
		/// <summary>
		/// 目標アルファ。
		/// </summary>
#else
		/// <summary>
		/// Target alpha.
		/// </summary>
#endif
		[SerializeField]
		private FlexibleFloat _To = new FlexibleFloat();

		[SerializeField]
		[HideInInspector]
		private int _SerializeVersion = 0;

		#region old

		[SerializeField]
		[FormerlySerializedAs("_Target")]
		[HideInInspector]
		private CanvasGroup _OldTarget = null;

		[SerializeField, FormerlySerializedAs( "_From" )]
		[HideInInspector]
		private float _OldFrom = 0f;

		[SerializeField, FormerlySerializedAs( "_To" )]
		[HideInInspector]
		private float _OldTo = 0f;

		#endregion // old

		#endregion // Serialize fields

		private CanvasGroup _MyCanvasGroup;

		private CanvasGroup _CachedTarget;

		private float _CachedFromValue;
		private float _CachedToValue;
		
		void SerializeVer1()
		{
			_From = (FlexibleFloat)_OldFrom;
			_To = (FlexibleFloat)_OldTo;
		}

		void SerializeVer2()
		{
			_Target = (FlexibleComponent)_OldTarget;
		}

		private const int _CurrentSerializeVersion = 2;

		void Serialize()
		{
			while (_SerializeVersion != _CurrentSerializeVersion)
			{
				switch (_SerializeVersion)
				{
					case 0:
						SerializeVer1();
						_SerializeVersion++;
						break;
					case 1:
						SerializeVer2();
						_SerializeVersion++;
						break;
					default:
						_SerializeVersion = _CurrentSerializeVersion;
						break;
				}
			}
		}

		public override void OnBeforeSerialize()
		{
			base.OnBeforeSerialize();

			Serialize();
		}

		public override void OnAfterDeserialize()
		{
			base.OnAfterDeserialize();

			Serialize();
		}

		protected override void OnTweenBegin()
		{
			_CachedTarget = _Target.value as CanvasGroup;
			if (_CachedTarget == null && _Target.type == FlexibleType.Constant)
			{
				if (_MyCanvasGroup == null)
				{
					_MyCanvasGroup = GetComponent<CanvasGroup>();
				}

				_CachedTarget = _MyCanvasGroup;
			}

			if (_CachedTarget == null)
			{
				return;
			}

			_CachedFromValue = _From.value;
			_CachedToValue = _To.value;

			float startAlpha = _CachedTarget.alpha;

			switch (_TweenMoveType)
			{
				case TweenMoveType.Absolute:
					break;
				case TweenMoveType.Relative:
					_CachedFromValue += startAlpha;
					_CachedToValue += startAlpha;
					break;
				case TweenMoveType.ToAbsolute:
					_CachedFromValue = startAlpha;
					break;
			}
		}

		protected override void OnTweenUpdate(float factor)
		{
			if (_CachedTarget != null)
			{
				_CachedTarget.alpha = Mathf.Lerp(_CachedFromValue, _CachedToValue, factor);
			}
		}
	}
}
