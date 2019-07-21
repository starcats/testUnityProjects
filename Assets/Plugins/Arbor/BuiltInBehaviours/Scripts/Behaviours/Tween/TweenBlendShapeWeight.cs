using UnityEngine;
using System.Collections.Generic;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// BlendShapeのWeight値を徐々に変化させる。
	/// </summary>
#else
	/// <summary>
	/// Tween Weight value of BlendShape.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Tween/TweenBlendShapeWeight")]
	[BuiltInBehaviour]
	public sealed class TweenBlendShapeWeight : TweenBase
	{
		[Arbor.Internal.Documentable]
		[System.Serializable]
		public class BlendShape
		{
			#region Serialize fields

#if ARBOR_DOC_JA
			/// <summary>
			/// 対象となるSkinnedMeshRenderer。<br/>
			/// 指定しない場合は、ArborFSMと同じGameObjectに割り当てられているSkinnedMeshRenderer。
			/// </summary>
#else
			/// <summary>
			/// SkinnedMeshRenderer of interest.<br/>
			/// If not specified, SkinnedMeshRenderer of GameObject that ArborFSM is assigned a target.
			/// </summary>
#endif
			[SerializeField]
			[SlotType(typeof(SkinnedMeshRenderer))]
			private FlexibleComponent _Target = new FlexibleComponent();

#if ARBOR_DOC_JA
			/// <summary>
			/// BlendShapeの名前。
			/// </summary>
#else
			/// <summary>
			/// Name of blend shape.
			/// </summary>
#endif
			[SerializeField] private FlexibleString _Name = new FlexibleString();

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
			/// 開始値。
			/// </summary>
#else
			/// <summary>
			/// Start value.
			/// </summary>
#endif
			[SerializeField] private FlexibleFloat _From = new FlexibleFloat(0.0f);

#if ARBOR_DOC_JA
			/// <summary>
			/// 目標値。
			/// </summary>
#else
			/// <summary>
			/// The goal value.
			/// </summary>
#endif
			[SerializeField] private FlexibleFloat _To = new FlexibleFloat(0.0f);

			#endregion // Serialize fields

			private SkinnedMeshRenderer _CachedTarget;
			private int _CachedIndex;
			private float _CachedFromValue;
			private float _CachedToValue;

			public void OnBegin(SkinnedMeshRenderer myRenderer)
			{
				_CachedTarget = _Target.value as SkinnedMeshRenderer;
				if (_CachedTarget == null && _Target.type == FlexibleType.Constant)
				{
					_CachedTarget = myRenderer;
				}

				if (_CachedTarget == null)
				{
					return;
				}

				Mesh sharedMesh = _CachedTarget.sharedMesh;
				if (sharedMesh == null)
				{
					return;
				}

				_CachedIndex = sharedMesh.GetBlendShapeIndex(_Name.value);

				if (_CachedIndex < 0)
				{
					return;
				}

				_CachedFromValue = _From.value;
				_CachedToValue = _To.value;

				float startWeight = _CachedTarget.GetBlendShapeWeight(_CachedIndex);

				switch (_TweenMoveType)
				{
					case TweenMoveType.Absolute:
						break;
					case TweenMoveType.Relative:
						_CachedFromValue += startWeight;
						_CachedToValue += startWeight;
						break;
					case TweenMoveType.ToAbsolute:
						_CachedFromValue = startWeight;
						break;
				}
			}

			public void OnUpdate(float factor)
			{
				if (_CachedTarget == null || _CachedIndex < 0)
				{
					return;
				}

				float weight = Mathf.Lerp(_CachedFromValue, _CachedToValue, factor);
				_CachedTarget.SetBlendShapeWeight(_CachedIndex, weight);
			}
		}

		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 対象のBlendShape
		/// </summary>
#else
		/// <summary>
		/// Target BlendShapes
		/// </summary>
#endif
		[SerializeField]
		private List<BlendShape> _BlendShapes = new List<BlendShape>();

#endregion // Serialize fields

		private SkinnedMeshRenderer _MyRenderer;

		protected override void OnTweenBegin()
		{
			if (_MyRenderer == null)
			{
				_MyRenderer = GetComponent<SkinnedMeshRenderer>();
			}

			for (int i = 0, count = _BlendShapes.Count; i < count; i++)
			{
				_BlendShapes[i].OnBegin(_MyRenderer);
			}
		}

		protected override void OnTweenUpdate(float factor)
		{
			for (int i = 0, count = _BlendShapes.Count; i < count; i++)
			{
				_BlendShapes[i].OnUpdate(factor);
			}
		}
	}
}
