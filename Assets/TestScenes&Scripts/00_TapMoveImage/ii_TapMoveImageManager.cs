using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;

public class ii_TapMoveImageManager : MonoBehaviour {

	public GameObject imagePf;
	private string[] gameObject = new string[] {};
	public GameObject imageBack;
	private GameObject image;
	private GameObject image2;
	//public GameObject image;
	public GameObject canvasUI;
	private Vector3 clickPosition;
	private int moveStartFlag = 0;
	private float disX = 0;
	private float disY = 0;
	private float moveSpeedX = 0;
	private float moveSpeedY = 0;
	private float MAX_MOVE_SPEED = 300.0f;
	private float moveTime = 0;
	private DateTime startTime;
	private DateTime nowTime;
	private float translationX = 0;
	private float translationY = 0;

	// Use this for initialization
	void Start () {
		//gameObject[0] = image;
		image = (GameObject)Instantiate (imagePf);
		image.transform.SetParent(imageBack.transform, false);
	}
	
	// Update is called once per frame
	void Update () {

		nowTime = DateTime.UtcNow;

		// マウス入力で左クリックをした瞬間
		if (Input.GetMouseButtonDown(0)) {
			// ここでの注意点は座標の引数にVector2を渡すのではなく、Vector3を渡すことである。
			// Vector3でマウスがクリックした位置座標を取得する
			clickPosition = Input.mousePosition;
			//Debug.Log(clickPosition);
			// Z軸修正
			clickPosition.z = 0f;
			MoveImage();
		}
		
		if (startTime + TimeSpan.FromSeconds(moveTime) > nowTime) {
			translationX = Time.deltaTime * moveSpeedX / 130;
			translationY = Time.deltaTime * moveSpeedY / 130;
			var a = startTime + TimeSpan.FromSeconds(moveTime);
			//Debug.Log(moveSpeedX);
			//Debug.Log(nowTime);
			//Debug.Log(translationX);
			image.transform.Translate(translationX, translationY, 0f);

		} 

	}

	void MoveImage() {
		disX = clickPosition.x - image.transform.localPosition.x;
		disY = clickPosition.y - image.transform.localPosition.y;
		var disXTime = Math.Abs(disX) / MAX_MOVE_SPEED;
		var disYTime = Math.Abs(disY) / MAX_MOVE_SPEED;

		if (disXTime > disYTime) {
			moveTime = disXTime;
			moveSpeedX = disX / moveTime;
			moveSpeedY = disY / moveTime;
		} else { 
			moveTime = disYTime;
			moveSpeedX = disX / moveTime;
			moveSpeedY = disY / moveTime;
		}
		Debug.Log(moveTime);
		startTime = nowTime;
		moveStartFlag = 1;
	}
}
