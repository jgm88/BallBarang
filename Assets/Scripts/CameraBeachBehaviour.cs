using UnityEngine;
using System.Collections;

public class CameraBeachBehaviour : MonoBehaviour {
	private float initialDistance;
//	private float currentDistance;
	// Use this for initialization
	void Start(){
		
		initialDistance = Vector3.Distance(transform.position, transform.parent.position);
		//currentDistance = initialDistance;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
