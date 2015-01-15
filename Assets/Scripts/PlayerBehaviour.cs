using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	public int life = 3;
	private Transform[] vHearts;
	private MeshRenderer mesh;

	// Use this for initialization
	void Start () {
		vHearts = GameObject.Find("Hearts").GetComponentsInChildren<Transform>();

	}

	public void deductLife(int damage){
		life -= damage;
		vHearts[life].gameObject.SetActive(false);
		audio.Play();

		if(life <= 0)
			die();
	}

	private void die(){
		gameObject.GetComponent<PlayerMovement>().enabled = false;
		mesh = gameObject.GetComponentInChildren<MeshRenderer>();
		mesh.enabled = false;
	}
}
