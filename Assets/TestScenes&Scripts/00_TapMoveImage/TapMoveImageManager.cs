using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;

public class TapMoveImageManager : MonoBehaviour {

	public GameObject imagePf;
	public GameObject imageBack;
	public GameObject image;
	private Vector3 clickPosition;
	private float moveX = 0.0f;
	private float deltaTimeNow = 0f;
	private float disX = 0;
	private float nowImagePosition = 0f;
	private float tapImagePosition = 0f;
	private Vector3 aTapPoint;

	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(image.transform.localPosition.x);
		Debug.Log(Time.deltaTime);

		// マウス入力で左クリックをした瞬間
		if (Input.GetMouseButton(0)) {
			// ここでの注意点は座標の引数にVector2を渡すのではなく、Vector3を渡すことである。
			// Vector3でマウスがクリックした位置座標を取得する
			//clickPosition = Input.mousePosition;
			//Debug.Log(clickPosition);
			// Z軸修正
			//clickPosition.z = 0f;

			aTapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			
			MoveImage();

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

	void MoveImage() {
		var xTime = 5.0f;
		var yTime = 2.0f;
		//Debug.Log(clickPosition.x);

		iTween.MoveTo (image, iTween.Hash ("x", aTapPoint.x, "y", aTapPoint.y , "time", xTime));
		// 同時にx,yを動かすことは出来ないみたい
		//iTween.MoveTo (image, iTween.Hash ("y", aTapPoint.y, "time", yTime));

	}
}
