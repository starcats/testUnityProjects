using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.Example
{
	[AddComponentMenu("")]
	[AddBehaviourMenu("Example/DebugGraphBehaviour")]
	public class DebugGraphBehaviour : StateBehaviour
	{
		private Text GetText()
		{
			ParameterContainer rootParameterContainer = nodeGraph.rootGraph.GetComponent<ParameterContainer>();
			if (rootParameterContainer == null)
			{
				return null;
			}
			Parameter parameter = rootParameterContainer.GetParam("CurrentGraphText");
			if (parameter == null)
			{
				return null;
			}
			return parameter.objectReferenceValue as Text;
		}

		// Use this for enter state
		public override void OnStateBegin()
		{
			string message = string.Format("{0} : {1}", nodeGraph, node);

			Text text = GetText();
			if (text != null)
			{
				text.text = message;
			}
			else
			{
				Debug.Log(message);
			}
		}
	}
}