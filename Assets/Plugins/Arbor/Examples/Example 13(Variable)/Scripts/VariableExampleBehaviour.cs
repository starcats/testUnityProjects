using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.Example
{
	[AddComponentMenu("")]
	[AddBehaviourMenu("Example/VariableExampleBehaviour")]
	public class VariableExampleBehaviour : StateBehaviour
	{
		[SerializeField]
		private Image _IconImage = null;
		[SerializeField]
		private Text _NameText = null;
		[SerializeField]
		private FlexibleVariableExampleData _ExampleData = new FlexibleVariableExampleData(new VariableExampleData());

		// Use this for enter state
		public override void OnStateBegin()
		{
			VariableExampleData exampleData = _ExampleData.value;
			if (exampleData != null)
			{
				_IconImage.sprite = exampleData.icon;
				_NameText.text = exampleData.name;
			}
		}
	}
}