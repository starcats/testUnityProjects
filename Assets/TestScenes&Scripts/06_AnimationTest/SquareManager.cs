using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SquareManager : MonoBehaviour {

	Animation square2Anim;
	public static int countNo = 0;

	// Use this for initialization
	void Start () {
		countNo ++;
		this.gameObject.GetComponent<Button> ().onClick.AddListener (Square2Tap);
		GameObject square2 = transform.Find ("Square2").gameObject;
		square2Anim = square2.GetComponent<Animation> ();
		Text squareText = transform.Find ("SquareText").gameObject.GetComponent<Text> ();
		squareText.text =  "" + countNo;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Square2Tap () {
		square2Anim.Play ();
	}
}
