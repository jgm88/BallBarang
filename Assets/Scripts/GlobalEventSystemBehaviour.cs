﻿using UnityEngine;
using System.Collections;

public class GlobalEventSystemBehaviour : MonoBehaviour {


	private GameObject escPanel;
	private GameObject winPanel;
	private ChangeCursor changeCursor;
	// Use this for initialization
	void Start () {

		escPanel = GameObject.Find("EscPanel");
		escPanel.SetActive(false);

		winPanel = GameObject.Find("WinPanel");
		winPanel.SetActive(false);

		changeCursor = gameObject.GetComponent<ChangeCursor>();
		showCursor(false);
	}
	
	void Update () {
		
	
		if(Input.GetKeyDown(KeyCode.Escape)){
			escPanel.SetActive(true);
			showCursor(true);
		}
		
	}

	public void showCursor(bool show){
		Screen.showCursor = false;
		Screen.lockCursor = !show;
		changeCursor.enabled = show;
	}
}
