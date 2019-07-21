﻿using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.BehaviourTree.Decorators
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Parameterのチェック
	/// </summary>
#else
	/// <summary>
	/// Check Parameter
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("ParameterCheck")]
	[BuiltInBehaviour]
	public class ParameterCheck : Decorator, INodeBehaviourSerializationCallbackReceiver
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 判定条件を設定する。
		/// <list type="bullet">
		/// <item><term>＋ボタン</term><description>条件を追加。</description></item>
		/// </list>
		/// </summary>
#else
		/// <summary>
		/// Set the judgment condition.
		/// <list type="bullet">
		/// <item><term>+ Button</term><description>Add condition.</description></item>
		/// </list>
		/// </summary>
#endif
		[SerializeField]
		private ParameterConditionList _ConditionList = new ParameterConditionList();

		[SerializeField]
		[HideInInspector]
		private int _SerializeVersion = 0;

		#region old

		[SerializeField]
		[HideInInspector]
		[FormerlySerializedAs("_Conditions")]
		private List<ParameterConditionLegacy> _OldConditions = new List<ParameterConditionLegacy>();

		#endregion // old

		#endregion // Serialize Fields

		private const int kCurrentSerializeVersion = 1;

		bool CheckCondition()
		{
			return _ConditionList.CheckCondition();
		}

		protected override bool OnConditionCheck() 
		{
			return CheckCondition();
		}

		void SerializeVer1()
		{
			_ConditionList.ImportLegacy(_OldConditions);
			_OldConditions.Clear();
		}

		void Serialize()
		{
			while (_SerializeVersion != kCurrentSerializeVersion)
			{
				switch (_SerializeVersion)
				{
					case 0:
						SerializeVer1();
						_SerializeVersion++;
						break;
					default:
						_SerializeVersion = kCurrentSerializeVersion;
						break;
				}
			}
		}

		void INodeBehaviourSerializationCallbackReceiver.OnBeforeSerialize()
		{
			Serialize();
		}

		void INodeBehaviourSerializationCallbackReceiver.OnAfterDeserialize()
		{
			Serialize();
		}
	}
}