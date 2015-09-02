using UnityEngine;
using System.Collections;

public class SearchParty : MonoBehaviour {

	public string searchTag1 ="jumpWall";
	public GameObject messageTarget;
	public string message1;
	
	void Start () {
		
	}
	
	void Update () {
		
	}
	
	
	public void OnTriggerStay(Collider col){
		if(col.tag == searchTag1){
			messageTarget.SendMessage(message1,col.gameObject);
		}
	}
}
