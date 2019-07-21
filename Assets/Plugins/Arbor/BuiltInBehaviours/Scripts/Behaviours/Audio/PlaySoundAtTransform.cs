using UnityEngine;
using UnityEngine.Audio;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// 指定したTransformの位置でサウンドを再生する。
	/// </summary>
#else
	/// <summary>
	/// Play the sound at the specified Transform position.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Audio/PlaySoundAtTransform")]
	[BuiltInBehaviour]
	public sealed class PlaySoundAtTransform : StateBehaviour
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 再生するAudioClip。
		/// </summary>
#else
		/// <summary>
		/// AudioClip to play.
		/// </summary>
#endif
		[SerializeField] private AudioClip _Clip = null;

#if ARBOR_DOC_JA
		/// <summary>
		/// 再生する位置。<br />
		/// TypeがConstantの時に指定しない場合、このGameObjectの位置。
		/// </summary>
#else
		/// <summary>
		/// Position to play.<br />
		/// If not specified when Type is Constant, the position of this GameObject.
		/// </summary>
#endif
		[SerializeField] private FlexibleTransform _Target = new FlexibleTransform();

#if ARBOR_DOC_JA
		/// <summary>
		/// 再生するボリューム
		/// </summary>
#else
		/// <summary>
		/// Volume to play
		/// </summary>
#endif
		[SerializeField, Range(0, 1)] private float _Volume = 1.0f;

#if ARBOR_DOC_JA
		/// <summary>
		/// 出力先のAudioMixerGroup
		/// </summary>
#else
		/// <summary>
		/// Output AudioMixerGroup
		/// </summary>
#endif
		[SerializeField] private AudioMixerGroup _OutputAudioMixerGroup = null;

#if ARBOR_DOC_JA
		/// <summary>
		/// 立体音響の影響をどれくらい受けるかを設定する。<br/>
		/// 0.0は音を完全に2Dにし、1.0は完全に3Dとなる。
		/// </summary>
#else
		/// <summary>
		/// Set how much the influence of stereophonic sound will be received.<br />
		/// 0.0 makes the sound completely 2D and 1.0 is completely 3D.
		/// </summary>
#endif
		[SerializeField, Range(0, 1)] private float _SpatialBlend = 0f;

		#endregion // Serialize fields

		private Transform _MyTransform;
		public Transform cachedTarget
		{
			get
			{
				Transform t = _Target.value;

				if( t == null && _Target.type == FlexibleType.Constant )
				{
					if( _MyTransform == null )
					{
						_MyTransform = transform;
					}

					t = _MyTransform;
				}
				return t;
			}
		}

		// Use this for enter state
		public override void OnStateBegin() 
		{
			Transform target = cachedTarget;

			if( target != null )
			{
				AudioUtility.PlayClipAtPoint( _Clip,target.position,_Volume,_OutputAudioMixerGroup,_SpatialBlend );
			}
		}
	}
}
