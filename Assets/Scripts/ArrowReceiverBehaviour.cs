using UnityEngine;
using System.Collections;

public class ArrowReceiverBehaviour : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if(other.tag == "Arrow")
			GameObject.Destroy(other.gameObject);
	}
}
