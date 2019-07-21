using UnityEngine;
using UnityEngine.Audio;

namespace Arbor.BehaviourTree.Actions
{
#if ARBOR_DOC_JA
	/// <summary>
	/// 指定した地点でサウンドを再生します。
	/// </summary>
#else
	/// <summary>
	/// Play the sound at the specified point.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Audio/PlaySoundAtPoint")]
	[BuiltInBehaviour]
	public class PlaySoundAtPoint : ActionBehaviour 
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
		/// 再生する位置。
		/// </summary>
#else
		/// <summary>
		/// Position to play.
		/// </summary>
#endif
		[SerializeField] private FlexibleVector3 _Position = new FlexibleVector3();

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

		protected override void OnExecute()
		{
			AudioUtility.PlayClipAtPoint( _Clip, _Position.value,_Volume,_OutputAudioMixerGroup,_SpatialBlend );
			FinishExecute(true);
		}
	}
}