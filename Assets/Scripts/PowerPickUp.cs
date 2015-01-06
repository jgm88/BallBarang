using UnityEngine;
using System.Collections;

public class PowerPickUp : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		this.transform.Rotate (0f, 1f, 0f);
	}


	public void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player")
		{
			col.transform.GetComponentInChildren<BombBehaviour>().setPower();
			audio.Play();
			MeshRenderer[] bombMeshs= this.transform.GetComponentsInChildren<MeshRenderer> ();
			bombMeshs [0].enabled = false;
			bombMeshs [1].enabled = false;
			this.gameObject.GetComponentInChildren<ParticleSystem>().Stop();
			this.GetComponent<SphereCollider>().enabled= false;
			Destroy(this.gameObject,2f);
		}

	}
}
