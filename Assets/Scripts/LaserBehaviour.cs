using UnityEngine;
using System.Collections;

public class LaserBehaviour : MonoBehaviour {


	private ParticleSystem particulas;
	private BoxCollider colider;
	private float secsToWait;

	// Use this for initialization
	void Start () {
	
		particulas = GetComponentInChildren<ParticleSystem>();
		colider = GetComponent<BoxCollider>();
		secsToWait = Random.Range(2,4);
		StartCoroutine(Parpadeo());
	}
	


	IEnumerator Parpadeo()
	{
		while (true)
		{
			particulas.renderer.enabled = false;
			colider.enabled = false;
			yield return new WaitForSeconds(secsToWait);
			particulas.renderer.enabled = true;
			colider.enabled = true;
			yield return new WaitForSeconds(secsToWait);
		

		}

	}
}
