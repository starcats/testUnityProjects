﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Arbor.ObjectPooling;

namespace Arbor.BehaviourTree.Actions
{
#if ARBOR_DOC_JA
	/// <summary>
	/// GameObjectを削除する。
	/// </summary>
#else
	/// <summary>
	/// It will remove the GameObject.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("GameObject/DestroyGameObject")]
	[BuiltInBehaviour]
	public class DestroyGameObject : ActionBehaviour 
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 削除するGameObject。
		/// </summary>
#else
		/// <summary>
		/// It will remove the GameObject.
		/// </summary>
#endif
		[SerializeField]
		private FlexibleGameObject _Target = new FlexibleGameObject();

		#endregion // Serialize fields

		protected override void OnExecute() 
		{
			GameObject target = _Target.value;
			if (target != null)
			{
				ObjectPool.Destroy(target);
			}

			FinishExecute(true);
		}
	}
}