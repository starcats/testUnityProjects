using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// トグルの状態によって遷移する。
	/// </summary>
#else
	/// <summary>
	/// It will transition by the toggle.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transition/UI/UIToggleTransition")]
	[BuiltInBehaviour]
	public sealed class UIToggleTransition : StateBehaviour, INodeBehaviourSerializationCallbackReceiver
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 判定をするトグル
		/// </summary>
#else
		/// <summary>
		/// Toggle to the judgment
		/// </summary>
#endif
		[SerializeField]
		[SlotType(typeof(Toggle))]
		private FlexibleComponent _Toggle = new FlexibleComponent();

#if ARBOR_DOC_JA
		/// <summary>
		/// トグルが変更されたタイミングで遷移するかどうか。
		/// </summary>
#else
		/// <summary>
		/// Whether toggle transitions with the changed timing.
		/// </summary>
#endif
		[SerializeField] private bool _ChangeTimingTransition = false;

#if ARBOR_DOC_JA
		/// <summary>
		/// ToggleがOnの場合の遷移先。<br />
		/// 遷移メソッド : OnStateBegin, Toggle.onValueChanged
		/// </summary>
#else
		/// <summary>
		/// Transition destination when Toggle is On.<br />
		/// Transition Method : OnStateBegin, Toggle.onValueChanged
		/// </summary>
#endif
		[SerializeField] private StateLink _OnState = new StateLink();

#if ARBOR_DOC_JA
		/// <summary>
		/// ToggleがOffの場合の遷移先。<br />
		/// 遷移メソッド : OnStateBegin, Toggle.onValueChanged
		/// </summary>
#else
		/// <summary>
		/// Transition destination when Toggle is Off.<br />
		/// Transition Method : OnStateBegin, Toggle.onValueChanged
		/// </summary>
#endif
		[SerializeField] private StateLink _OffState = new StateLink();

		[SerializeField]
		[HideInInspector]
		private int _SerializeVersion;

		#region old

		[SerializeField]
		[FormerlySerializedAs("_Toggle")]
		[HideInInspector]
		private Toggle _OldToggle = null;

		#endregion // old

		#endregion // Serialize fields

		private Toggle _MyToggle;
		public Toggle cachedToggle
		{
			get
			{
				Toggle toggle = _Toggle.value as Toggle;
				if (toggle == null && _Toggle.type == FlexibleType.Constant)
				{
					if (_MyToggle == null)
					{
						_MyToggle = GetComponent<Toggle>();
					}

					toggle = _MyToggle;
				}
				return toggle;
			}
		}
		
		void Transition(bool on)
		{
			if (on)
			{
				Transition(_OnState);
			}
			else
			{
				Transition(_OffState);
			}
		}

		// Use this for enter state
		public override void OnStateBegin()
		{
			Toggle toggle = cachedToggle;
			if (toggle != null)
			{
				if (!_ChangeTimingTransition)
				{
					Transition(toggle.isOn);
				}
				else
				{
					toggle.onValueChanged.AddListener(Transition);
				}
			}
		}

		// Use this for exit state
		public override void OnStateEnd()
		{
			Toggle toggle = cachedToggle;
			if (toggle != null)
			{
				if (_ChangeTimingTransition)
				{
					toggle.onValueChanged.RemoveListener(Transition);
				}
			}
		}

		void SerializeVer1()
		{
			_Toggle = (FlexibleComponent)_OldToggle;
		}

		void INodeBehaviourSerializationCallbackReceiver.OnBeforeSerialize()
		{
			if (_SerializeVersion == 0)
			{
				SerializeVer1();
				_SerializeVersion = 1;
			}
		}

		void INodeBehaviourSerializationCallbackReceiver.OnAfterDeserialize()
		{
			if (_SerializeVersion == 0)
			{
				SerializeVer1();
			}
		}
	}
}
