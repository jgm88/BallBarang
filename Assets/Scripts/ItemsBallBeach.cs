using UnityEngine;
using System.Collections;

public class ItemsBallBeach : MonoBehaviour {
	public bool wood = false;
	public bool towel = false;
	public bool rope = false;


	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "wood") 
		{
			wood = true;
			//Destroy(other.gameObject);
		}
		if(other.tag == "towel")
		{
			towel = true;
			//Destroy(other.gameObject);
		}
		if(other.tag == "rope")
		{
			rope = true;
			//Destroy(other.gameObject);
		}
	}
	void OnGUI()
	{	
		string text = "Inventory: \n\n";

		if(wood){ text += "Wood\n"; }
		if(towel){ text += "Towel\n"; }
		if(rope){ text += "Rope\n"; }

		GUI.Box(new Rect(10,10,100,90), text);
	}

	void Start () {}
	void Update () {}
}

