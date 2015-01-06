using UnityEngine;
using System.Collections;

public class CoinBehaviour : MonoBehaviour {

	public float rotationSpeed = 1.5f;
	public GameObject fence;

	private FenceBehaviour fenceBehaviour;
	private ParticleSystem particles1;
	private ParticleSystem particles2;
	private GameObject coinModel;

	void Start(){
		fenceBehaviour = fence.GetComponent<FenceBehaviour>();
		particles1 = transform.GetChild(0).GetComponent<ParticleSystem>();
		particles2 = transform.GetChild(1).GetComponent<ParticleSystem>();
		coinModel = transform.GetChild(2).gameObject;
	}
	// Update is called once per frame
	void Update () {
		transform.Rotate(0f, rotationSpeed, 0f);
	}
	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			//Hacemos desaparecer la moneda
			gameObject.collider.enabled = false;
			coinModel.SetActive(false);

			particles1.Play();
			particles2.Play();

			audio.Play();

			fenceBehaviour.tryOpen();
		}
	}
}
