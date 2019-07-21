using UnityEngine;
using System.Collections.Generic;

namespace Arbor
{
	public abstract class WeightListBase
	{
		public abstract int count
		{
			get;
		}

		public abstract void Add(object value, float weight);
		public abstract void Insert(int index, object value, float weight);

		public abstract object GetValueObject(int index);
		public abstract void SetValueObject(int index,object value);

		public abstract float GetWeight(int index);
		public abstract void SetWeight(int index, float weight);

		public abstract float GetTotalWeight();
	}

#if ARBOR_DOC_JA
	/// <param name="Value">値</param>
	/// <param name="Weight">重み。 大きいほど確率が高くなる。</param>
	/// <param name="Probability">実際の確率</param>
#else
	/// <param name="Value">value</param>
	/// <param name="Weight">Weight. The larger the probability increases.</param>
	/// <param name="Probability">Actual probability</param>
#endif
	[System.Serializable]
	[Arbor.Internal.Documentable]
	public class WeightList<T> : WeightListBase
	{
		[System.Serializable]
		public class Item
		{
			public T value;
			public float weight;
		}

		[SerializeField]
		[Arbor.Internal.HideInDocument]
		private List<T> _Values = new List<T>();

		[SerializeField]
		[Range(0,100)]
		[Arbor.Internal.HideInDocument]
		private List<float> _Weights = new List<float>();

		public override int count
		{
			get
			{
				return _Values.Count;
			}
		}

		public override void Add(object value, float weight)
		{
			_Values.Add((T)value);
			_Weights.Add(weight);
		}

		public override void Insert(int index, object value, float weight)
		{
			_Values.Insert(index, (T)value);
			_Weights.Insert(index, weight);
		}

		public override object GetValueObject(int index)
		{
			return GetValue(index);
		}

		public T GetValue(int index)
		{
			return _Values[index];
		}

		public override void SetValueObject(int index, object value)
		{
			SetValue(index, (T)value);
		}

		public void SetValue(int index, T value)
		{
			_Values[index] = value;
		}

		public override float GetWeight(int index)
		{
			return _Weights[index];
		}

		public override void SetWeight(int index, float weight)
		{
			_Weights[index] = weight;
		}

		public override float GetTotalWeight()
		{
			if (_Values.Count == 0 || _Values.Count != _Weights.Count)
			{
				return 0;
			}

			float totalWeight = 0.0f;

			for (int index = 0,count = _Weights.Count; index < count; index++)
			{
				totalWeight += _Weights[index];
			}

			return totalWeight;
		}

		public T GetRandomItem()
		{
			float totalWeight = GetTotalWeight();

			if (totalWeight == 0.0f)
			{
				return default(T);
			}

			float r = Random.Range(0, totalWeight);

			totalWeight = 0.0f;

			int findIndex = 0;

			for (int index = 0, count = _Values.Count; index < count; index++)
			{
				float weight = _Weights[index];

				if (totalWeight <= r && r < totalWeight + weight)
				{
					findIndex = index;
					break;
				}

				totalWeight += weight;
			}

			return _Values[findIndex];
		}
	}
}