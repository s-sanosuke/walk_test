using UnityEngine;
using System.Collections;

public class Breakwall : MonoBehaviour {

	public GameObject party;
	walk_party partyScript; 
	string getTag = "sword";
	public GameObject parent;

	void Start () {
		partyScript = party.GetComponent<walk_party> ();
	}
	void Update () {
	}
	
	public void OnTriggerStay(Collider katana){

		if(katana.tag == getTag){
		partyScript.stop = true;
		partyScript.velocity = Vector3.zero;
			Destroy(parent);
		}
	

	}
}
	