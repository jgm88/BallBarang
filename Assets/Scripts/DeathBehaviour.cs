using UnityEngine;
using System.Collections;

public class DeathBehaviour : MonoBehaviour {

	private GameObject player;
	public Vector3 respawnPosition;

	// Use this for initialization
	void Start () {
	
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnCollisionEnter(Collision colision)
	{
		
		if(colision.transform.tag == "Player"){
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

		player.transform.position = respawnPosition;
		player.rigidbody.isKinematic=false;

	}
}
