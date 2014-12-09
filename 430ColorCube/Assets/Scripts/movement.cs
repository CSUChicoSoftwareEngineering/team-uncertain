using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
	public GameObject player;
	int chargeTime = 0;
	public bool smash = false;
	bool charge = true;
	int jumpSpeed = 15;
	int playerSpeed = 10;
	public float gravity = 40.0F;
	private Vector3 moveDirection = Vector3.zero;
	public Camera playerCam;


	void Start(){
		playerCam.camera.enabled = true;
	}

	void Update() {
		CharacterController controller = GetComponent<CharacterController>();
		float MoveHorizontal = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
		float MoveVertical = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;
		// Move the Player
	//	transform.Translate(Vector3.forward * MoveVertical);
		transform.Rotate(0, playerSpeed * MoveHorizontal, 0);
		if (controller.isGrounded) {
			moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection * playerSpeed);
			if (Input.GetButton("Charge") && player.GetComponent<colorCollision>().curColor == "red" 
			    || Input.GetButton("Charge") && player.GetComponent<colorCollision> ().secColor == "orange" || Input.GetButton("Charge") && player.GetComponent<colorCollision>().secColor == "purple") {
				if(charge == true){
					smash = true;
					float curSpeed = playerSpeed * Input.GetAxis("Vertical");
					Vector3 forward = transform.TransformDirection(Vector3.forward);
					controller.SimpleMove(forward * curSpeed* 10);
					chargeTime++;
					if(chargeTime == 30){
						charge = false;
						smash = false;
					}
				}
			}
			else{
				smash = false;
			}
			if(Input.GetButtonUp("Charge")){
				StartCoroutine("Recharge");
			}
			if (Input.GetButtonDown("Jump")){
				if(player.GetComponent<colorCollision>().curColor == "yellow" 
				   || player.GetComponent<colorCollision> ().secColor == "orange" || player.GetComponent<colorCollision>().secColor == "green")
					moveDirection.y = jumpSpeed*1.5f;
				else
					moveDirection.y = jumpSpeed;
			}
		}
		if (Input.GetButton("Charge") && player.GetComponent<colorCollision> ().secColor == "purple"){
			if(charge == true){
				smash = true;
				float curSpeed = playerSpeed * Input.GetAxis("Vertical");
				Vector3 forward = transform.TransformDirection(Vector3.forward);
				controller.SimpleMove(forward * curSpeed* 10);
				chargeTime++;
				if(chargeTime == 30){
					charge = false;
					smash = false;
				}
			}
			else{
				smash = false;
			}
			if(Input.GetButtonUp("Charge")){
				StartCoroutine("Recharge");
			}
		}
		if (controller.isGrounded == false) {
			if(Input.GetButton("Charge") && player.GetComponent<colorCollision>().secColor == "orange"){
				smash = true;
				float curSpeed = playerSpeed * Input.GetAxis("Vertical");
				gravity = 240f;
			}

		}


		if (player.GetComponent<colorCollision>().curColor == "blue" && controller.isGrounded == false 
		    || player.GetComponent<colorCollision> ().secColor == "purple" && controller.isGrounded == false){
			if(Input.GetButton("Jump") && moveDirection.y < 1f){
				gravity = 30f;
				moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
				moveDirection = transform.TransformDirection(moveDirection * playerSpeed);
			}

		}
		if (player.GetComponent<colorCollision> ().curColor == "blue" 
		    || player.GetComponent<colorCollision> ().secColor == "purple" || player.GetComponent<colorCollision>().secColor == "green") {
			moveDirection.y -= gravity * Time.deltaTime;
		}
		else {
			moveDirection.y -= gravity * Time.deltaTime;

		}
		controller.Move(moveDirection * Time.deltaTime);
		gravity = 20f;
	}
	IEnumerator Recharge(){
		yield return new WaitForSeconds (3f);
		charge = true;
		chargeTime = 0;
	}

}
