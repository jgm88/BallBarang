using UnityEngine;
using System.Collections;

public class ArrowLauncherBehaviour : MonoBehaviour {

	public GameObject arrowPrefab;
	public Transform arrowEnd;
	public float force = 500f;
	public float delay = 3f;
	GameObject arrow;

	// Use this for initialization
	void Start () {
		StartCoroutine(shotArrow());

	}
	IEnumerator shotArrow(){
		while(true){

			arrow = Instantiate(arrowPrefab,transform.position, Quaternion.identity) as GameObject;
			arrow.transform.Rotate(0f,-90f,0f);
			arrow.rigidbody.AddForce(force,0f,0f);
			arrow.rigidbody.AddTorque(1000f,0f,0f);
			yield return new WaitForSeconds (delay);
		}
	}
}
