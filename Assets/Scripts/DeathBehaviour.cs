using UnityEngine;
using System.Collections;

public class DeathBehaviour : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {
	
		player = GameObject.FindGameObjectWithTag("Player");
	}
	



	void OnCollisionEnter(Collision colision)
	{
		
		if(colision.transform.tag == "Player" || colision.gameObject.GetComponentInChildren<Transform>().tag == "Player"){
			player.rigidbody.isKinematic=true;
			player.particleSystem.Play();
			StartCoroutine(Respawn());
		}
		
		
	}

	IEnumerator Respawn()
	{
		while(player.particleSystem.isPlaying)
		{
			yield return new WaitForEndOfFrame();
		}

		player.transform.position = player.GetComponent<SpawnBehaviour> ().respawn;
		player.rigidbody.isKinematic=false;

	}
}
