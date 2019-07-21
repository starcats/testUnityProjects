using UnityEngine;
using System.Collections;

namespace Arbor
{
	[System.Flags]
	public enum GraphArgumentUpdateTiming
	{
		Enter = 0x01,
		Execute = 0x02,
	}
}