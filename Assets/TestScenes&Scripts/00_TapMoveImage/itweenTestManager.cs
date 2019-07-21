using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class itweenTestManager : MonoBehaviour {

	public GameObject obj;
	private GameObject rightButton;
	private GameObject leftButton;

	// Use this for initialization
	void Start () {

		rightButton = GameObject.Find("RightButton");
		rightButton.GetComponent<Button> ().onClick.AddListener(MoveLeft);
		leftButton = GameObject.Find ("LeftButton");
		leftButton.GetComponent<Button> ().onClick.AddListener(MoveDownRight);

		
	}
	

	public void MoveRight() {
		iTween.MoveTo (obj, iTween.Hash ("x", obj.transform.position.x+2, "time", 3.1f));
	}

	public void MoveLeft() {
		iTween.MoveTo (obj, iTween.Hash ("x", obj.transform.position.x-2, "time", 3));
	}
	// Update is called once per frame
	void Update () {
		
	}

	public void MoveDownRight () {
		iTween.MoveTo (obj, iTween.Hash ("x", obj.transform.position.x+2, "y", obj.transform.position.y-1, "time", 4f));
	}
}
