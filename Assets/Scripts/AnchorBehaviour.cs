using UnityEngine;
using System.Collections;

public class AnchorBehaviour : MonoBehaviour {

	/// <summary>
	/// Angulo para rotar el Anchor, se recoge de los Walls
	/// </summary>
	public float rotationAngle;
	/// <summary>
	/// Al justo subir a una pared, para saber cuando rotar la camara
	/// </summary>
	private bool isOnWall;
	/// <summary>
	/// Rotara la camara una vez
	/// </summary>
	private bool rotateCamera;

	/// <summary>
	/// Posicion del item a seguir. 
	/// </summary>
	private GameObject player;

	private CameraBehaviour cameraBehaviour;

	private MouseLook mouseLook;
	private PlayerMovement playerMovement;

	public Transform transform270r;
	public Transform transform90r;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerMovement = player.GetComponent<PlayerMovement>();
		
		cameraBehaviour = GameObject.FindWithTag("MainCamera").GetComponent<CameraBehaviour>();
		mouseLook = gameObject.GetComponent<MouseLook>();

		isOnWall = false;
		rotateCamera = false;
	}

	void Update () {
		transform.position = player.transform.position;

		if(rotateCamera && !playerMovement.isGrounded){

			cameraBehaviour.transformToZero();

			isOnWall = true;
			rotateCamera = false;

			if(rotationAngle == 90f)
				transform.rotation = transform90r.rotation;			
			else if(rotationAngle == 270f)
				transform.rotation = transform270r.rotation;
		}
			
	}
	public void startClimbing(){
		if(!isOnWall)
			rotateCamera = true;

		mouseLook.enabled = false;			
			
	}
	public void stopClimbing(){
		mouseLook.enabled = true;
		isOnWall = false;
		cameraBehaviour.transformToInit();
	}
}
