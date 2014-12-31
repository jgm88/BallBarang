using UnityEngine;
using System.Collections;

public class LeverBehaviour : MonoBehaviour {

	public GameObject lever;
	public GameObject explosiveWagon;
	private bool moved= false;
	
	ExplosiveWagonBehaviour activeWagon;
	
	public void Start()
	{
		activeWagon = explosiveWagon.GetComponent<ExplosiveWagonBehaviour>();
	}
	
	public void OnTriggerEnter(Collider col)
	{
		
		if (col.tag == "Player" && !moved) {
			lever.animation.Play();
			moved=true;
			activeWagon.turnOn();
		}
		
	}
}
