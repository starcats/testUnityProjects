﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// シーンをまたいでもアクセス可能なParameterContainerを扱う。
	/// </summary>
	/// <remarks>
	/// 共有して使用したいParameterContainerをプレハブとして用意する必要があります。<br/>
	/// 同じParameterContainerプレハブを参照するGlobalParameterContainerは共通のParameterContainerインスタンスを使用するようになります。
	/// </remarks>
#else
	/// <summary>
	/// Class dealing with the accessible ParameterContainer even across the scene.
	/// </summary>
	/// <remarks>
	/// You need to prepare the ParameterContainer you want to share and use as a prefab.<br/>
	/// GlobalParameterContainer referring to the same ParameterContainer prefab will now use a common ParameterContainer instance.
	/// </remarks>
#endif
	[BuiltInComponent]
	[AddComponentMenu("Arbor/GlobalParameterContainer",30)]
	[HelpURL( ArborReferenceUtility.componentUrl + "globalparametercontainer.html" )]
	public sealed class GlobalParameterContainer : GlobalParameterContainerInternal
	{
	}
}
