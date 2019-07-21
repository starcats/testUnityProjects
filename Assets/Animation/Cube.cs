using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

	[SerializeField]
	AnimationClip cube1;

	[SerializeField]
	AnimationClip cube2;

	AnimationClip newCube;

	// Use this for initialization
	void Start () {
		newCube = new AnimationClip();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			// cube1 = newCube;
			cube1.ClearCurves();
			print ("a");
		}

		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			cube1 = newCube;
			// cube1.ClearCurves();
			print ("newCube");
		}
	}
}
