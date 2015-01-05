using UnityEngine;
using System.Collections;

public class BombBehaviour : MonoBehaviour {

	private GameObject bomb;
	public float timeLife= 30f;
	public float timeToExplote;
	public bool getPower= false;


	public void setPower()
	{
		getPower = true;
	}

	public void addTime(float time)
	{
		float tempTime = timeToExplote + time;

		Debug.Log ("Increase Time");

		if (tempTime > timeLife) 
		{
			timeToExplote = timeLife;
		} else
			timeToExplote = tempTime;
	}
	// Use this for initialization
	void Start () {
		timeToExplote = timeLife;
		StartCoroutine (chronoExplosion ());
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(1) && getPower) {
			doExplosion();
		}
	}

	void doExplosion ()
	{

		bomb= Instantiate (this.gameObject,this.transform.position, this.transform.rotation) as GameObject;
		bomb.AddComponent<SphereCollider> ();
		bomb.GetComponent<BombBehaviour> ().enabled = false;
		bomb.AddComponent ("TimeExplosion");
	}

	IEnumerator chronoExplosion()
	{
		while (timeToExplote>0 && !getPower ) 
		{
			timeToExplote -= 1;
			yield return new WaitForSeconds(1f);
		}
		if (!getPower) {
				
			ParticleSystem explosionParticle=  this.GetComponentInChildren<ParticleSystem> ();
			Vector3 myPos = this.transform.position;
			Collider[] physicsObjects = Physics.OverlapSphere (myPos, 3.35f);
			foreach (Collider col in physicsObjects) {
				if(col && col.rigidbody && !col.tag.Equals("Player")){
					col.rigidbody.AddExplosionForce(750f,myPos,10f,6.0f);
				}
			}
			explosionParticle.Play ();
			this.transform.GetComponentInChildren<MeshRenderer> ().enabled = false;
			MeshRenderer[] bombMeshs= this.transform.GetComponentsInChildren<MeshRenderer> ();
			bombMeshs [0].enabled = false;
			bombMeshs [1].enabled = false;
			
			Destroy (this.gameObject, 2.5f);
		
		}
	}
}
