using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// AudioSourceを停止する。
	/// </summary>
#else
	/// <summary>
	/// Stop AudioSource.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Audio/StopSound")]
	[BuiltInBehaviour]
	public sealed class StopSound : StateBehaviour, INodeBehaviourSerializationCallbackReceiver
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 停止するAudioSource。<br />
		/// 指定しない場合はArborFSMが割り当てられているGameObjectにあるAudioSource。
		/// </summary>
#else
		/// <summary>
		/// AudioSource to stop.<br/>
		/// If not specified, ArborFSM is assigned to the AudioSource in the GameObject.
		/// </summary>
#endif
		[SerializeField]
		[SlotType(typeof(AudioSource))]
		private FlexibleComponent _AudioSource = new FlexibleComponent();

		[SerializeField]
		[HideInInspector]
		private int _SerializeVersion;

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
		
		void Stop()
		{
			AudioSource audioSource = cachedAudioSource;
			if (audioSource != null)
			{
				audioSource.Stop();
			}
		}

		// Use this for enter state
		public override void OnStateBegin()
		{
			Stop();
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
