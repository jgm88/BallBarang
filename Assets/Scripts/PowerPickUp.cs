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
			Destroy(this.gameObject);
		}

	}
}
