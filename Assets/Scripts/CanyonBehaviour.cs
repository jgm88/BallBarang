using UnityEngine;
using System.Collections;

public class CanyonBehaviour : MonoBehaviour {
	
	private GameObject player;
	public float canyonForce;


	// Use this for initialization
	void Start () {
	
		player = GameObject.FindGameObjectWithTag("Player");
	}
	

	void Update () {


	}

	void OnCollisionEnter(Collision colision)
	{

		if(colision.transform.tag == "Player"){

			player.SetActive(false);
			player.transform.position = transform.position + transform.up * 4;
			StartCoroutine(CanyonLaunch());
		}


	}

	IEnumerator CanyonLaunch()
	{
		player.rigidbody.isKinematic = true;
		yield return new WaitForSeconds(2f);
		player.SetActive(true);
		player.rigidbody.isKinematic = false;
		player.rigidbody.AddForce(transform.TransformDirection(Vector3.up) * canyonForce);
		//player.rigidbody.isKinematic = false;
		//used = true;
	}

}
