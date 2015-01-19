using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BombBehaviour : MonoBehaviour {

	public float timeLife= 30f;
	public float timeToExplote;
	public bool getPower= false;
	public GameObject timeBar;


	private GameObject bomb;
	private GameObject gameOver;
	private GameObject gameWin;
	private RectTransform maskSize;
	private Rect internalRect;
	private float MaxWidth;
	private float maxAnchor;
	private Vector2 anchorPosition;



	void Awake()
	{
		gameOver = GameObject.Find ("GameOver");
		gameOver.SetActive (false);
	}

	// Use this for initialization
	void Start () {

		timeToExplote = timeLife;
		StartCoroutine (chronoExplosion ());
		maskSize = timeBar.GetComponent<Mask> ().rectTransform;
		MaxWidth = maskSize.rect.width;
		maxAnchor = maskSize.anchoredPosition.x;
		anchorPosition = maskSize.anchoredPosition;
		internalRect = maskSize.rect;
	}
	public void setPower()
	{
		
		getPower = true;
	}
	
	public void addTime(float time)
	{
		float tempTime = timeToExplote + time;
		if (tempTime > timeLife) 
		{
			timeToExplote = timeLife;
		} else
			timeToExplote = tempTime;
	}

	void LateUpdate()
	{
		float currentWidth = timeToExplote * MaxWidth / timeLife;
		float currentAnchor = timeToExplote * maxAnchor / timeLife;
		internalRect.width = currentWidth;
		anchorPosition.x = currentAnchor;
		
		maskSize.sizeDelta= internalRect.size;
		maskSize.anchoredPosition = anchorPosition;
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
			this.transform.parent.GetComponent<PlayerMovement>().enabled= false;
			this.transform.parent.GetComponent<Rigidbody>().isKinematic= true;
			this.transform.GetComponentInChildren<MeshRenderer> ().enabled = false;
			MeshRenderer[] bombMeshs= this.transform.GetComponentsInChildren<MeshRenderer> ();
			bombMeshs [0].enabled = false;
			bombMeshs [1].enabled = false;
			Destroy (this.gameObject, 2.5f);
		
		}
	}

	void OnDestroy()
	{
		
	}
}
