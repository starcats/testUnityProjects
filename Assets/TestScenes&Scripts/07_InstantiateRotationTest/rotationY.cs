using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationY : MonoBehaviour {

	float dir = 0f;
	public float rotationNum = 0f;
	public bool isMove = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
		dir += rotationNum;
		transform.rotation = Quaternion.Euler (0, dir, 0);
		if (isMove == true) {
			GetComponent<Rigidbody2D> ().velocity = transform.up;
		}
	}
}
