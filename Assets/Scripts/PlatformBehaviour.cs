using UnityEngine;
using System.Collections;

public class PlatformBehaviour : MonoBehaviour {


	public GameObject target;
	public float platformSpeed;
	public GameObject back;
	private Vector3 tempPos;

	void Start()
	{
		tempPos = target.transform.position;

	}
	
	// Update is called once per frame
	void Update () {

		if(Vector3.Distance(transform.position,target.transform.position)<2f)
			tempPos=back.transform.position;
		else if(Vector3.Distance(transform.position,back.transform.position)<2f)
			tempPos=target.transform.position;

		transform.position = Vector3.Lerp(transform.position,tempPos,Time.deltaTime * platformSpeed);

	}

	void OnTriggerEnter(Collider colision)
	{
		if(colision.transform.tag == "Player")
			colision.transform.SetParent (transform);
	}

	void OnTriggerExit(Collider colision)
	{
		if (colision.transform.tag ==	 "Player")
			colision.transform.SetParent (null);
	}

}
