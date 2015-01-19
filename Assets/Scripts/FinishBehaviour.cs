using UnityEngine;
using System.Collections;

public class FinishBehaviour : MonoBehaviour {

	private GameObject winpanel;
	// Use this for initialization
	void Awake () {
	
		winpanel = GameObject.Find ("WinPanel");
		winpanel.SetActive (false);
	}
	


	void OnTriggerEnter(Collider colider)
	{

		if (colider.tag == "Player") {
			winpanel.SetActive(true);
			GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().isKinematic=true;
			GameObject.Find ("EventSystem").GetComponent<GlobalEventSystemBehaviour> ().showCursor (true);
		}

	}
}
