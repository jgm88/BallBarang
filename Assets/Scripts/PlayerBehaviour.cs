using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	public int life = 3;
	// Use this for initialization
	void Start () {
	
	}

	public void deductLife(int damage){
		life -= damage;
		if(life <= 0)
			die();
	}

	private void die(){
		//TODO
		//Comportamiento de muerte
	}
}
