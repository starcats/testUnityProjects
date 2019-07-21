using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// UIの色を徐々に変化させる。
	/// </summary>
#else
	/// <summary>
	/// Gradually change color of UI.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("UI/Tween/UITweenColor")]
	[BuiltInBehaviour]
	public sealed class UITweenColor : TweenBase
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 対象となるGraphic。<br/>
		/// 指定しない場合は、ArborFSMと同じGameObjectに割り当てられているGraphic。
		/// </summary>
#else
		/// <summary>
		/// Graphic of interest.<br/>
		/// If not specified, Graphic of GameObject that ArborFSM is assigned a target.
		/// </summary>
#endif
		[SerializeField]
		[SlotType(typeof(Graphic))]
		private FlexibleComponent _Target = new FlexibleComponent();

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
		private int _SerializeVersion = 0;

		#region old

		[SerializeField]
		[FormerlySerializedAs("_Target")]
		[HideInInspector]
		private Graphic _OldTarget = null;

		[SerializeField]
		[FormerlySerializedAs("_Gradient")]
		[HideInInspector]
		private Gradient _OldGradient = new Gradient();

		#endregion // old

		#endregion // Serialize fields

		private Graphic _MyGraphic;
		private Graphic _CachedTarget;

		private Gradient _CachedGradient;

		private const int _CurrentSerializeVersion = 2;

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
			base.OnTweenBegin();

			_CachedTarget = _Target.value as Graphic;
			if (_CachedTarget == null && _Target.type == FlexibleType.Constant)
			{
				if (_MyGraphic == null)
				{
					_MyGraphic = GetComponent<Graphic>();
				}

				_CachedTarget = _MyGraphic;
			}

			if (_CachedTarget == null)
			{
				return;
			}

			_CachedGradient = _Gradient.value;
			if (_CachedGradient == null)
			{
				_CachedGradient = new Gradient();
			}
		}

		protected override void OnTweenUpdate (float factor)
		{
			if (_CachedTarget != null)
			{
				_CachedTarget.color = _CachedGradient.Evaluate( factor );
			}
		}
	}
}
