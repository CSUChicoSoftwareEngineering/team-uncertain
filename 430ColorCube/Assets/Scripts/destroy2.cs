using UnityEngine;
using System.Collections;

public class destroy2 : MonoBehaviour {

	BoxCollider box_c;

	void Start()
	{
		box_c = GetComponent<BoxCollider>() as BoxCollider;
		Vector3 b_size = new Vector3 (box_c.size.x, box_c.size.y + 1f, box_c.size.z + 1f);
		box_c.size = b_size;
		this.gameObject.SetActive (true);
	}
	// Use this for initialization
	void OnTriggerEnter(Collider collision){
		if (collision.gameObject.tag == "Player") {
			if(collision.gameObject.GetComponent<movement>().smash2 == true){
				//Destroy(this.gameObject);
				this.gameObject.GetComponent<MeshCollider>().enabled = false;
				this.gameObject.GetComponent<MeshRenderer>().enabled = false;
				this.gameObject.tag = "Destroyed";
			}
		}
	}
}
