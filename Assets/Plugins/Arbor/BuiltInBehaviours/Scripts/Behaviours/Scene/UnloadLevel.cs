using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// 指定したシーンを現在シーンからアンロードする。
	/// </summary>
#else
	/// <summary>
	/// Unload the specified scene from the current scene.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Scene/UnloadLevel")]
	[BuiltInBehaviour]
	public sealed class UnloadLevel : StateBehaviour
	{
#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// アンロードするシーンの名前。
		/// </summary>
#else
		/// <summary>
		/// The name of the scene to be unloaded.
		/// </summary>
#endif
		[SerializeField] private string _LevelName = string.Empty;

#endregion // Serialize fields

		// Use this for enter state
		public override void OnStateBegin()
		{
#if UNITY_5_5_OR_NEWER
			SceneManager.UnloadSceneAsync(_LevelName);
#else
			SceneManager.UnloadScene(_LevelName);
#endif
		}
	}

}
