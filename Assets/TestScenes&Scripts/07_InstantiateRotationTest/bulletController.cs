using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour {

	float speed = 0.1f;

	// Use this for initialization
	void Start () {

		GetComponent<Rigidbody2D> ().velocity = transform.up * speed;
		// transform.upの初期値は Vector3 (0, 1, 0)
		// rotationが初期値だと真上に向かって速度(speed)を加える。

	}
	
	// Update is called once per frame
	void Update () {

	}
}
