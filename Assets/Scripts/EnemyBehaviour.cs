using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	
	public int damage = 1;
	private PlayerBehaviour playerBehaviour;

	// Use this for initialization
	void Start () {
		playerBehaviour = GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>();
	}
	
	void OnTriggerEnter(Collider other){
		if(other.tag == "Player")
			playerBehaviour.deductLife(damage);
	}
}
