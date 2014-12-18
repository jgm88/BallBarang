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
	public bool isGrounded;
	/// <summary>
	/// Númreo de superficies tipo "suelo" que estamos tocando.
	/// </summary>
	private int contactosConElSuelo = 0;
	/// <summary>
	/// Transform de la camara.
	/// </summary>
	private Transform anclaCamara;
	/// <summary>
	/// Direccion relativa a la camara. 
	/// </summary>
	private Vector3 realDirection;
	/// <summary>
	/// Factor del Power-Up de velocidad
	/// </summary>
	public int speedPowerUpFactor;

	// Use this for initialization
	void Start ()
	{

		//Empezamos en el aire
		isGrounded = false;
		//Obtenemos la camara
		anclaCamara = GameObject.Find ("Anchor").transform;

	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown (KeyCode.Space) && isGrounded)  
				rigidbody.AddForce (0, jumpForce, 0);

		if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0) 
		{
			realDirection = anclaCamara.TransformDirection (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			rigidbody.AddForce(realDirection *acceleration);
		}				
	}

	void OnCollisionEnter(Collision colision)
	{
		if (colision.gameObject.tag == "Ground" || colision.gameObject.tag == "Speed") 
		{
			contactosConElSuelo++;

		}

		if (colision.gameObject.tag == "Speed") 
		{
			rigidbody.velocity*=speedPowerUpFactor;
		}

		if(contactosConElSuelo > 0)
		{
			isGrounded = true;


		}
	
	}

	void OnCollisionExit(Collision colision)
	{
		if (colision.gameObject.tag == "Ground") 
		{
			contactosConElSuelo--;
			
		}

		if(contactosConElSuelo == 0)
		{
			isGrounded = false;

		}
	
	}

	

}
