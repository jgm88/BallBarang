using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {

	public float Acceleration;
	public float jumpForce;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0) {
				Debug.Log ("Moviendo");
			rigidbody.AddForce (Input.GetAxis ("Horizontal") * Acceleration, Input.GetAxis ("Jump")*jumpForce, Input.GetAxis ("Vertical") * Acceleration);
		} else if (Input.GetAxis ("Jump")!=0) {
				Debug.Log ("Saltando");
			rigidbody.AddForce(0,jumpForce,0);
		}//else 	rigidbody.velocity = Vector3.zero;

	}
}
