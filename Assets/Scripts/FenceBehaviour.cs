using UnityEngine;
using System.Collections;

public class FenceBehaviour : MonoBehaviour {
	
	public int coins;

	public void tryOpen(){
		coins--;
		if(coins == 0)
			GameObject.Destroy(gameObject);
	}
}
