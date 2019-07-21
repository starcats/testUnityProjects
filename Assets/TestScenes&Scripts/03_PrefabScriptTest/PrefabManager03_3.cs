using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.UI;

public class PrefabManager03_3 : MonoBehaviour {


	private Vector3 clickPosition;
	private Vector3 worldClickPosition;
	private float MAX_MOVE_SPEED = 2.0f;
	private DateTime nowTime;
	private float translationX = 0;
	private float translationY = 0;
	private GameObject canvas;

	//public static List<GameObject> listClone = new List<GameObject>();
	//private static List<DateTime> listStartTime = new List<DateTime>();
	//private static List<float> listMoveTime = new List<float>();
	// static List<float> listTranslationX = new List<float>();
	//private static List<float> listTranslationY = new List<float>();
	//private int countClone = 0;

	void Start () {

		canvas = GameObject.Find("Canvas");

	}
	
	// Update is called once per frame
	void Update () {

		//countClone = listClone.Count - 1;
		//print (Time.deltaTime);

	}

	public void SetPrefab () {
		transform.localPosition = new Vector3 (UnityEngine.Random.Range (-600, 600),
												UnityEngine.Random.Range (300, -300),
												0);
	}


	
}
