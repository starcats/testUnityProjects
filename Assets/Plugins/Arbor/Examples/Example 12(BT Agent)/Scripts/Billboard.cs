using UnityEngine;
using System.Collections;

namespace Arbor.Example
{
	[AddComponentMenu("Arbor/Example/Billboard")]
	public class Billboard : MonoBehaviour
	{
		private Transform _Trasnform;

		private void Start()
		{
			_Trasnform = GetComponent<Transform>();
		}

		void LateUpdate()
		{
			_Trasnform.forward = Camera.main.transform.forward;
		}
	}
}