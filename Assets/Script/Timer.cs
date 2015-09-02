using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	
	Text timerText;
	public float timeLimit = 60.0f;
	float time;

	public GameObject clearEvent;
	readText readScript;

	GameObject endGame;
	GameObject retry;
	GameObject gameOver;
	GameObject gameClear;

	void Start () {

		Time.timeScale = 1.0f;
		readScript = clearEvent.GetComponent<readText> ();
		timerText = GetComponent<Text>();
		time = timeLimit;
		retry = transform.FindChild ("retryOver").gameObject;
		endGame = transform.FindChild("endGameOver").gameObject;
		gameOver = transform.FindChild ("gameOver").gameObject;
		gameClear = transform.FindChild ("gameClear").gameObject;
		retry.SetActive(false);
		endGame.SetActive(false);
		gameOver.SetActive (false);
		gameClear.SetActive (false);

	}

	void Update () {

		time -=  Time.deltaTime;
		timerText.text = "Time: " + time;
		if(time <= 0.0f){
			gameOver.SetActive(true);
			Time.timeScale=0;
			if(Input.GetKeyDown (KeyCode.Return)){
				retry.SetActive(true);
				endGame.SetActive(true);
			}
		}
		if (readScript.readEnd == true) {
			gameClear.SetActive (true);
			Time.timeScale = 0;
			if(Input.GetKeyDown (KeyCode.Return)) {
				retry.SetActive (true);
				endGame.SetActive (true);
			}
		}
	}
}
