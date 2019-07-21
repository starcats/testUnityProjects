using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class PrefabManager03_2 : MonoBehaviour {

	public float pfLocalPositionX = 0;
	private float moveSpeed = 0;

	private Vector3 clickPosition;
	private Vector3 worldClickPosition;
	private float MAX_MOVE_SPEED = 2.0f;
	public DateTime nowTime;
	private DateTime startTime;
	private float translationX = 0;
	private float translationY = 0;

	private float moveTime = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		nowTime = DateTime.UtcNow;
		print (Time.deltaTime);

		// マウス入力で左クリックを押している間
		// GetMouseButtonDown(0)は押した時のみ、こっちの方が軽い気がする
		if (Input.GetMouseButton(0)) {
			// ここでの注意点は座標の引数にVector2を渡すのではなく、Vector3を渡すことである。　らしい。
			// Vector3でマウスがクリックした位置座標を取得する
			clickPosition = Input.mousePosition;
			//Debug.Log(clickPosition);

			// マウス位置座標をスクリーン座標からワールド座標に変換する
			// ワールドポシションならandroid実機テストの際ズレがなくなった
			worldClickPosition = Camera.main.ScreenToWorldPoint(clickPosition);
			worldClickPosition.z = 0f;

			MoveReadyClone();
			MoveClone();
		}	
		
	}

	public void SetPrefab () {
		transform.localPosition = new Vector3 (UnityEngine.Random.Range (-600, 600),
												UnityEngine.Random.Range (300, -300),
												0);

		pfLocalPositionX = transform.localPosition.x;
	}

	void MoveReadyClone() {

		var moveSpeedX = 0.0f;
		var moveSpeedY = 0.0f;
		var disX = worldClickPosition.x - transform.position.x;
		var disY = worldClickPosition.y - transform.position.y;
		var disXTime = Math.Abs(disX) / MAX_MOVE_SPEED;
		var disYTime = Math.Abs(disY) / MAX_MOVE_SPEED;
		// Debug.Log(listClone[0].transform.position.x);

		if (disXTime > disYTime) {
			moveTime = disXTime;
			moveSpeedX = disX / moveTime;
			moveSpeedY = disY / moveTime;
		} else { 
			moveTime = disYTime;
			moveSpeedX = disX / moveTime;
			moveSpeedY = disY / moveTime;
		}
		startTime = nowTime;
		// localPositionを使うとmoveSpeedに /130をしないといけない、なんで？
		translationX = Time.deltaTime * moveSpeedX; // / 130;
		translationY = Time.deltaTime * moveSpeedY; // / 130;

	}

	void MoveClone () {

	if (startTime + TimeSpan.FromSeconds(moveTime) > nowTime) {
		transform.Translate(translationX, translationY, 0f);		
		} 
	}
	
}
