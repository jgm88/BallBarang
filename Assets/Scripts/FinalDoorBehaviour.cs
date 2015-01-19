using UnityEngine;
using System.Collections;

public enum DoorColors{ROJO, AZUL, VERDE, AMARILLO};

public class FinalDoorBehaviour : MonoBehaviour {

	public GameObject rayoAzul;
	public GameObject rayoRojo;
	public GameObject rayoVerde;
	public GameObject rayoAmarillo;


	// Use this for initialization
	void Start () {
	
	}
	
	void QuitColor(DoorColors color)
	{
		if (color == DoorColors.AMARILLO)
		{
			rayoAmarillo.GetComponent<LineRenderer>().enabled=false;
			rayoAmarillo.GetComponent<Lightning>().enabled = false;
		}else if (color == DoorColors.VERDE)
		{
			rayoVerde.GetComponent<LineRenderer>().enabled=false;
			rayoVerde.GetComponent<Lightning>().enabled = false;
		}else if (color == DoorColors.AZUL)
		{
			rayoAzul.GetComponent<LineRenderer>().enabled=false;
			rayoAzul.GetComponent<Lightning>().enabled = false;
		}else if (color == DoorColors.ROJO)
		{
			rayoRojo.GetComponent<LineRenderer>().enabled=false;
			rayoRojo.GetComponent<Lightning>().enabled = false;
		}

	}
}
