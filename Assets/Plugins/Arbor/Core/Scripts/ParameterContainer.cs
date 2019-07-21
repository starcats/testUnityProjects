using UnityEngine;
using System.Collections.Generic;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// パラメータを格納するためのコンポーネント。<br/>
	/// GameObjectにアタッチして使用する。
	/// </summary>
#else
	/// <summary>
	/// ParameterContainer。<br />
	/// Is used by attaching to GameObject.
	/// </summary>
#endif
	[AddComponentMenu("Arbor/ParameterContainer",20)]
	[BuiltInComponent]
	[HelpURL( ArborReferenceUtility.componentUrl + "parametercontainer.html")]
	public sealed class ParameterContainer : ParameterContainerInternal
	{
	}
}
