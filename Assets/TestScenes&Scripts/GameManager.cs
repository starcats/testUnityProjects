using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;

public class TapCreateImageSceneGameManager : MonoBehaviour {

	public GameObject imagePf;
	public GameObject imageBack;
	public GameObject image;
	private Vector3 clickPosition;
	private float moveX = 0.0f;
	private float deltaTimeNow = 0f;
	private float disX = 0;
	private float nowImagePosition = 0f;
	private float tapImagePosition = 0f;

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
		nowImagePosition = image.transform.localPosition.x;

		float distance = nowImagePosition - clickPosition.x;
		Debug.Log(distance);
		if (distance > 5 | -5 > distance) {
			//Debug.Log(Time.deltaTime);
			float translation = Time.deltaTime * moveX;
			image.transform.Translate(translation, 0f, 0f);
		}
		
	}

	void WarpImage () {
		tapImagePosition = image.transform.localPosition.x;
		disX = clickPosition.x - tapImagePosition;
		Debug.Log(disX);
		// moveX = disX / 100;
		if (disX >= 1) {
			moveX = 0.5f;
		} else if (disX <= -1) {
			moveX = -0.5f;
		} else {
			moveX = 0f;
		}

		//image.transform.localPosition = clickPosition;
		//Debug.Log(image.transform.localPosition.x);
	}

	void MoveImage() {

	}
}
