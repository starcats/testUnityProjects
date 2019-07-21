using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationZ : MonoBehaviour {

	float dir = 0f;
	public float rotationNum = 0f;
	public bool isMove = false;

	// Use this for initialization
	void Start () {
		//GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, 1, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
		dir += rotationNum;
		transform.rotation = Quaternion.Euler (0, 0, dir);

		if (isMove == true) {
			GetComponent<Rigidbody2D> ().velocity = transform.up;
		}
	}
}
