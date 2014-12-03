using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {

	// Use this for initialization
	public void onPickup(){
		gameObject.GetComponent<MeshRenderer> ().enabled = false;
		gameObject.GetComponent<BoxCollider> ().enabled = false;
		StartCoroutine ("Empty");
	}
	IEnumerator Empty(){
		yield return new WaitForSeconds (3f);
		gameObject.GetComponent<MeshRenderer> ().enabled = true;
		gameObject.GetComponent<BoxCollider> ().enabled = true;
	}
}
