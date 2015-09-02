using UnityEngine;
using System.Collections;

public class Smallwall : MonoBehaviour {

	public string searchTag1 ="jumpWall";
	public string searchTag2 ="BreakWall";
	public GameObject messageTarget;
	public string message1;
	public string message2; 

	void Start () {
	
	}
	void Update () {

	}

	public void OnTriggerStay(Collider col){
		if(col.tag == searchTag1){
			messageTarget.SendMessage(message1,col.gameObject);
		}
		if (col.tag == searchTag2) {
			messageTarget.SendMessage(message2,col.gameObject);
		}
	}
}