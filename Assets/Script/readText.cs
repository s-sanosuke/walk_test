using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class readText : MonoBehaviour {

	public int allText=2;
	GameObject[] talks;
	public GameObject eventArea;
	EventTalk  eventScript;
	int i;
	public bool readEnd;

	void Start () {
		talks = new GameObject[allText];
		readEnd = false;
		eventScript = eventArea.GetComponent<EventTalk> ();

		for (i =0; i< allText; i++) {
			if(i == 0){
			talks [i] = transform.FindChild ("Talk").gameObject;
			talks [i].GetComponent<Text> ().enabled = true;
			}
			else if (i >= 1) {
			talks [i] = transform.FindChild ("Talk (" + i.ToString() + ")").gameObject;
			talks [i].GetComponent<Text> ().enabled = false;
			}
		}
			i = 0;
	}

	void Update () {
	
		 if (i < allText-1  &&Input.GetKeyDown (KeyCode.Return) && eventScript.callEvent == true) {
			talks [i].GetComponent<Text> ().enabled = false;
			talks [i + 1].GetComponent<Text> ().enabled = true;
			i++;
		} else if (i == allText - 1 && Input.GetKeyDown (KeyCode.Return) && eventScript.callEvent == true) {
			readEnd =true;
		}
		}
	}
