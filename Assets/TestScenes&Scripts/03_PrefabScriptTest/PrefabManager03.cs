using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager03 : MonoBehaviour {

	public float pfLocalPositionX = 0;
	private float moveSpeed = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton(0)) {
			Move();
			float moveSpeed = Time.deltaTime * 0.1f;
			transform.Translate(moveSpeed, 0, 0);
			print(Time.deltaTime);
		}
		
	}

	public void SetPrefab () {
		transform.localPosition = new Vector3 (-400,
												UnityEngine.Random.Range (300, -300),
												0);

		pfLocalPositionX = transform.localPosition.x;
	}

	public void Move () {
		transform.Translate(0.01f, 0, 0);
		//print(transform.localPosition);
	}
}
