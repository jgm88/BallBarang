using UnityEngine;
using System.Collections;

public class ShowelBehaviour : MonoBehaviour 
{
	private Vector3 direction;
	public float force = 0f;
	public float destroyPosition = 0.0f;
	public float limit = 0.0f;

	void Start () {}
	void Update () 
	{
		//lugar de destruccion
		if(transform.position.z > destroyPosition)
		{
			Destroy(this.gameObject);
		}
		//Inclinar hacia el agua
		if(transform.position.z > limit)
		{
			this.rigidbody.AddForce(0,-2,0);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			if (other.rigidbody)
			{
				direction = other.transform.position - transform.position;
				direction.y = 0;
				other.rigidbody.AddForce(direction.normalized * force);
				Destroy(this.gameObject);
			}
		}

	}
	/*
	void OnGUI()
	{	
		string text = "\nTEST:\n" 
					+ "x: " + this.transform.position.x + "\n"
					+ "y: " + this.transform.position.y + "\n"
					+ "z: " + this.transform.position.z;
		GUI.Box(new Rect(10,10,100,90), text);
	}
	*/
}
