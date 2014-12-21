using UnityEngine;
using System.Collections;

public class ExplosionBehaviour : MonoBehaviour {


	public GameObject explosionAnim ;
	private ParticleSystem explosionParticle;
	private Vector3 myPos;
	private Collider[] physicsObjects;
	// Use this for initialization
	void Start () {
		explosionParticle=  (ParticleSystem)explosionAnim.GetComponent("ParticleSystem");
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(1)) {
			doExplosion();
		}
	}

	void doExplosion ()
	{
		myPos = this.transform.position;
		physicsObjects = Physics.OverlapSphere (myPos, 3.35f);
		foreach (Collider col in physicsObjects) {
			if(col && col.rigidbody && !col.tag.Equals("Player")){
				col.rigidbody.AddExplosionForce(750f,myPos,10f,6.0f);
			}
		}
		explosionParticle.Play ();
	}
}
