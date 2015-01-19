using UnityEngine;
using System.Collections;

public class LaserCircleBehaviour : MonoBehaviour {

	private float secsToWait;
	private BoxCollider colider;
	public ParticleSystem[] particulas;

	// Use this for initialization
	void Start () {
	
		secsToWait = Random.Range(2,4);
		colider = GetComponent<BoxCollider>();
		particulas = GetComponentsInChildren<ParticleSystem> ();
		StartCoroutine(Parpadeo());

	}


	IEnumerator Parpadeo()
	{
		while (true)
		{
			Debug.Log(particulas.Length);
			foreach(ParticleSystem particula in particulas)
				particula.particleSystem.renderer.enabled = false;

			colider.enabled = false;
			yield return new WaitForSeconds(secsToWait);

			foreach(ParticleSystem particula in particulas)
				particula.renderer.enabled=true;

			colider.enabled = true;
			yield return new WaitForSeconds(secsToWait);
			
			
		}
		
	}
}
