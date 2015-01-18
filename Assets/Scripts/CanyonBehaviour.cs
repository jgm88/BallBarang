using UnityEngine;
using System.Collections;

public class CanyonBehaviour : MonoBehaviour {
	
	private GameObject player;
	public float canyonForce;
	private bool used;


	// Use this for initialization
	void Start () {
	
		player = GameObject.FindGameObjectWithTag("Player");
		used = false;
	}
	

	void Update () {


	}

	void OnCollisionEnter(Collision colision)
	{

		if(colision.transform.tag == "Player" && !used){

			player.SetActive(false);
			player.transform.position = transform.position + transform.forward * 4;
			StartCoroutine(CanyonLaunch());
		}


	}

	IEnumerator CanyonLaunch()
	{
		yield return new WaitForSeconds(2f);
		player.SetActive(true);
		player.rigidbody.AddForce(transform.TransformDirection(Vector3.up) * canyonForce);
		used = true;
	}

}
