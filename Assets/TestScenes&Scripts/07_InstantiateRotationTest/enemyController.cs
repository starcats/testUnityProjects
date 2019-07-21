using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour {

	public GameObject bullet;

	// Use this for initialization
	void Start () {
		// 直接velocity(速度)に代入すれば進み続ける
		// →gravityは0にする
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);

		attack();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void attack() {

		//var pf = Instantiate(bullet, transform.position, Quaternion.Euler (0, 0, 0));


		var pf = Instantiate(bullet);
		var myPos = this.gameObject.transform.position;
		pf.transform.position = new Vector2 (myPos.x, myPos.y);
		//pf.transform.rotation = Quaternion.Euler (0, 0, 0);
		
	}
}
