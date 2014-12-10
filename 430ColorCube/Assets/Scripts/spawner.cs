using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {

	public Material Orig_color;

	void Start()
	{
		this.renderer.material = Orig_color;
	}
	// Use this for initialization
	public void onPickup(){
		gameObject.GetComponent<MeshRenderer> ().enabled = false;
		//gameObject.GetComponent<BoxCollider> ().enabled = false;
		this.renderer.material = Orig_color;
		StartCoroutine ("Empty");
	}
	IEnumerator Empty(){
		yield return new WaitForSeconds (3f);
		gameObject.GetComponent<MeshRenderer> ().enabled = true;
		//gameObject.GetComponent<BoxCollider> ().enabled = true;
		this.renderer.material = Orig_color;
	}
}
