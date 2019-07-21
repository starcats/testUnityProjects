﻿using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Calculatorの状態チェッククラス
	/// </summary>
#else
	/// <summary>
	/// Condition check class of Calculator
	/// </summary>
#endif
	[System.Serializable]
	[Arbor.Internal.Documentable]
	public class CalculatorConditionLegacy : ISerializationCallbackReceiver
	{
		#region enum

#if ARBOR_DOC_JA
		/// <summary>
		/// 比較タイプ
		/// </summary>
#else
		/// <summary>
		/// Compare type
		/// </summary>
#endif
		public enum CompareTypeOld
		{
			/// <summary>
			/// Value1 &gt; Value2
			/// </summary>
			Greater,

			/// <summary>
			/// Value1 &lt; Value2
			/// </summary>
			Less,

			/// <summary>
			/// Value1 == Value2
			/// </summary>
			Equals,

			/// <summary>
			/// Value1 != Value2
			/// </summary>
			NotEquals,
		}

		#endregion // enum

		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 値の型
		/// </summary>
#else
		/// <summary>
		/// Value type
		/// </summary>
#endif
		[SerializeField]
		internal CalculatorCondition.Type _Type = CalculatorCondition.Type.Int;

#if ARBOR_DOC_JA
		/// <summary>
		/// 比較タイプ
		/// </summary>
#else
		/// <summary>
		/// Compare type
		/// </summary>
#endif
		[SerializeField]
		internal CompareType _CompareType = CompareType.Equals;

#if ARBOR_DOC_JA
		/// <summary>
		/// Intの値1
		/// </summary>
#else
		/// <summary>
		/// Int value 1
		/// </summary>
#endif
		[SerializeField]
		internal FlexibleInt _IntValue1 = new FlexibleInt();

#if ARBOR_DOC_JA
		/// <summary>
		/// Intの値2
		/// </summary>
#else
		/// <summary>
		/// Int value 2
		/// </summary>
#endif
		[SerializeField]
		internal FlexibleInt _IntValue2 = new FlexibleInt();

#if ARBOR_DOC_JA
		/// <summary>
		/// Floatの値1
		/// </summary>
#else
		/// <summary>
		/// Float value 1
		/// </summary>
#endif
		[SerializeField]
		internal FlexibleFloat _FloatValue1 = new FlexibleFloat();

#if ARBOR_DOC_JA
		/// <summary>
		/// Floatの値2
		/// </summary>
#else
		/// <summary>
		/// Float value 2
		/// </summary>
#endif
		[SerializeField]
		internal FlexibleFloat _FloatValue2 = new FlexibleFloat();

#if ARBOR_DOC_JA
		/// <summary>
		/// Boolの値1
		/// </summary>
#else
		/// <summary>
		/// Bool value 1
		/// </summary>
#endif
		[FormerlySerializedAs("_BoolValue")]
		[SerializeField]
		internal FlexibleBool _BoolValue1 = new FlexibleBool(false);

#if ARBOR_DOC_JA
		/// <summary>
		/// Boolの値2
		/// </summary>
#else
		/// <summary>
		/// Bool value 2
		/// </summary>
#endif
		[SerializeField]
		internal FlexibleBool _BoolValue2 = new FlexibleBool(true);

		[SerializeField]
		[HideInInspector]
		private int _SerializeVersion = 0;

#region old

		[FormerlySerializedAs("_CompareType")]
		[SerializeField]
		[HideInInspector]
		private CompareTypeOld _CompareTypeOld = CompareTypeOld.Greater;

		#endregion // old

		#endregion // Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 値を比較する.
		/// </summary>
		/// <returns>比較結果</returns>
#else
		/// <summary>
		/// Compare the values.
		/// </summary>
		/// <returns>Comparison result</returns>
#endif
		public bool Compare()
		{
			switch (_Type)
			{
				case CalculatorCondition.Type.Int:
					switch (_CompareType)
					{
						case CompareType.Greater:
							return (_IntValue1.value > _IntValue2.value);
						case CompareType.GreaterOrEquals:
							return (_IntValue1.value >= _IntValue2.value);
						case CompareType.Less:
							return (_IntValue1.value < _IntValue2.value);
						case CompareType.LessOrEquals:
							return (_IntValue1.value <= _IntValue2.value);
						case CompareType.Equals:
							return (_IntValue1.value == _IntValue2.value);
						case CompareType.NotEquals:
							return (_IntValue1.value != _IntValue2.value);
					}
					break;
				case CalculatorCondition.Type.Float:
					switch (_CompareType)
					{
						case CompareType.Greater:
							return (_FloatValue1.value > _FloatValue2.value);
						case CompareType.GreaterOrEquals:
							return (_FloatValue1.value >= _FloatValue2.value);
						case CompareType.Less:
							return (_FloatValue1.value < _FloatValue2.value);
						case CompareType.LessOrEquals:
							return (_FloatValue1.value <= _FloatValue2.value);
						case CompareType.Equals:
							return (_FloatValue1.value == _FloatValue2.value);
						case CompareType.NotEquals:
							return (_FloatValue1.value != _FloatValue2.value);
					}
					break;
				case CalculatorCondition.Type.Bool:
					return _BoolValue1.value == _BoolValue2.value;

			}
			return false;
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// CalculatorConditionコンストラクタ
		/// </summary>
		/// <param name="type">値の型</param>
#else
		/// <summary>
		/// CalculatorCondition constructor
		/// </summary>
		/// <param name="type">Value type</param>
#endif
		public CalculatorConditionLegacy(CalculatorCondition.Type type)
		{
			_SerializeVersion = 1;
			_Type = type;
		}

		internal void SerializeVer1()
		{
			_BoolValue2 = new FlexibleBool( true );
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			if (_SerializeVersion == 0)
			{
				switch (_CompareTypeOld)
				{
					case CompareTypeOld.Greater:
						_CompareType = CompareType.Greater;
						break;
					case CompareTypeOld.Less:
						_CompareType = CompareType.Less;
						break;
					case CompareTypeOld.Equals:
						_CompareType = CompareType.Equals;
						break;
					case CompareTypeOld.NotEquals:
						_CompareType = CompareType.NotEquals;
						break;
				}
				_SerializeVersion = 1;
			}
		}
	}
}