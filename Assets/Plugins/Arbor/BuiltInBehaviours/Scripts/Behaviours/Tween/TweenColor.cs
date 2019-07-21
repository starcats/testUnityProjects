using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Rendererの色を徐々に変化させる。
	/// </summary>
#else
	/// <summary>
	/// Gradually change color of Renderer.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Tween/TweenColor")]
	[BuiltInBehaviour]
	public sealed class TweenColor : TweenBase
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 対象となるRenderer。<br/>
		/// 指定しない場合は、ArborFSMと同じGameObjectに割り当てられているRenderer。
		/// </summary>
#else
		/// <summary>
		/// Renderer of interest.<br/>
		/// If not specified, Renderer of GameObject that ArborFSM is assigned a target.
		/// </summary>
#endif
		[SerializeField]
		[SlotType(typeof(Renderer))]
		private FlexibleComponent _Target = new FlexibleComponent();

#if ARBOR_DOC_JA
		/// <summary>
		/// Colorのプロパティ名。
		/// </summary>
#else
		/// <summary>
		/// Property name of Color.
		/// </summary>
#endif
		[SerializeField]
		private FlexibleString _PropertyName = new FlexibleString("_Color");

#if ARBOR_DOC_JA
		/// <summary>
		/// 色の変化の指定。
		/// </summary>
#else
		/// <summary>
		/// Specifying the color change.
		/// </summary>
#endif
		[SerializeField] private FlexibleGradient _Gradient = new FlexibleGradient(new Gradient());

		[SerializeField]
		[HideInInspector]
		private int _SerializeVersion;

		#region old

		[SerializeField]
		[FormerlySerializedAs("_Target")]
		[HideInInspector]
		private Renderer _OldTarget = null;

		[SerializeField]
		[FormerlySerializedAs("_Gradient")]
		[HideInInspector]
		private Gradient _OldGradient = new Gradient();

		#endregion // old

		#endregion // Serialize fields

		private const int kCurrentSerializeVersion = 2;

		private Gradient _CurrentGradient;

		private Renderer _MyRenderer;
		private Renderer _CachedTarget;

		private string _CachedPropertyName;
		
		private MaterialPropertyBlock _Block = null;

		protected override void OnTweenBegin()
		{
			base.OnTweenBegin();

			_CachedTarget = _Target.value as Renderer;
			if (_CachedTarget == null && _Target.type == FlexibleType.Constant)
			{
				if (_MyRenderer == null)
				{
					_MyRenderer = GetComponent<Renderer>();
				}

				_CachedTarget = _MyRenderer;
			}

			if (_CachedTarget == null)
			{
				return;
			}

			_CachedPropertyName = _PropertyName.value;

			if (_Block == null)
			{
				_Block = new MaterialPropertyBlock();
			}
			
			_CachedTarget.GetPropertyBlock(_Block);
			
			_CurrentGradient = _Gradient.value;
			if (_CurrentGradient == null)
			{
				_CurrentGradient = new Gradient();
			}
		}

		protected override void OnTweenUpdate (float factor)
		{
			if(_CachedTarget != null)
			{
				if (_Block == null)
				{
					_Block = new MaterialPropertyBlock();
				}

				_Block.SetColor(_CachedPropertyName, _CurrentGradient.Evaluate(factor));

				_CachedTarget.SetPropertyBlock(_Block);
			}
		}

		void SerializeVer1()
		{
			_Target = (FlexibleComponent)_OldTarget;
		}

		void SerializeVer2()
		{
			_Gradient = (FlexibleGradient)_OldGradient;
		}

		void Serialize()
		{
			while (_SerializeVersion != kCurrentSerializeVersion)
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
						_SerializeVersion = kCurrentSerializeVersion;
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
	}
}
