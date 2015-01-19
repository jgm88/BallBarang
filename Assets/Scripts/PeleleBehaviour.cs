using UnityEngine;
using System.Collections;

public class PeleleBehaviour : MonoBehaviour {

	public float rotate = 1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0f,rotate,0f, Space.Self);
	}
}
