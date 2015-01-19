using UnityEngine;
using System.Collections;

public class ItemsBallBeach : MonoBehaviour {

	//Objetos para montar la balsa
	public bool wood = false;
	public bool towel = false;
	public bool rope = false;
	private bool create = true;

	//balsa
	public GameObject shipPrefab;
	private GameObject ship;
	private Vector3 initShipPos = new Vector3(30f,3.1f,48.5f);

	//para cuando mueres
	private Vector3 init = new Vector3(-9.5f,3.5f,11.5f);
	
	void Start () {}
	void Update () 
	{
		if(this.gameObject.transform.position.y < -5)
		{
			dead ();
		}

		if(wood && towel && rope)
		{
			wood = towel = rope = false;
			ship = Instantiate(shipPrefab, initShipPos, Quaternion.identity) as GameObject;
			ship.transform.Rotate(0f,110f,90f);
			create = false;
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
		string text = "";
		if(create)
		{
			text = "Inventario: \n\n";
		}
		else
		{
			text = "¡Balsa Creada!";
		}
		if(wood){ text += "Madera\n"; }
		if(towel){ text += "Tela\n"; }
		if(rope){ text += "Cuerda\n"; }
		//text = test ();
		if(wood && towel && rope)
		{
			text = "¡Balsa Creada!";
		}
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

