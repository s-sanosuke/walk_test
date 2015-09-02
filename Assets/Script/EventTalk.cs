using UnityEngine;
using System.Collections;

public class EventTalk : MonoBehaviour {
	public GameObject EventTxt;
	public string searchTag ="Player";
	public GameObject messageTarget;
	readText readScript;

	BoxCollider box;
	public bool callEvent = false;

    void Start () {
		readScript = EventTxt.GetComponent<readText> ();
		EventTxt.GetComponent<Canvas> ().enabled = false;
		box = GetComponent<BoxCollider> ();
	}

	void Update () {


		if (EventTxt.GetComponent<Canvas>().enabled == true) {
			Time.timeScale = 0.0f;
			if(Input.GetKey(KeyCode.Return) && readScript.readEnd == true ){
			EventTxt.GetComponent<Canvas>().enabled = false;
			Destroy(box,1.0f);
			messageTarget.GetComponent<walk>().rotationSpeed = 1000;		
			Time.timeScale = 1.0f;
			}
		}
	}

	public void OnTriggerEnter(Collider col){
		if (col.tag == searchTag) {
			EventTxt.GetComponent<Canvas> ().enabled = true;
			callEvent = true;
		}
	}
}
