using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// 演算結果によって遷移する。
	/// </summary>
	/// <remarks>
	/// 複数のConditionを設定した場合は、すべての比較結果が真になったときのみ遷移する。
	/// </remarks>
#else
	/// <summary>
	/// It will transition by the calculation result
	/// </summary>
	/// <remarks>
	/// When more than one Condition is set, it transits only when all comparison results become true.
	/// </remarks>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transition/CalculatorTransition")]
	[BuiltInBehaviour]
	public sealed class CalculatorTransition : StateBehaviour, INodeBehaviourSerializationCallbackReceiver
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
		private CalculatorConditionList _ConditionList = new CalculatorConditionList();

#if ARBOR_DOC_JA
		/// <summary>
		/// 遷移先ステート。<br />
		/// 遷移メソッド : OnStateBegin
		/// </summary>
#else
		/// <summary>
		/// Transition destination state.<br />
		/// Transition Method : OnStateBegin
		/// </summary>
#endif
		[SerializeField] private StateLink _NextState = new StateLink();

		[SerializeField]
		[HideInInspector]
		private int _SerializeVersion;

		#region old

		[SerializeField]
		[HideInInspector]
		[FormerlySerializedAs("_Condisions")]
		[FormerlySerializedAs("_Conditions")]
		private List<CalculatorConditionLegacy> _OldConditions = new List<CalculatorConditionLegacy>();

		#endregion // old

		#endregion // Serialize fields

		private const int kCurrentSerializeVersion = 2;

		// Use this for enter state
		public override void OnStateBegin()
		{
			if ( CheckCondition() )
			{
				Transition(_NextState);
			}
		}

		bool CheckCondition()
		{
			return _ConditionList.CheckCondition();
		}

		void SerializeVer1()
		{
			int conditionCount = _OldConditions.Count;
			for( int conditionIndex = 0 ; conditionIndex < conditionCount ; conditionIndex++ )
			{
				CalculatorConditionLegacy condition = _OldConditions[conditionIndex];
				condition.SerializeVer1();
			}
		}

		void SerializeVer2()
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
					case 1:
						SerializeVer2();
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

