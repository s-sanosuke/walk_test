using UnityEngine;
using System.Collections;

public class Clear : MonoBehaviour {

	public GameObject clearEvent;
	readText readScript;

//	Text timerText;
	
	GameObject endGame;
	GameObject retry;
	GameObject gameClear;

	void Start () {

		readScript = clearEvent.GetComponent<readText> ();

		retry = transform.FindChild ("retryClear").gameObject;
		endGame = transform.FindChild("endGameClear").gameObject;
		gameClear = transform.FindChild ("gameClear").gameObject;
		retry.SetActive(false);
		endGame.SetActive(false);
		gameClear.SetActive (false);	
	}

	void Update () {

		if (readScript.readEnd == true) {
			gameClear.SetActive (true);
			Time.timeScale = 0;
			if (Input.GetKeyDown (KeyCode.Return)) {
				retry.SetActive (true);
				endGame.SetActive (true);
			}
		}

	}
}
