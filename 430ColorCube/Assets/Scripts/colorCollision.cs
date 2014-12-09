using UnityEngine;
using System.Collections;

public class colorCollision : MonoBehaviour {
	public string curColor = "clear";
	public string secColor = "clear";
	Mesh purple;
	Mesh green;
	Mesh orange;
	public Material purpleMat;
	public Material greenMat;
	public Material orangeMat;
	public Mesh purp;	
	public Mesh oran;
	public Mesh gren;
	Mesh initialMesh;
	Mesh changeMesh;


	public Color lerpedColor = Color.white;

	// Use this for initialization
	void Start () {
		initialMesh = GetComponent<MeshFilter>().mesh;
		//purple = purp; //purp.GetComponent<MeshFilter>().mesh;
		//orange = oran;//.GetComponent<MeshFilter>().mesh;
		//green = gren;//.GetComponent<MeshFilter>().mesh;
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider collision) {
		changeMesh = collision.GetComponent<MeshFilter>().mesh;
		lerpedColor = gameObject.renderer.material.color;
		if(collision.gameObject.tag == "Blue"){
			if(lerpedColor == Color.red){
				gameObject.renderer.material = purpleMat;
				GetComponent<MeshFilter>().mesh = purp;

				curColor = "blue";
				secColor = "purple";
			}
			else if(lerpedColor == Color.yellow){
				gameObject.renderer.material = greenMat;
				GetComponent<MeshFilter>().mesh = gren;

				curColor = "blue";
				secColor = "green";
			}
			else{
				gameObject.renderer.material.color = Color.Lerp(lerpedColor, Color.blue, Time.time);
				GetComponent<MeshFilter>().mesh = changeMesh;

				lerpedColor = gameObject.renderer.material.color;
				curColor = "blue";
				secColor = "clear";
			}


			collision.gameObject.GetComponent<spawner>().onPickup();
		}
		if(collision.gameObject.tag == "Red"){
			if(lerpedColor == Color.blue){
				gameObject.renderer.material = purpleMat;
				GetComponent<MeshFilter>().mesh = purp;

				curColor = "blue"; //red
				secColor = "purple";
			}
			else if(lerpedColor == Color.yellow){
				gameObject.renderer.material = orangeMat;
				GetComponent<MeshFilter>().mesh = oran;

				curColor = "red";
				secColor = "orange";
			}
			else{
				gameObject.renderer.material.color = Color.Lerp(lerpedColor, Color.red, Time.time);
				GetComponent<MeshFilter>().mesh = changeMesh;

				lerpedColor = gameObject.renderer.material.color;
				curColor = "red";
				secColor = "clear";
			}

			collision.gameObject.GetComponent<spawner>().onPickup();
			//Destroy(collision.gameObject);
		}
		if(collision.gameObject.tag == "Yellow"){
			if(lerpedColor == Color.blue){
				gameObject.renderer.material = greenMat;
				GetComponent<MeshFilter>().mesh = gren;

				curColor = "yellow";
				secColor = "green";
			}
			else if(lerpedColor == Color.red){
				gameObject.renderer.material = orangeMat;
				GetComponent<MeshFilter>().mesh = oran;
				GetComponent<MeshCollider>().sharedMesh = oran;
				curColor = "yellow";
				secColor = "orange";
			}
			else{
				gameObject.renderer.material.color = Color.Lerp(lerpedColor, Color.yellow, Time.time);
				GetComponent<MeshFilter>().mesh = changeMesh;

				lerpedColor = gameObject.renderer.material.color;
				curColor = "yellow";
				secColor = "clear";
			}

			collision.gameObject.GetComponent<spawner>().onPickup();
		}
		if(collision.gameObject.tag == "Black"){
			while(lerpedColor != Color.white){
				gameObject.renderer.material.color = Color.Lerp(lerpedColor, Color.white, Time.time);
				GetComponent<MeshFilter>().mesh = initialMesh;

				lerpedColor = gameObject.renderer.material.color;
			}
			curColor = "clear";
			secColor = "clear";
		}
	}
}
