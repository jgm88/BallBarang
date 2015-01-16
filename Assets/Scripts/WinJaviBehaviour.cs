using UnityEngine;
using System.Collections;

public class WinJaviBehaviour : MonoBehaviour {

	private GameObject winPanel;
	private EventSystemBehaviour eventSystemBehaviour;
	// Use this for initialization
	void Start () {
		winPanel = GameObject.Find("WinPanel");
		winPanel.SetActive(false);

		eventSystemBehaviour = GameObject.Find("EventSystem").GetComponent<EventSystemBehaviour>();
	}
	
	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			winPanel.SetActive(true);
			eventSystemBehaviour.showCursor(true);
		}
	}
}
