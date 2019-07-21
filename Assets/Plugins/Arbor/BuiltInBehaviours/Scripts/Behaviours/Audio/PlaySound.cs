using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// AudioSourceを再生する。
	/// </summary>
#else
	/// <summary>
	/// Play AudioSource.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Audio/PlaySound")]
	[BuiltInBehaviour]
	public sealed class PlaySound : StateBehaviour, INodeBehaviourSerializationCallbackReceiver
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 再生するAudioSource。<br />
		/// 指定しない場合はArborFSMが割り当てられているGameObjectにあるAudioSource。
		/// </summary>
#else
		/// <summary>
		/// AudioSource to play.<br/>
		/// If not specified, ArborFSM is assigned to the AudioSource in the GameObject.
		/// </summary>
#endif
		[SerializeField]
		[SlotType(typeof(AudioSource))]
		private FlexibleComponent _AudioSource = new FlexibleComponent();

#if ARBOR_DOC_JA
		/// <summary>
		/// 再生時にClipを設定するかどうか。
		/// </summary>
#else
		/// <summary>
		/// Whether to set Clip during playback.
		/// </summary>
#endif
		[SerializeField]
		private bool _IsSetClip = false;

#if ARBOR_DOC_JA
		/// <summary>
		/// 設定するAudioClip。
		/// </summary>
#else
		/// <summary>
		/// AudioClip to set.
		/// </summary>
#endif
		[SerializeField]
		private AudioClip _Clip = null;

		[SerializeField]
		[HideInInspector]
		private int _SerializeVersion = 0;

		#region old

		[FormerlySerializedAs("_AudioSource")]
		[SerializeField]
		[HideInInspector]
		private AudioSource _OldAudioSource = null;

		#endregion // old

		#endregion // Serialize fields

		private AudioSource _MyAudioSource;
		public AudioSource cachedAudioSource
		{
			get
			{
				AudioSource audioSource = _AudioSource.value as AudioSource;
				if (audioSource == null && _AudioSource.type == FlexibleType.Constant)
				{
					if (_MyAudioSource == null)
					{
						_MyAudioSource = GetComponent<AudioSource>();
					}

					audioSource = _MyAudioSource;
				}
				return audioSource;
			}
		}
		
		void Play()
		{
			AudioSource audioSource = cachedAudioSource;
			if (audioSource != null)
			{
				if (_IsSetClip)
				{
					audioSource.clip = _Clip;
				}
				audioSource.Play();
			}
		}

		// Use this for enter state
		public override void OnStateBegin()
		{
			Play();
		}

		void SerializeVer1()
		{
			_AudioSource = (FlexibleComponent)_OldAudioSource;
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
