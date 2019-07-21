using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.BehaviourTree.Actions
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
	public class StopSound : ActionBehaviour 
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 停止するAudioSource。<br />
		/// 指定しない場合はBehaviourTreeが割り当てられているGameObjectにあるAudioSource。
		/// </summary>
#else
		/// <summary>
		/// AudioSource to stop.<br/>
		/// If not specified, BehaviourTree is assigned to the AudioSource in the GameObject.
		/// </summary>
#endif
		[SerializeField]
		[SlotType(typeof(AudioSource))]
		private FlexibleComponent _AudioSource = new FlexibleComponent();

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

		protected override void OnExecute() 
		{
			Stop();
			FinishExecute(true);
		}
	}
}