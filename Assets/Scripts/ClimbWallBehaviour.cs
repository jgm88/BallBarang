using UnityEngine;
using System.Collections;

public class ClimbWallBehaviour : MonoBehaviour {

	public float force = 100f;
	private Vector3 direction;

	void Start(){
		direction = new Vector3(0f,0f,0f);
	}
	void Update(){
//		direction = Vector3(0f,Input.GetAxis ("Vertical"),0f);
	}


	void OnTriggerStay(Collider other){
		if(other.tag == "Player"){

			direction.y += force * Time.deltaTime;
			other.rigidbody.AddForce(direction.normalized *force);


		}
	}
}
