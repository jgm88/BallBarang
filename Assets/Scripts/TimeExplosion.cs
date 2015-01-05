using UnityEngine;
using System.Collections;

public class TimeExplosion : MonoBehaviour {
	 	
	// Use this for initialization
	private Vector3 myPos;
	public ParticleSystem explosionParticle;
	private Collider[] physicsObjects;
	private MeshRenderer[] bombMeshs;
	void Start () {
		explosionParticle=  this.GetComponentInChildren<ParticleSystem> ();
		StartCoroutine (timerBomb ());
	}
	
	IEnumerator timerBomb()
	{

		yield return new WaitForSeconds(2f);
		myPos = this.transform.position;
		physicsObjects = Physics.OverlapSphere (myPos, 3.35f);
		foreach (Collider col in physicsObjects) {
			if(col && col.rigidbody && col.tag.Equals("ExplosionAffect")){
				col.rigidbody.isKinematic=false;
				col.rigidbody.AddExplosionForce(750f,myPos,10f,6.0f);
			}
		}
		explosionParticle.Play ();
		this.transform.GetComponentInChildren<MeshRenderer> ().enabled = false;
		bombMeshs= this.transform.GetComponentsInChildren<MeshRenderer> ();
		bombMeshs [0].enabled = false;
		bombMeshs [1].enabled = false;

		Destroy (this.gameObject, 2.5f);
	}
}
