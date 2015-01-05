using UnityEngine;
using System.Collections;

public class WickBehaviour : MonoBehaviour {

	public float upTime= 25f;

	public void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player")
		{
			col.transform.GetComponentInChildren<BombBehaviour>().addTime(upTime);
			Destroy(this.gameObject);
		}
	}

	void Update()
	{
		this.transform.Rotate (0f, 1.5f, 0f);
	}
}
