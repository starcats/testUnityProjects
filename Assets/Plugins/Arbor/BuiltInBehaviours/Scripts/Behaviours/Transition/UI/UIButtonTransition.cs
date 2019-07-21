using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// ボタンをクリックしたら遷移する。
	/// </summary>
#else
	/// <summary>
	/// Click the button to make a transition.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transition/UI/UIButtonTransition")]
	[BuiltInBehaviour]
	public sealed class UIButtonTransition : StateBehaviour, INodeBehaviourSerializationCallbackReceiver
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// クリック判定をするボタン
		/// </summary>
#else
		/// <summary>
		/// Button to click judgment
		/// </summary>
#endif
		[SerializeField]
		[SlotType(typeof(Button))]
		private FlexibleComponent _Button = new FlexibleComponent();

#if ARBOR_DOC_JA
		/// <summary>
		/// 遷移先ステート。<br />
		/// 遷移メソッド : Button.onClick
		/// </summary>
#else
		/// <summary>
		/// Transition destination state.<br />
		/// Transition Method : Button.onClick
		/// </summary>
#endif
		[SerializeField] private StateLink _NextState = new StateLink();

		[SerializeField]
		[HideInInspector]
		private int _SerializeVersion = 0;

		#region old

		[FormerlySerializedAs("_Button")]
		[SerializeField]
		[HideInInspector]
		private Button _OldButton = null;

		#endregion // old

		#endregion // Serialize fields

		private Button _MyButton;
		public Button cachedButton
		{
			get
			{
				Button button = _Button.value as Button;
				if (button == null && _Button.type == FlexibleType.Constant)
				{
					if (_MyButton == null)
					{
						_MyButton = GetComponent<Button>();
					}

					button = _MyButton;
				}
				return button;
			}
		}
		
		// Use this for enter state
		public override void OnStateBegin()
		{
			Button button = cachedButton;
			if (button != null)
			{
				button.onClick.AddListener(OnClick);
			}
		}

		// Use this for exit state
		public override void OnStateEnd()
		{
			Button button = cachedButton;
			if (button != null)
			{
				button.onClick.RemoveListener(OnClick);
			}
		}

		public void OnClick()
		{
			Transition(_NextState);
		}

		void SerializeVer1()
		{
			_Button = (FlexibleComponent)_OldButton;
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
