using UnityEngine;
using UnityEngine.UI;

namespace Arbor.Example
{
	using Arbor.BehaviourTree;

	[AddComponentMenu("")]
	[AddBehaviourMenu("Example/DebugGraphAction")]
	public class DebugGraphAction : ActionBehaviour
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

		protected override void OnStart()
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

		protected override void OnExecute()
		{
			FinishExecute(true);
		}
	}
}