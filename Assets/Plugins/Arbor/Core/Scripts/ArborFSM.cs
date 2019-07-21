﻿using UnityEngine;
using System.Collections.Generic;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// ステートマシンのコア部分。<br/>
	/// GameObjectにアタッチして使用する。
	/// </summary>
	/// <remarks>
	/// Open EditorボタンをクリックとArbor Editor Windowが開く。
	/// </remarks>
#else
	/// <summary>
	/// Core part of StateMachine.<br/>
	/// Is used by attaching to GameObject.
	/// </summary>
	/// <remarks>
	/// Click on the Open Editor button to open the Arbor Editor Window.
	/// </remarks>
#endif
	[AddComponentMenu("Arbor/ArborFSM",10)]
	[BuiltInComponent]
	[HelpURL( ArborReferenceUtility.componentUrl + "arborfsm.html")]
	public sealed class ArborFSM : ArborFSMInternal
	{
#if ARBOR_DOC_JA
		/// <summary>
		/// シーン内にあるArborFSMを名前で取得する。
		/// </summary>
		/// <param name="name">検索するArborFSMの名前。</param>
		/// <returns>見つかったArborFSM。見つからなかった場合はnullを返す。</returns>
#else
		/// <summary>
		/// Get the ArborFSM that in the scene with the name.
		/// </summary>
		/// <param name="name">The name of the search ArborFSM</param>
		/// <returns>Found ArborFSM. Returns null if not found.</returns>
#endif
		[System.Obsolete("use NodeGraph.FindGraph<ArborFSM>(name)")]
		public static ArborFSM FindFSM( string name )
		{
			return FindGraph<ArborFSM>(name);
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// シーン内にある同一名のArborFSMを取得する。
		/// </summary>
		/// <param name="name">検索するArborFSMの名前。</param>
		/// <returns>見つかったArborFSMの配列。</returns>
#else
		/// <summary>
		/// Get the ArborFSM of the same name that is in the scene.
		/// </summary>
		/// <param name="name">The name of the search ArborFSM.</param>
		/// <returns>Array of found ArborFSM.</returns>
#endif
		[System.Obsolete("use NodeGraph.FindFSMs<ArborFSM>(name)")]
		public static ArborFSM[] FindFSMs( string name )
		{
			return FindGraphs<ArborFSM>(name);
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// GameObjectにアタッチされているArborFSMを名前で取得する。
		/// </summary>
		/// <param name="gameObject">検索したいGameObject。</param>
		/// <param name="name">検索するArborFSMの名前。</param>
		/// <returns>見つかったArborFSM。見つからなかった場合はnullを返す。</returns>
#else
		/// <summary>
		/// Get ArborFSM in the name that has been attached to the GameObject.
		/// </summary>
		/// <param name="gameObject">Want to search GameObject.</param>
		/// <param name="name">The name of the search ArborFSM.</param>
		/// <returns>Found ArborFSM. Returns null if not found.</returns>
#endif
		[System.Obsolete("use NodeGraph.FindGraph<ArborFSM>(gameObject,name)")]
		public static ArborFSM FindFSM( GameObject gameObject,string name )
		{
			return FindGraph<ArborFSM>(gameObject, name);
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// GameObjectにアタッチされている同一名のArborFSMを取得する。
		/// </summary>
		/// <param name="gameObject">検索したいGameObject。</param>
		/// <param name="name">検索するArborFSMの名前。</param>
		/// <returns>見つかったArborFSMの配列。</returns>
#else
		/// <summary>
		/// Get the ArborFSM of the same name that is attached to a GameObject.
		/// </summary>
		/// <param name="gameObject">Want to search GameObject.</param>
		/// <param name="name">The name of the search ArborFSM.</param>
		/// <returns>Array of found ArborFSM.</returns>
#endif
		[System.Obsolete("use NodeGraph.FindGraphs<ArborFSM>(gameObject,name)")]
		public static ArborFSM[] FindFSMs( GameObject gameObject,string name )
		{
			return FindGraphs<ArborFSM>(gameObject, name);
		}
	}
}
