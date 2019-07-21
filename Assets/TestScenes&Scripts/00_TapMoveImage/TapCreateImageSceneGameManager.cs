using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour {

	public GameObject imagePf;
	public GameObject imageBack;
	public GameObject image;
	private Vector3 clickPosition;

	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {

		// マウス入力で左クリックをした瞬間
		if (Input.GetMouseButtonDown(0)) {
			// ここでの注意点は座標の引数にVector2を渡すのではなく、Vector3を渡すことである。
			// Vector3でマウスがクリックした位置座標を取得する
			clickPosition = Input.mousePosition;
			//Debug.Log(clickPosition);
			// Z軸修正
			clickPosition.z = 0f;

			WarpImage();
			// オブジェクト生成 : オブジェクト(GameObject), 位置(Vector3), 角度(Quaternion)
			// ScreenToWorldPoint(位置(Vector3))：スクリーン座標をワールド座標に変換する
			// Instantiate(imagePf, canvasUI.ScreenToWorldPoint(clickPosition), imagePf.transform.rotation);

			/*
			GameObject Pf = (GameObject) Instantiate(imagePf);
			Pf.transform.SetParent(imageBack.transform, false);
			Pf.transform.localPosition = clickPosition;
			*/


		}
		
	}

	void WarpImage () {
		var NP = image.transform.localPosition.x;
		Debug.Log(image.transform.localPosition.x);
		image.transform.localPosition = clickPosition;
		Debug.Log(image.transform.localPosition.x);
	}
}
