using UnityEngine;
using System.Collections;

public class CoinBehaviour : MonoBehaviour {

	public float rotationSpeed = 1.5f;
	public GameObject fence;
	private FenceBehaviour fenceBehaviour;

	void Start(){
		fenceBehaviour = fence.GetComponent<FenceBehaviour>();
	}
	// Update is called once per frame
	void Update () {
		transform.Rotate(0f, rotationSpeed, 0f);
	}
	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			fenceBehaviour.tryOpen();
			GameObject.Destroy(gameObject);
		}
	}
}
