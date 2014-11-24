using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {
	/// <summary>
	/// Aceleración del movimiento de la bola (Default:5).
	/// </summary>
	public float acceleration;
	/// <summary>
	/// Fuerza del salto (Default:350)
	/// </summary>
	public float jumpForce;
	/// <summary>
	/// Estamos en el suelo o en el aire.
	/// </summary>
	private bool isGrounded;
	/// <summary>
	/// Númreo de superficies tipo "suelo" que estamos tocando.
	/// </summary>
	private int contactosConElSuelo = 0;

	// Use this for initialization
	void Start () {
	
		isGrounded = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)  
			rigidbody.AddForce (0, jumpForce, 0);
				

		if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0) {
			Debug.Log ("Moviendo");
			rigidbody.AddForce (Input.GetAxis ("Horizontal") * acceleration, 0, Input.GetAxis ("Vertical") * acceleration);
		}

	}

	void OnCollisionEnter(Collision colision)
	{
		if (colision.gameObject.tag == "Suelo") 
		{
			contactosConElSuelo++;

		}

		if(contactosConElSuelo > 0)
		{
			isGrounded = true;
			Debug.Log("En el suelo");

		}
	
	}

	void OnCollisionExit(Collision colision)
	{
		if (colision.gameObject.tag == "Suelo") 
		{
			contactosConElSuelo--;
			
		}

		if(contactosConElSuelo == 0)
		{
			isGrounded = false;
			Debug.Log ("En el aire");
		}
	
	}

	

}
