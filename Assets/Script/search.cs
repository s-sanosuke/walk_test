using UnityEngine;
using System.Collections;

public class search : MonoBehaviour {

	public string searchTag ="jumpWall";
	public GameObject messageTarget;
	public string message;

	void Start () {
	
	}

	void Update () {
	
	}


	public void OnTriggerStay(Collider col){

		if(col.tag == searchTag){
			messageTarget.SendMessage(message,col.gameObject);
		}
	}
}