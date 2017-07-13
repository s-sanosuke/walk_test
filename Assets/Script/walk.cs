using UnityEngine;
using System.Collections;

// git start
public class walk : MonoBehaviour {
	public float speed=5;
	public float lowSpeed=5;
	public float hiSpeed=10;
	public float jumpPower=10;
	public float rotationSpeed = 360.0f;
	public float timer=0;
	public Vector3 direction = Vector3.zero;
	public Vector3 Normal;
	CharacterController playerController;
	public GameObject Party;
	public walk_party partyScript;
	public CameraController cameraScript;
	public GameObject Camera;
	Transform vecCamera;
	Vector3 inputDirection;
    Vector3 inputX2;
    Vector3 inputY2;
    float inputX;
    float inputY;


	void Start () {
		playerController = GetComponent<CharacterController>();
		partyScript = Party.GetComponent<walk_party>();
		vecCamera = Camera.GetComponent<Transform>();
		cameraScript = Camera.GetComponent<CameraController>();
		timer = 0;
		speed = lowSpeed;
//		partyScript.speed2 = lowSpeed;
	
		inputDirection= Vector3.zero;
		inputX2 = Vector3.zero;
		inputY2 = Vector3.zero;

	}

	void Update () {
		inputX2 = Vector3.zero;
		inputY2 = Vector3.zero;


		if (playerController.isGrounded) {
			inputX = Input.GetAxisRaw("Horizontal");
			if(inputX==1){
		       inputX2 = vecCamera.transform.right;
			}
			if(inputX == -1){
				inputX2 = -vecCamera.transform.right;
			}
			 inputY = Input.GetAxisRaw("Vertical");
			if(inputY==1){
			   inputY2 = vecCamera.transform.forward;
			}
			if(inputY == -1){
				inputY2 = -vecCamera.transform.forward;

			}
			inputDirection = inputX2+inputY2;
			inputDirection.y = 0.0f;
		    Normal = inputDirection.normalized;
			Vector3 Direction = Vector3.Normalize(inputDirection) * speed;

			if (inputX == 1 || inputY == -1 || inputX == -1 || inputY == 1){

				Quaternion characterTargetRotation = Quaternion.LookRotation(inputDirection);
				transform.rotation = Quaternion.RotateTowards(transform.rotation,characterTargetRotation,rotationSpeed * Time.deltaTime);
					direction = Direction;
				timer +=Time.deltaTime;
				if(timer>10){
					speed=hiSpeed;
//					partyScript.speed2=hiSpeed;
				}
			
			}
			else if(inputX == 0 && inputY==0){
				direction = Vector3.zero;
				timer =0.0f;
				speed = lowSpeed;

			}
		}
		direction.y += Physics.gravity.y * 5.0f * Time.deltaTime;
		playerController.Move(direction * Time.deltaTime);

	}

	public void FindJumpWall(GameObject jumpWall){
	
		if (Input.GetButton ("Jump")) {
			direction= transform.forward * 10.0f;
			direction.y += jumpPower;
			playerController.Move(direction*Time.deltaTime);
		}
	}
	public void FindBreakWall(GameObject breakWall){
		if (Input.GetKeyDown(KeyCode.F)) {
			Vector3 attack = breakWall.transform.position - partyScript.transform.position;
			attack.y= 0.0f;
			partyScript.velocity =attack.normalized*10.0f;
			partyScript.stop = false;
		}
	}
}
