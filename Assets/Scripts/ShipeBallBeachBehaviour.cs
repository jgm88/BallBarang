using UnityEngine;
using System.Collections;

public class ShipeBallBeachBehaviour : MonoBehaviour 
{
	public Vector3 posStart;
	public Vector3 posEnd;
	public float duration = 1.0f;

	private float lerp = 0.0f;
	private float lastLerp = -0.01f;
	private int numAction = 0;

	void Start () 
	{
		transform.localPosition = posStart;
	}
	
	// Update is called once per frame
	void Update () 
	{
		lerp = Mathf.PingPong(Time.time, duration) / duration;
		action (numAction);
		lastLerp = lerp;
	}
	void OnTriggerEnter(Collider other)
	{
		other.transform.SetParent(this.transform);
	}
	void OnTriggerExit(Collider Other)
	{
		Other.transform.SetParent(null);
	}
	void waitingUp()
	{
		if(lastLerp > lerp)
		{
			numAction = 1;
		}
	}
	
	void waitingDown()
	{
		if(lastLerp < lerp)
		{
			numAction = 2;
		}
	}
	
	void movingUp()
	{
		if(lastLerp > lerp)
		{
			numAction = 3;
			return;
		}
		
		transform.localPosition = Vector3.Lerp(posStart, posEnd, lerp);
	}
	
	void waitingDown2()
	{
		if(lastLerp < lerp)
		{
			numAction = 4;
		}
	}
	
	void waitingUp2()
	{
		if(lastLerp > lerp)
		{
			numAction = 5;
		}
	}
	
	void movingDown()
	{
		if(lastLerp < lerp)
		{
			numAction = 0;
			return;
		}
		
		transform.localPosition = Vector3.Lerp(posStart,posEnd,lerp);
	}
	void action (int status)
	{
		/*
		waitingUp()		-> 0
		waitingDown()	-> 1
		movingUp()		-> 2
		waitingDown2()	-> 3
		waitingUp2()	-> 4
		movingDown()	-> 5
		 */
		switch(status)
		{
			case 0:	waitingUp();
				break;
			case 1:	waitingDown();
				break;
			case 2:	movingUp();
				break;
			case 3:	waitingDown2();
				break;
			case 4:	waitingUp2();
				break;
			case 5:	movingDown();
				break;
		}
	}
}
