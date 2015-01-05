using UnityEngine;
using System.Collections;

public class ExplosiveWagonBehaviour : MonoBehaviour {


	public Vector3 destiny;
	public GameObject lamp;

	public void turnOn()
	{
		StartCoroutine (movementCor());
	}

	IEnumerator movementCor()
	{
		float smooth = 0.7f;
//		Vector3 movPos = new Vector3 (this.transform.position.x,this.transform.position.y,this.transform.position.z);

		while (Vector3.Distance(this.transform.position,destiny)>0.05f) {
			transform.position= Vector3.Lerp(this.transform.position,destiny,smooth*Time.deltaTime);
			yield return null;
		}
		lamp.rigidbody.isKinematic = false;
//		this.transform.position = destiny;
	}
}
