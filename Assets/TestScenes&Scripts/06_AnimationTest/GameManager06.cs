using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class GameManager06 : MonoBehaviour {

	Animator btn3Anim;
	//Animator imageAnim;
	Animation imageAnim;
	GameObject canvas;

	// Use this for initialization
	void Start () {
		Button btn1 = GameObject.Find ("Button1").GetComponent<Button> ();
		btn1.onClick.AddListener (Btn1Tap);


		// なんかここでエラー出てたよ
		
		print ("right");

		GameObject btn3 = GameObject.Find ("Button3");
		btn3.GetComponent<Button> ().onClick.AddListener (Btn3Tap);
		btn3Anim = btn3.GetComponent<Animator> ();

		Button btn4 = GameObject.Find ("Button4").GetComponent<Button> ();
		btn4.onClick.AddListener (Btn4Tap);

		GameObject image = GameObject.Find ("Image");
		//imageAnim = image.GetComponent<Animator> ();
		imageAnim = image.GetComponent<Animation> ();

		canvas = GameObject.Find ("CanvasBack");
		var square = Resources.Load<GameObject> ("Prefabs/Square");

		for (int j = 0; j < 3; j++) {
			for (int i = 0; i < 3; i++) {
				var pf = Instantiate<GameObject> (square);
				pf.transform.SetParent (canvas.transform, false);
				var x = i * 120.0f - 120.0f;
				var y = j * -120.0f - 320.0f;
				pf.transform.localPosition = new Vector3 (x, y, 0f);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Btn1Tap () {
		print ("a");
	}

	void Btn3Tap () {
		btn3Anim.Play ("Button3", 0, 0f);
	}

	void Btn4Tap () {
		imageAnim.Play ();
	}
}
