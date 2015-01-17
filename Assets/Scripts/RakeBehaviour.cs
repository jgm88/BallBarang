using UnityEngine;
using System.Collections;

public class RakeBehaviour : MonoBehaviour 
{
	public bool isLeft = false;
	public float rotationVelocity = 0f;
	public float force = 0f	;
	private Vector3 direction;
	private bool maxTop = true;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () 
	{
		if(maxTop)
		{
			gameObject.transform.Rotate(0f, (-1)*rotationVelocity, 0f);
		}
		else
		{
			gameObject.transform.Rotate(0f,rotationVelocity, 0f);
		}

		if(isLeft)
		{
			if(gameObject.transform.rotation.y < 0)
			{
				maxTop = false;
			}
			
			if(gameObject.transform.rotation.y > 0.5)
			{
				maxTop = true;
			}
		}
		else
		{
			if(gameObject.transform.rotation.x < 0)
			{
				maxTop = false;
			}
			
			if(gameObject.transform.rotation.x > 0.5)
			{
				maxTop = true;
			}
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
				//maxTop = false;
			}
		}

		if(other.tag == "wood")
		{
			maxTop = false;
		}
	}
}
