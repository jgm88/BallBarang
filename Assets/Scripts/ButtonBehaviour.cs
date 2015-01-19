using UnityEngine;
using System.Collections;

public class ButtonBehaviour : MonoBehaviour {


	public DoorColors colorButton;

	private GameObject finalDoorCamera;
	private bool used;

	// Use this for initialization
	void Start () {

		finalDoorCamera = GameObject.Find ("FinalDoorCamera");
		used = false;

	}
	
	void OnCollisionEnter(Collision colision)
	{
		if (colision.transform.tag == "Player" && !used)
			StartCoroutine ("DeactivateColor", colorButton);


	}


	IEnumerator DeactivateColor(DoorColors color)
	{
		Camera temp = Camera.main;
		temp.enabled = false;
		finalDoorCamera.camera.enabled=true;
		yield return new WaitForSeconds (1f);
		GameObject.Find("FinalFloor").SendMessage ("QuitColor", color);
		yield return new WaitForSeconds (1f);
		transform.renderer.material.color = Color.black;
		finalDoorCamera.camera.enabled = false;
		temp.enabled = true;
		used = true;	


	}
}
