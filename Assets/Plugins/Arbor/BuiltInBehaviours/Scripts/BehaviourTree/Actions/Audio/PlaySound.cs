using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.BehaviourTree.Actions
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
	public class PlaySound : ActionBehaviour 
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 再生するAudioSource。<br />
		/// 指定しない場合はBehaviourTreeが割り当てられているGameObjectにあるAudioSource。
		/// </summary>
#else
		/// <summary>
		/// AudioSource to play.<br/>
		/// If not specified, BehaviourTree is assigned to the AudioSource in the GameObject.
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

		protected override void OnExecute()
		{
			Play();
			FinishExecute(true);
		}
	}
}