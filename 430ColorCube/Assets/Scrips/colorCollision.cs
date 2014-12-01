using UnityEngine;
using System.Collections;

public class colorCollision : MonoBehaviour {
	public string curColor = "clear";

	public Color lerpedColor = Color.white;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider collision) {
		print("collide");
		lerpedColor = gameObject.renderer.material.color;
		if(collision.gameObject.tag == "Blue"){
			while(lerpedColor != Color.blue){
				gameObject.renderer.material.color = Color.Lerp(lerpedColor, Color.blue, Time.time);
				lerpedColor = gameObject.renderer.material.color;
			}
			curColor = "blue";
			Destroy(collision.gameObject);
		}
		if(collision.gameObject.tag == "Red"){
			while(lerpedColor != Color.red){
				gameObject.renderer.material.color = Color.Lerp(lerpedColor, Color.red, Time.time);
				lerpedColor = gameObject.renderer.material.color;
			}
			curColor = "red";
			Destroy(collision.gameObject);
		}
		if(collision.gameObject.tag == "Yellow"){
			while(lerpedColor != Color.yellow){
				gameObject.renderer.material.color = Color.Lerp(lerpedColor, Color.yellow, Time.time);
				lerpedColor = gameObject.renderer.material.color;
			}
			curColor = "yellow";
			Destroy(collision.gameObject);
		}
	}
}
