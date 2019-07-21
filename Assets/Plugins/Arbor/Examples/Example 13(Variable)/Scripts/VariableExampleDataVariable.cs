using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.Example
{
	[System.Serializable]
	public class VariableExampleData
	{
		// Declare Serialize Fields
		public string name;
		public Sprite icon;
	}

	[System.Serializable]
	public class FlexibleVariableExampleData : FlexibleField<VariableExampleData>
	{
		public FlexibleVariableExampleData(VariableExampleData value) : base(value)
		{
		}

		public FlexibleVariableExampleData(AnyParameterReference parameter) : base(parameter)
		{
		}

		public FlexibleVariableExampleData(InputSlotAny slot) : base(slot)
		{
		}

		public static explicit operator VariableExampleData(FlexibleVariableExampleData flexible)
		{
			return flexible.value;
		}

		public static explicit operator FlexibleVariableExampleData(VariableExampleData value)
		{
			return new FlexibleVariableExampleData(value);
		}
	}

	[System.Serializable]
	public class InputSlotVariableExampleData : InputSlot<VariableExampleData>
	{
	}

	[System.Serializable]
	public class OutputSlotVariableExampleData : OutputSlot<VariableExampleData>
	{
	}

	[AddVariableMenu("Example/VariableExampleData")]
	[AddComponentMenu("")]
	public class VariableExampleDataVariable : Variable<VariableExampleData>
	{
	}
}