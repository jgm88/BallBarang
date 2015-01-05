using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {


	/// <summary>
	/// Transform para rotacion de camara en pared
	/// </summary>
	public Transform transformZero;
	/// <summary>
	/// Transform para rotacion de camara en suelo
	/// </summary>
	public Transform transformInit;
	private RaycastHit rayHit;
	private bool isCorrected;
	private float initialDistance;
	private float currentDistance;
	private Vector3 correctedHitPoint;

	public void transformToZero(){
		transform.position = transformZero.position;
		transform.rotation = transformZero.rotation;
	}
	public void transformToInit(){
		transform.position = transformInit.position;
		transform.rotation = transformInit.rotation;

	}
	void Start(){
		
		initialDistance = Vector3.Distance(transform.position, transform.parent.position);
		currentDistance = initialDistance;
	}
	void LateUpdate(){
		isCorrected = false;

		// Sacamos el punto entre el objeto con el que colisiona el rayo entre la posicion deseada y el player(anchor)
		if(Physics.Linecast(transform.parent.position, transformInit.position, out rayHit)){

			//Corregimos la posicion para que la camara no se intruzca en el objetivo
			correctedHitPoint = rayHit.point;
			correctedHitPoint.y+=1;
			transform.position = Vector3.Lerp(transform.position, correctedHitPoint, 20 * Time.deltaTime);
			isCorrected = true;

			currentDistance = Vector3.Distance(transform.position, transform.parent.position);
		}
		//Si no se ha encontrado obstaculo entre la posicion deseada y el objetivo y la distancia actual es menor
		if(!isCorrected && currentDistance < initialDistance){

			transform.position = Vector3.Lerp(transform.position, transformInit.position, 20 * Time.deltaTime);
			currentDistance = Vector3.Distance(transform.position, transform.parent.position);
		}


	}
}
