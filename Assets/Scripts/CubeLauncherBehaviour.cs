using UnityEngine;
using System.Collections;

public class CubeLauncherBehaviour : MonoBehaviour 
{
	public GameObject showelPrefab;
	public Transform showelEnd;
	public float force = 500f;
	public float delay = 2f;
	private GameObject showel;
	
	// Use this for initialization
	void Start () 
	{
		StartCoroutine(shotShowel());
	}
	IEnumerator shotShowel()
	{
		while(true)
		{
			showel = Instantiate(showelPrefab,transform.position, Quaternion.identity) as GameObject;
			showel.transform.Rotate(0f,90f,0f);
			showel.rigidbody.AddForce(0,0,force);
			showel.rigidbody.AddTorque(1000f,0f,0f);
			yield return new WaitForSeconds (delay);
		}
	}
}
