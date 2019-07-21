using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;

public class iiii_TapMoveClone : MonoBehaviour {

	public GameObject imagePf;
	public GameObject imageBack;
	public Button cleateCircleButton;
	private Vector3 clickPosition;
	private Vector3 worldClickPosition;
	private float MAX_MOVE_SPEED = 2.0f;
	private DateTime nowTime;
	private float translationX = 0;
	private float translationY = 0;

	private List<GameObject> listClone = new List<GameObject>();
	private List<DateTime> listStartTime = new List<DateTime>();
	private List<float> listMoveTime = new List<float>();
	private List<float> listTranslationX = new List<float>();
	private List<float> listTranslationY = new List<float>();
	private int countClone = 0;

	void Start () {

		cleateCircleButton.GetComponent<Button> ().onClick.AddListener(CreateClone);
	}
	
	// Update is called once per frame
	void Update () {

		nowTime = DateTime.UtcNow;
		countClone = listClone.Count - 1;

		// GetMouseButton(0)はマウス入力で左クリックを押している間
		// GetMouseButtonDown(0)は押した時のみ、こっちの方が軽い気がする
		if (Input.GetMouseButton(0)) {
			// ここでの注意点は座標の引数にVector2を渡すのではなく、Vector3を渡すことである。　らしい。
			// Vector3でマウスがクリックした位置座標を取得する
			clickPosition = Input.mousePosition;
			Debug.Log(clickPosition);

			// マウス位置座標をスクリーン座標からワールド座標に変換する
			// ワールドポシションならandroid実機テストの際ズレがなくなった
			worldClickPosition = Camera.main.ScreenToWorldPoint(clickPosition);
			worldClickPosition.z = 0f;
			Debug.Log(worldClickPosition);

			MoveReadyClone();
			MoveClone();
		}	
	}

	void CreateClone () {

		GameObject imageClone = (GameObject)Instantiate (imagePf);
		imageClone.transform.SetParent(imageBack.transform, false);

		listClone.Add(imageClone);
		listMoveTime.Add(0);
		listStartTime.Add(nowTime);
		listTranslationX.Add(0);
		listTranslationY.Add(0);
		Debug.Log(countClone);

	}

	void MoveReadyClone() {

		for (int i = 0; i <= countClone; i++) {
			var moveSpeedX = 0.0f;
			var moveSpeedY = 0.0f;
			var disX = worldClickPosition.x - listClone[i].transform.position.x;
			var disY = worldClickPosition.y - listClone[i].transform.position.y;
			var disXTime = Math.Abs(disX) / MAX_MOVE_SPEED;
			var disYTime = Math.Abs(disY) / MAX_MOVE_SPEED;
			Debug.Log(listClone[0].transform.position.x);

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
			// localPositionを使うとmoveSpeedに /130をしないといけない、なんで？
			listTranslationX[i] = Time.deltaTime * moveSpeedX; // / 130;
			listTranslationY[i] = Time.deltaTime * moveSpeedY; // / 130;
		}
	}

	void MoveClone () {
		countClone = listClone.Count - 1;
		for (int i = 0; i <= countClone; i++) {
		if (listStartTime[i] + TimeSpan.FromSeconds(listMoveTime[i]) > nowTime) {
			listClone[i].transform.Translate(listTranslationX[i], listTranslationY[i], 0f);		
			} 
		}
	}
}
