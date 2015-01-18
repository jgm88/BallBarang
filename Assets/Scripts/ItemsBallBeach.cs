using UnityEngine;
using System.Collections;

public class ItemsBallBeach : MonoBehaviour {
	public bool wood = false;
	public bool towel = false;
	public bool rope = false;

	private Vector3 init = new Vector3(-9.5f,3.5f,11.5f);
	void Start () {}
	void Update () 
	{
		if(this.gameObject.transform.position.y < -5)
		{
			dead ();
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "wood") 
		{
			wood = true;
		}
		if(other.tag == "towel")
		{
			towel = true;
		}
		if(other.tag == "rope")
		{
			rope = true;
		}
	}
	void dead()
	{
		this.gameObject.transform.position = init;
	}
	void OnGUI()
	{	
		string text = "Inventory: \n\n";

		if(wood){ text += "Wood\n"; }
		if(towel){ text += "Towel\n"; }
		if(rope){ text += "Rope\n"; }
		//text = test ();
		GUI.Box(new Rect(10,10,100,90), text);
	}
	/*
	string test()
	{
		string aux="Test:\n";
		aux += "X: " + this.gameObject.transform.position.x +"\n";
		aux += "Y: " + this.gameObject.transform.position.y +"\n";
		aux += "Z: " + this.gameObject.transform.position.z +"\n";
		return aux;
	}
	*/
}

