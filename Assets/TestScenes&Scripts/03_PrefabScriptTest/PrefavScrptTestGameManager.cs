using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PrefavScrptTestGameManager : MonoBehaviour {

	public Button createButton;
	public GameObject prefab;
	public GameObject canvas;

	// Use this for initialization
	void Start () {

		createButton.onClick.AddListener(CreatePrefab);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void TestPrint () {
		print("create");
	}

	void CreatePrefab () {
		GameObject pf = (GameObject)Instantiate (prefab);
		pf.transform.SetParent (canvas.transform, false);
		pf.GetComponent<PrefabManager03_2> ().SetPrefab(); 


	}
}
