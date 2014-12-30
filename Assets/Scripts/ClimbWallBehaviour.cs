using UnityEngine;
using System.Collections;

public class ClimbWallBehaviour : MonoBehaviour {

	/// <summary>
	/// Angulo para rotar el Anchor
	/// </summary>
	public float rotationAngle;
	/// <summary>
	/// Fuerza de atraccion
	/// </summary>
	public float force = 5f;
	/// <summary>
	/// Direccion de atraccion
	/// </summary>
	private Vector3 direction;

	private GameObject player;
	private PlayerMovement playerMovement;

	private AnchorBehaviour anchorBehaviuor;


	void Start(){

		direction = new Vector3(0f,0f,0f);

		player = GameObject.FindWithTag("Player");
		playerMovement = player.GetComponent<PlayerMovement>();
		anchorBehaviuor = GameObject.FindWithTag("AnchorCamera").GetComponent<AnchorBehaviour>();
	}
	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){

			anchorBehaviuor.rotationAngle = rotationAngle;
			playerMovement.startClimbing();

		}
	}
	void OnTriggerStay(Collider other){
		if(other.tag == "Player"){
			//Debemos mantener los flags de climbing
			player.rigidbody.useGravity = false;
			playerMovement.isClimbing = true;

			direction = transform.position;
			direction.y = 0f;
			direction.z = 0f;
			other.rigidbody.AddForce(direction * force);


		}
	}
	void OnTriggerExit(Collider other){
		if(other.tag == "Player"){
			playerMovement.stopClimbing();
		}
	}
}
