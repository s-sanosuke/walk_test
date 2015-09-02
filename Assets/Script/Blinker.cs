using UnityEngine;
using System.Collections;

public class Blinker : MonoBehaviour {
	public GameObject check;
	public GameObject finish;
	private float nextTime;
	public float interval = 0.5f;	// 点滅周期
	// Use this for initialization
	void Start () {

		nextTime = Time.time;
		GetComponent<Renderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (check.GetComponent<EventTalk> ().callEvent == true) {
			if (Time.time > nextTime) {
				GetComponent<Renderer> ().enabled = !GetComponent<Renderer> ().enabled;
				nextTime += interval;
			}
		}
		if(finish.GetComponent<EventTalk>().callEvent== true){
			GetComponent<Renderer>().enabled = false;
		}

	}
}
