using UnityEngine;
using System.Collections;

public class WickBehaviour : MonoBehaviour {

	public float upTime= 25f;

	public void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player")
		{
			audio.Play();
			col.transform.GetComponentInChildren<BombBehaviour>().addTime(upTime);
			this.gameObject.GetComponentInChildren<MeshRenderer>().enabled=false;
			this.gameObject.GetComponentInChildren<ParticleSystem>().Stop();
			this.gameObject.GetComponent<BoxCollider>().enabled= false;
			Destroy(this.gameObject,2f);
		}
	}

	void Update()
	{
		this.transform.Rotate (0f, 1.5f, 0f);
	}
}
