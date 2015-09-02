using UnityEngine;
using System.Collections;

public class walk_party : MonoBehaviour {
	public float speed2;
	public float stopDistance = 5.0f;
	public GameObject messageTarget;
	public GameObject Player;
	public string message;
	public float rotationSpeed = 360.0f;
	public float waitBaseTime = 0.000f;
	float waitTime;
	public Vector3 basePosition;

	public CharacterController partyController;
	Vector3 dir;
	public Vector3 velocity = Vector3.zero;
	Vector3 currentvelocity;
	float distance;
	public bool stop;
	walk playerScript;

	void Start () {
		partyController = GetComponent<CharacterController>();
		playerScript = Player.GetComponent<walk> ();
		stop = true;
		basePosition = transform.position;
		waitTime = waitBaseTime;
		dir = Vector3.zero;
	}

	void Update () {	 

		currentvelocity = velocity;
		dir = Player.transform.position - transform.position;
		distance = Vector3.Distance (Player.transform.position, transform.position);
			if (distance > stopDistance) {
		waitTime -= Time.deltaTime;
			if (waitTime <= 0.0f) {
				Findplayer (Player);
			}
			else{
				partyController.Move(Physics.gravity*Time.deltaTime);
			}
		}
		if (distance <= stopDistance) {
			waitTime = waitBaseTime;
	 		}
		if (stop == false) {
			partyController.Move(velocity*Time.deltaTime);
		}
	}


	public void Findplayer(GameObject player){
		Quaternion characterTargetRotation = Quaternion.LookRotation (dir);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, characterTargetRotation, rotationSpeed * Time.deltaTime);
		velocity = dir.normalized * playerScript.speed;
		velocity = Vector3.Lerp (currentvelocity, velocity, Mathf.Min(Time.deltaTime *3.0f, 1.0f));	
		velocity.y += Physics.gravity.y * 5.0f * Time.deltaTime;
		partyController.Move (velocity * Time.deltaTime);
	}
	public void FindJumpWall(GameObject jumpWall){
			velocity = transform.forward * 10.0f;
			velocity.y += playerScript.jumpPower;
			partyController.Move(velocity*Time.deltaTime);
		}
}
	