using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class EventSystemBehaviour : MonoBehaviour {

	private Button button1;
	private Button button2;
	private bool isHide;

	// Use this for initialization
	void Start () {
		button1 = GameObject.Find("InfoButton1").GetComponent<Button>();
		button2 = GameObject.Find("InfoButton2").GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Return)){
			if(button1.IsActive()){
				button1.Select();
			}
			if(button2.IsActive()){
				button2.Select();
			}
		}
	}
}
