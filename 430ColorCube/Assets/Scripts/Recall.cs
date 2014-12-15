using UnityEngine;
using System.Collections;

public class Recall : MonoBehaviour {

	GameObject respawn;
	Vector3 start_pos;
	public GameObject player;

	Mesh initial_mesh;
	Color init_color;
	Material init_mat;
	void Start()
	{
		GameObject.Find("WinText").GetComponent<MeshRenderer>().enabled = false;

		if(this.gameObject.tag == "Skybox")
		{
			BoxCollider box_c = gameObject.GetComponent<BoxCollider>();
			box_c.size = new Vector3(214, 4, 95);
			box_c.center = new Vector3(78, 9, -47);

			GameObject.Find ("Ceiling").GetComponent<BoxCollider>().size = new Vector3 (200, .5f, 90);
		}
		init_mat = player.renderer.material;
		initial_mesh = player.GetComponent<MeshFilter> ().mesh;
		init_color = player.GetComponent<MeshRenderer> ().material.color;

		respawn = GameObject.Find ("Respawn");
		start_pos = respawn.transform.position;
	}

	void OnTriggerEnter(Collider collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			if( this.gameObject.tag == "Skybox")
			{
				collision.transform.parent = null;
				collision.transform.position = start_pos;
			}

			else if(this.gameObject.tag == "Winner")
			{
				GameObject.Find("WinText").GetComponent<MeshRenderer>().enabled = true;

				StartCoroutine (WinDelay(5, collision));
			}

			else if(this.gameObject.tag == "NextLevel")
			{
				GameObject.Find("WinText").GetComponent<MeshRenderer>().enabled = true;
				
				StartCoroutine (LvlDelay(5, collision));
			}

			collision.renderer.material = init_mat;
			collision.GetComponent<MeshFilter>().mesh = initial_mesh;
			collision.GetComponent<MeshRenderer>().material.color = Color.Lerp (player.GetComponent<MeshRenderer>().material.color, init_color, Time.time);


			GameObject[] destroyed = GameObject.FindGameObjectsWithTag("Destroyed");
			foreach( GameObject cube in destroyed)
			{
				cube.gameObject.GetComponent<MeshCollider>().enabled = true;
				cube.gameObject.GetComponent<MeshRenderer>().enabled = true;
				cube.gameObject.tag = "Untagged";
			}
		}
	}

	IEnumerator LvlDelay(float wait, Collider collision){
		collision.GetComponent<movement> ().enabled = false;
		yield return new WaitForSeconds(wait);
		collision.GetComponent<movement> ().enabled = true;
		Application.LoadLevel (1);
	}

	IEnumerator WinDelay(float wait, Collider collision)
	{
		collision.GetComponent<movement> ().enabled = false;
		yield return new WaitForSeconds(wait);
		collision.GetComponent<movement> ().enabled = true;
		Application.LoadLevel (0);
		//collision.transform.parent = null;
		//collision.transform.position = start_pos;
		//GameObject.Find("WinText").GetComponent<MeshRenderer>().enabled = false;
	}

}
