using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Textを設定します。
	/// </summary>
#else
	/// <summary>
	/// Set the Text.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("UI/UISetText")]
	[BuiltInBehaviour]
	public sealed class UISetText : StateBehaviour, INodeBehaviourSerializationCallbackReceiver
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 対象となるText。<br/>
		/// 指定しない場合は、ArborFSMと同じGameObjectに割り当てられているText。
		/// </summary>
#else
		/// <summary>
		/// Text of interest.<br/>
		/// If not specified, Text of GameObject that ArborFSM is assigned a target.
		/// </summary>
#endif
		[SerializeField]
		[SlotType(typeof(Text))]
		private FlexibleComponent _Text = new FlexibleComponent();

#if ARBOR_DOC_JA
		/// <summary>
		/// 設定する文字列。
		/// </summary>
#else
		/// <summary>
		/// String to be set.
		/// </summary>
#endif
		[SerializeField]
		[ConstantMultiline]
		private FlexibleString _String = new FlexibleString();

#if ARBOR_DOC_JA
		/// <summary>
		/// パラメータが変更したときに更新するかどうか(StringがParameterの時のみ)。
		/// </summary>
#else
		/// <summary>
		/// Whether to update when parameters change(Only when String is Parameter).
		/// </summary>
#endif
		[SerializeField]
		private bool _ChangeTimingUpdate = false;

		[SerializeField]
		[HideInInspector]
		private int _SerializeVersion = 0;

		#region old

		[SerializeField]
		[FormerlySerializedAs("_Text")]
		[HideInInspector]
		private Text _OldText = null;

		[SerializeField]
		[FormerlySerializedAs("_String")]
		[HideInInspector]
		private string _OldString = string.Empty;

		#endregion // old

		#endregion // Serialize fields

		private Text _MyText;
		public Text cachedText
		{
			get
			{
				Text text = _Text.value as Text;
				if (text == null && _Text.type == FlexibleType.Constant)
				{
					if (_MyText == null)
					{
						_MyText = GetComponent<Text>();
					}

					text = _MyText;
				}
				return text;
			}
		}

		void UpdateText()
		{
			Text text = cachedText;
			if (text != null)
			{
				text.text = _String.value;
			}
		}

		private Parameter _CachedParameter;
		private Parameter cachedParameter
		{
			get
			{
				if (_CachedParameter == null && _String.type == FlexibleType.Parameter)
				{
					_CachedParameter = _String.parameter;
				}
				return _CachedParameter;
			}
		}

		private bool _IsSettedOnChanged;

		void SetOnChanged()
		{
			if (_IsSettedOnChanged)
			{
				ReleaseOnChanged();
				_CachedParameter = null;
			}

			Parameter parameter = cachedParameter;
			if (parameter != null && _ChangeTimingUpdate)
			{
				parameter.onChanged += OnChangedParameter;
				_IsSettedOnChanged = true;
			}
		}

		void ReleaseOnChanged()
		{
			Parameter parameter = cachedParameter;
			if (parameter != null && _IsSettedOnChanged)
			{
				parameter.onChanged -= OnChangedParameter;
				_IsSettedOnChanged = false;
			}
		}

		void OnEnable()
		{
			SetOnChanged();
		}

		void OnDisable()
		{
			ReleaseOnChanged();
		}

		protected override void OnValidate()
		{
			base.OnValidate();

			if (Application.isPlaying && isActiveAndEnabled && _IsSettedOnChanged)
			{
				SetOnChanged();
			}
		}

		// Use this for enter state
		public override void OnStateBegin()
		{
			UpdateText();
		}
		
		void OnChangedParameter(Parameter parameter)
		{
			UpdateText();
		}

		void SerializeVer1()
		{
			_Text = (FlexibleComponent)_OldText;
			_String = (FlexibleString)_OldString;
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
