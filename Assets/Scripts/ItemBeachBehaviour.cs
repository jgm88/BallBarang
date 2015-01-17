using UnityEngine;
using System.Collections;

public class ItemBeachBehaviour : MonoBehaviour 
{
	void Start () {}
	void Update () {}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			audio.Play();
			Destroy(this.gameObject, 0.4f);
		}
	}
}
