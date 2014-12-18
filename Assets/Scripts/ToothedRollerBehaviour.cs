using UnityEngine;
using System.Collections;

public class ToothedRollerBehaviour : MonoBehaviour {

	public float rotationVelocity = 4f;
	public float force = 100;
	private Vector3 direction;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Rotate(0f,rotationVelocity,0f);
	}
	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){

			if (other.rigidbody){

				direction = other.transform.position - transform.position;
				direction.y = 0;
				other.rigidbody.AddForce(direction.normalized * force);
			}
		}
	}

}
