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
	public Material yellowMat;
	public Material redMat;
	public Material blueMat;
	public Material whiteMat;
	public Mesh purp;	
	public Mesh oran;
	public Mesh gren;
	Mesh initialMesh;
	Mesh changeMesh;
	
	
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
		if(collision.gameObject.tag == "Blue"){
			if(curColor == "red" && secColor == "clear"){
				gameObject.renderer.material = purpleMat;
				GetComponent<MeshFilter>().mesh = purp;
				curColor = "blue";
				secColor = "purple";
			}
			else if(curColor == "yellow" && secColor == "clear"){
				gameObject.renderer.material = greenMat;
				GetComponent<MeshFilter>().mesh = gren;
				curColor = "blue";
				secColor = "green";
			}
			else{
				gameObject.renderer.material = blueMat;
				GetComponent<MeshFilter>().mesh = changeMesh;
				curColor = "blue";
				secColor = "clear";
			}
			
			
			collision.gameObject.GetComponent<spawner>().onPickup();
		}
		if(collision.gameObject.tag == "Red"){
			if(curColor == "blue" && secColor == "clear"){
				gameObject.renderer.material = purpleMat;
				GetComponent<MeshFilter>().mesh = purp;
				curColor = "blue"; //red
				secColor = "purple";
			}
			else if(curColor == "yellow" && secColor == "clear"){
				gameObject.renderer.material = orangeMat;
				GetComponent<MeshFilter>().mesh = oran;
				curColor = "red";
				secColor = "orange";
			}
			else{
				gameObject.renderer.material = redMat;
				GetComponent<MeshFilter>().mesh = changeMesh;
				curColor = "red";
				secColor = "clear";
			}
			
			collision.gameObject.GetComponent<spawner>().onPickup();
			//Destroy(collision.gameObject);
		}
		if(collision.gameObject.tag == "Yellow"){
			if(curColor == "blue" && secColor == "clear"){
				gameObject.renderer.material = greenMat;
				GetComponent<MeshFilter>().mesh = gren;
				curColor = "yellow";
				secColor = "green";
			}
			else if(curColor == "red" && secColor == "clear"){
				gameObject.renderer.material = orangeMat;
				GetComponent<MeshFilter>().mesh = oran;
				curColor = "yellow";
				secColor = "orange";
			}
			else{
				gameObject.renderer.material = yellowMat;
				GetComponent<MeshFilter>().mesh = changeMesh;
				curColor = "yellow";
				secColor = "clear";
			}
			
			collision.gameObject.GetComponent<spawner>().onPickup();
		}
		if(collision.gameObject.tag == "Black" || collision.gameObject.tag == "Skybox" || collision.gameObject.tag == "Winner"){
			gameObject.renderer.material = whiteMat;
			GetComponent<MeshFilter>().mesh = initialMesh;
			
			curColor = "clear";
			secColor = "clear";
		}
	}
}
