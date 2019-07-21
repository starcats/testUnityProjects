using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arbor.Example
{
	[AddComponentMenu( "" )]
	[AddBehaviourMenu( "Example/Menu" )]
	public class ExampleMenuTransition : StateBehaviour
	{
		[Multiline( 3 )]
		[SerializeField]
		private string _MenuName = string.Empty;

		[System.Serializable]
		public class Item
		{
			public string name;
			public StateLink link;
		}

		[SerializeField]
		private List<Item> _Items = new List<Item>();

		void OnGUI()
		{
			GUILayout.Label( _MenuName );

			int itemCount = _Items.Count;
			for( int itemIndex = 0 ; itemIndex < itemCount ; itemIndex++ )
			{
				Item item = _Items[itemIndex];
				if( GUILayout.Button( item.name ) )
				{
					Transition( item.link );
				}
			}
		}
	}
}
