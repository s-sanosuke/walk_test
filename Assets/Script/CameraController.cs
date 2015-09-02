using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform target;
	public float distance = 4.0f;
	public float height = 2.0f;
	public Vector3 posi;
	public GameObject  look;
	 walk playScript;

	Vector3 velocity = Vector3.zero;
	Vector3 currentvelocity;
	bool reset;

	void Start () {
		playScript = look.GetComponent<walk>();
		target = look.GetComponent<Transform> ();
		reset = true;
	}

	void Update () {

		currentvelocity = velocity;

		Vector3 dir = target.position - transform.position;
		float distance = Vector3.Distance(target.transform.position, transform.position);
		posi = dir.normalized * playScript.speed;
		Vector3 posi2 = target.position + (Vector3.up * height);
	
		RaycastHit hitInfo;
		if(Physics.Linecast(transform.position,target.position,out hitInfo,1<<LayerMask.NameToLayer("Ground"))){
			posi = hitInfo.point;
			posi.y = posi2.y;
			transform.position =posi;
		}

		posi.y = posi2.y;
		velocity = posi;

	if (transform.position.y < height) {
			velocity.y = playScript.speed;
		} else if (transform.position.y > height) {
			velocity.y = -playScript.speed;
		} else {
			velocity.y= 0.0f;
		}

		velocity = Vector3.Lerp (currentvelocity, velocity, Mathf.Min (Time.deltaTime * 1.0f, 1.0f));

		
		if (Input.GetKey(KeyCode.R)) {
			Camerareset(transform.right.normalized);
		}
		else if (Input.GetKey(KeyCode.E)) {
			Camerareset(-transform.right.normalized);
		}
		else if (reset == true && distance > 13.0f) {
			transform.position = (transform.position+(velocity * Time.deltaTime));
		}
		else if (reset == true && distance < 8.0f && !Physics.Linecast(transform.position,target.position,out hitInfo,1<<LayerMask.NameToLayer("Ground"))) {
			Vector3 outsight = -(transform.forward);
			outsight.y=0.0f;
			velocity =Vector3.zero;
			transform.position = (transform.position + (outsight.normalized * playScript.speed *Time.deltaTime));
		}
		transform.LookAt (target);
	}

	public void Camerareset(Vector3 resetrota){

		Vector3 resetVec = transform.forward.normalized;
		resetVec.y = 0.0f;

		resetrota.y = 0.0f;

		transform.position = (transform.position + (resetrota * 30.0f * Time.deltaTime));

//		if(resetVec.x <= playScript.transform.forward.x + 0.1f && resetVec.x >= playScript.transform.forward.x - 0.1f &&
//		   resetVec.z <=playScript.transform.forward.z +0.1f && resetVec.z >= playScript.transform.forward.z - 0.1f) {
	
//		}
	}
}

