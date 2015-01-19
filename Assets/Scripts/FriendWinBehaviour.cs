using UnityEngine;
using System.Collections;

public class FriendWinBehaviour : MonoBehaviour 
{
	private GameObject winPanel;

	bool isInGround = false;
	// Use this for initialization
	void Start () 
	{
		winPanel = GameObject.Find("WinPanel");
	}
	// Update is called once per frame
	void Update () 
	{
		
		if(isInGround)
		{
			this.rigidbody.AddForce(0,300,0);
			isInGround = false;
		}
	}
	void OnTriggerEnter(Collider other)
	{
		isInGround = true;

		if(other.tag == "Player")
		{
			winPanel.SetActive(false);
		}
	}
}
