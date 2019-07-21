using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticTestSceneA : MonoBehaviour {

	public static int a = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static int GetA () {
		return a;
	}
}
