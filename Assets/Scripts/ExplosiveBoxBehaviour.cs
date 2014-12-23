using UnityEngine;
using System.Collections;

public class ExplosiveBoxBehaviour : MonoBehaviour {


	private Component [] childRigids;

	public GameObject [] sparksAnims;
	public GameObject [] bombs;
	public GameObject explosionEffect;

	// Use this for initialization
	void Start () {
		childRigids = gameObject.GetComponentsInChildren (rigidbody.GetType());
	}

	public void OnTriggerEnter(Collider col)
	{
		if (col.tag.Equals ("Actuator")) {
			StartCoroutine("explosion",2f);
			Destroy (col.gameObject, 2f);
		}
	}


	IEnumerator explosion(float time)
	{
		StartCoroutine ("turnSparks");
		yield return new WaitForSeconds(2f);
		explosionEffect.particleSystem.Play ();
		foreach(Rigidbody rigid in childRigids)
		{
			rigid.constraints= RigidbodyConstraints.None;
		}
		foreach(Rigidbody rigid in childRigids)
		{
			rigid.AddExplosionForce(700f,this.transform.position,10f,6.0f);
		}
		Destroy (this.gameObject, 3.5f);

	}

	IEnumerator turnSparks()
	{
		sparksAnims [0].particleSystem.Play ();
		sparksAnims [1].particleSystem.Play ();
		sparksAnims [2].particleSystem.Play ();

		yield return new WaitForSeconds(2f);

		sparksAnims [0].particleSystem.Stop ();
		sparksAnims [1].particleSystem.Stop ();
		sparksAnims [2].particleSystem.Stop ();


		Destroy (bombs [0]);
		Destroy (bombs [1]);
		Destroy (bombs [2]);

	}



}
