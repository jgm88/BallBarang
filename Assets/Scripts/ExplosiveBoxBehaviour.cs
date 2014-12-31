using UnityEngine;
using System.Collections;

public class ExplosiveBoxBehaviour : MonoBehaviour {


	private Component [] childRigids;
	public GameObject [] sparksAnims;
	public GameObject [] bombs;
	public GameObject explosionEffect;
	private Collider[] physicsObjects;

	// Use this for initialization
	void Start () {
		childRigids = gameObject.GetComponentsInChildren (rigidbody.GetType());
	}

	public void OnTriggerEnter(Collider col)
	{
		if (col.tag.Equals ("Actuator")) {
			StartCoroutine("explosionCor",2f);
			Destroy (col.gameObject, 2f);
		}
	}


	IEnumerator explosionCor(float time)
	{
		Vector3 myPos= this.gameObject.transform.position;
		StartCoroutine (turnSparksCor());
		yield return new WaitForSeconds(2f);
		explosionEffect.particleSystem.Play ();
		foreach(Rigidbody rigid in childRigids)
		{
			rigid.isKinematic = false;
		}
		foreach(Rigidbody rigid in childRigids)
		{
			rigid.AddExplosionForce(700f,this.transform.position,30f,6f);
		}
		physicsObjects = Physics.OverlapSphere (myPos, 30f);
		foreach (Collider col in physicsObjects) {
			if(col && col.rigidbody && col.tag.Equals("ExplosionAffect")){
				col.rigidbody.isKinematic = false;
				col.rigidbody.AddExplosionForce(800f,myPos,30f,0.001f);
			}
		}
		Destroy (this.gameObject, 3.5f);

	}

	IEnumerator turnSparksCor()
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
