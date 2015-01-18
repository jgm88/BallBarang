using UnityEngine;
using System.Collections;

public class FriendBallBeachBehaviour : MonoBehaviour 
{
	public string mesage = "";
	private bool talk = false;
	// Use this for initialization
	void Start () 
	{
		talk = false;
	}
	
	// Update is called once per frame
	void Update () {}

	void OnTriggerEnter(Collider other)
	{
		talk = true;
	}
	void OnTriggerExit(Collider other)
	{
		talk = false;
	}
	string transformMesage(string str)
	{
		string aux = "";
		for(int i=0; i<str.Length; ++i)
		{
			if(str[i].Equals('.'))
			{
				aux += '\n';
			}
			else
			{
				aux += str[i];
			}
		}
		return aux;
	}
	void OnGUI()
	{	
		if(talk)
		{
			GUI.Box(new Rect(Screen.width/2-110,Screen.height-100,220,90), transformMesage(mesage));
		}
	}
}
