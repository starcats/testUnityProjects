using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;

public class PrefavScrptTestGameManager2 : MonoBehaviour {

	public Button createButton;
	public GameObject prefab;
	public GameObject canvas;
	public static DateTime nowTime;

	public static List<GameObject> listClone = new List<GameObject>();


	// Use this for initialization
	void Start () {

		createButton.onClick.AddListener(CreatePrefab);
		
	}
	
	// Update is called once per frame
	void Update () {

		nowTime = DateTime.UtcNow;
		print(listClone.Count);
	}

	void TestPrint () {
		print("create");
	}

	void CreatePrefab () {
		GameObject pf = (GameObject)Instantiate (prefab);
		pf.transform.SetParent (canvas.transform, false);
		listClone.Add(pf);
		pf.GetComponent<PrefabManager03_3> ().SetPrefab(); 



	}
}
