using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;

public class i_TapMoveClone : MonoBehaviour {

	public GameObject imagePf;
	private string[] gameObject = new string[] {};
	public GameObject imageBack;
	public Button button;
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

	private List<GameObject> listClone = new List<GameObject>();
	private List<DateTime> listStartTime = new List<DateTime>();
	private List<float> listMoveTime = new List<float>();
	private List<float> listTranslationX = new List<float>();
	private List<float> listTranslationY = new List<float>();
	private int countClone = 0;

	// Use this for initialization
	void Start () {
		//gameObject[0] = image;
		CreateImage();
		button.GetComponent<Button> ().onClick.AddListener(CreateImage);
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
			//MoveImage();
			MoveClone();
		}
		countClone = listClone.Count - 1;
		for (int i = 0; i <= countClone; i++) {
			if (listStartTime[i] + TimeSpan.FromSeconds(listMoveTime[i]) > nowTime) {
				listClone[i].transform.Translate(listTranslationX[i], listTranslationY[i], 0f);		
			} 
		}
	}



	void CreateImage () {

		GameObject imageClone = (GameObject)Instantiate (imagePf);
		imageClone.transform.SetParent(imageBack.transform, false);

		listClone.Add(imageClone);
		listMoveTime.Add(0);
		listStartTime.Add(nowTime);
		listTranslationX.Add(0);
		listTranslationY.Add(0);
		Debug.Log(countClone);

	}

	void MoveClone() {

		for (int i = 0; i <= countClone; i++) {

			disX = clickPosition.x - listClone[i].transform.localPosition.x;
			disY = clickPosition.y - listClone[i].transform.localPosition.y;
			var disXTime = Math.Abs(disX) / MAX_MOVE_SPEED;
			var disYTime = Math.Abs(disY) / MAX_MOVE_SPEED;

			if (disXTime > disYTime) {
				listMoveTime[i] = disXTime;
				moveSpeedX = disX / listMoveTime[i];
				moveSpeedY = disY / listMoveTime[i];
			} else { 
				listMoveTime[i] = disYTime;
				moveSpeedX = disX / listMoveTime[i];
				moveSpeedY = disY / listMoveTime[i];
			}
			listStartTime[i] = nowTime;
			listTranslationX[i] = Time.deltaTime * moveSpeedX / 130;
			listTranslationY[i] = Time.deltaTime * moveSpeedY / 130;
		}
	}
}
