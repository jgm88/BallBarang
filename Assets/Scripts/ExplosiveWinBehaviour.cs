using UnityEngine;
using System.Collections;

public class ExplosiveWinBehaviour : MonoBehaviour {


	GameObject gameWin;

	void Awake()
	{
		gameWin = GameObject.Find ("GameWin");
		gameWin.SetActive (false);

		GameObject.Find ("GameOver").SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		this.transform.Rotate (0f, 1f, 0f);
	}


	void OnTriggerEnter(Collider col)
	{
		if (col.CompareTag ("Player")) {
				
			col.GetComponent<PlayerMovement> ().acceleration = 0;
			col.GetComponent<PlayerMovement> ().rigidbody.isKinematic = true;
			GameObject.Find ("EventSystem").GetComponent<GlobalEventSystemBehaviour> ().showCursor (true);
			gameWin.SetActive (true);
		}
		 	
	}

}
