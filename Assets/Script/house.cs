using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class house : MonoBehaviour {
	public GameObject window;
	public string searchTag ="Player";
	public GameObject textWindow;
	public GameObject texts;

	float waitTime =4.0f;
	bool  getText = false;

	void Start () {
//		window.GetComponent<Canvas> ();
		textWindow.SetActive (false);
		texts.SetActive (false);
	}

	void Update(){

		if (getText == true) {
			waitTime -= Time.deltaTime;
			if (waitTime <= 0.0f) {
				textWindow.SetActive(false);
				texts.SetActive(false);
				waitTime =4.0f;
			}
		}
	}

	public void OnTriggerEnter(Collider col){
		if (col.tag == searchTag) {
			textWindow.SetActive(true);
			texts.SetActive(true);
			getText = true;
		}
	}
}
