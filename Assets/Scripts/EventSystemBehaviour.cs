using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class EventSystemBehaviour : MonoBehaviour {

	private Button button1;
	private PlayerBehaviour playerBehaviour;
	private GameObject gameOverPanel;
	private GameObject escPanel;
	private ChangeCursor changeCursor;

	// Use this for initialization
	void Start () {

		playerBehaviour = GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>();
		button1 = GameObject.Find("InfoButton1").GetComponent<Button>();
		if(button1.IsActive())
			button1.Select();

		gameOverPanel = GameObject.Find("GameOverPanel");
		gameOverPanel.SetActive(false);

		escPanel = GameObject.Find("EscPanel");
		escPanel.SetActive(false);



		changeCursor = gameObject.GetComponent<ChangeCursor>();
		showCursor(false);
	}

	void Update () {



		if(Input.GetKeyDown(KeyCode.Return)){
			if(button1.IsActive()){
				button1.Select();
			}
		}
		if(Input.GetKeyDown(KeyCode.Escape)){
			escPanel.SetActive(true);
			showCursor(true);
		}

	}
	void LateUpdate(){
		if(playerBehaviour.life < 1){

			gameOverPanel.SetActive(true);
			showCursor(true);
		}
	}
	public void showCursor(bool show){
		Screen.showCursor = false;
		Screen.lockCursor = !show;
		changeCursor.enabled = show;
	}
}
