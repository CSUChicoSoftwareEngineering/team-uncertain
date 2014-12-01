using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
	public GameObject player;

	int jumpSpeed = 15;
	int playerSpeed = 10;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;
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
			if (Input.GetButton("Jump")){
				if(player.GetComponent<colorCollision>().curColor == "yellow")
					moveDirection.y = jumpSpeed*2;
				else
					moveDirection.y = jumpSpeed;
			}
		}
		if (player.GetComponent<colorCollision>().curColor == "blue" && controller.isGrounded == false){
			if(Input.GetButtonDown("Jump")){
				gravity = .05f;
				moveDirection.y = jumpSpeed;

				moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
				moveDirection = transform.TransformDirection(moveDirection * playerSpeed*15);

			}
		}
		gravity = 20.0f;
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}
