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

	public void transformToZero(){
		transform.position = transformZero.position;
		transform.rotation = transformZero.rotation;
	}
	public void transformToInit(){
		transform.position = transformInit.position;
		transform.rotation = transformInit.rotation;

	}
}
