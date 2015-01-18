using UnityEngine;
using System.Collections;

public class ItemBeachBehaviour : MonoBehaviour 
{
	private string item = "";
	void Start () {}
	void Update () {}

	void OnTriggerEnter(Collider other)
	{
		item = this.gameObject.name;
		if(other.tag == "Player")
		{
			audio.Play();
			Destroy(this.gameObject, 0.5f);
		}
	}

	void OnGUI()
	{	
		if(item != "")
		{
			GUI.Box(new Rect(Screen.width/2-100,Screen.height-100,200,55), "\n¡" + item + " obtained!");	
		}
	}
}