using UnityEngine;
using System.Collections;

public class destroy : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter(Collider collision){
		if (collision.gameObject.tag == "Player") {
			print("collide");
			if(collision.gameObject.GetComponent<movement>().smash == true){
				Destroy(this.gameObject);
			}
		}
	}
}
