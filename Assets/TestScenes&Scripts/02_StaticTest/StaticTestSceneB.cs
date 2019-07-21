using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticTestSceneB : MonoBehaviour {
	// Use this for initialization

	int b;

	void Start () {

		b = StaticTestSceneA.GetA();
		print (b);
		
	}

}
