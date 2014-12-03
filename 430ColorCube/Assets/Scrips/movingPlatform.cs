using UnityEngine;
using System.Collections;

public class movingPlatform : MonoBehaviour {
	Vector3 startPosition;
	Vector3 MoveDirection;
	int MoveDistance = 32;
	Vector3 endPosition;
	public Collider ColliderPlatform;
	bool OneWay;
	float _t;
	float MoveSpeed = .25f;
	bool stop = false;

	void Start () {
		startPosition = transform.position;
		MoveDirection = new Vector3 (1, 0, 0);
		//MoveDirection is Vector3 - usually a norm vector like (0,1,0)
		//which would cause the platform to move along the Y axis
		endPosition = startPosition + (MoveDistance * MoveDirection);
		//ColliderPlatform holds a collider that is not a trigger, as 
		//well as the mesh, and must move with the whole platform
		ColliderPlatform.transform.parent = transform;
	}
	void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.tag == ("Player"))
		{
			collision.transform.parent = transform;
		}
	}
	void OnTriggerExit(Collider collision)
	{
		if (collision.gameObject.tag == ("Player"))
		{
			collision.transform.parent = null;
		}
	}
	void Update ()  
	{ 
		if (OneWay) //&& stop == false) 
			_t += Time.deltaTime * MoveSpeed; 
		else //if(!OneWay && stop == false)
			_t -= Time.deltaTime * MoveSpeed; 
		if (stop == false){
			transform.position = Vector3.Lerp(startPosition, endPosition, _t); 
		}
		_t = Mathf.Clamp(_t,0.0f,1.0f); //avoids platforms getting stuck
		
		if (transform.position == endPosition || transform.position == startPosition){ 
			StartCoroutine (moveDelay(2));
			OneWay = !OneWay; 
			stop = true;
		}
	}
	IEnumerator moveDelay(float wait){
		yield return new WaitForSeconds(wait);
		stop = false;
	}
}