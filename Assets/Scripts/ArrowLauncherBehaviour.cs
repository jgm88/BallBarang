using UnityEngine;
using System.Collections;

public class ArrowLauncherBehaviour : MonoBehaviour {

	public GameObject arrowPrefab;
	public Transform arrowEnd;
	public float delay = 3f;
	public float rotate = -90f;
	public Vector3 vForce;
	public Vector3 vTorque;
	GameObject arrow;

	// Use this for initialization
	void Start () {
		StartCoroutine(shotArrow());

	}
	IEnumerator shotArrow(){
		while(true){

			arrow = Instantiate(arrowPrefab,transform.position, Quaternion.identity) as GameObject;
			arrow.transform.Rotate(0f,rotate,0f);
			arrow.rigidbody.AddForce(vForce);
			arrow.rigidbody.AddTorque(vTorque);
			yield return new WaitForSeconds (delay);
		}
	}
}
