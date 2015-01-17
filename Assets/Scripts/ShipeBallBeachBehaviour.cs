using UnityEngine;
using System.Collections;

public class ShipeBallBeachBehaviour : MonoBehaviour 
{
	public Vector3 posStart;
	public Vector3 posEnd;
	public float duration = 1.0f;

	private float lerp = 0.0f;
	private float lastLerp = -0.01f;
	//private var action = waitingUp;
	void Start () 
	{
		transform.localPosition = posStart;
	}
	
	// Update is called once per frame
	void Update () 
	{
		lerp = Mathf.PingPong(Time.time, duration) / duration;
		waitingUp();
		//lastLerp = lerp;
	}

	void waitingUp()
	{
		if(lastLerp > lerp)
		{
			waitingDown();
		}
	}
	
	void waitingDown()
	{
		if(lastLerp < lerp)
		{
			movingUp();
		}
	}
	
	void movingUp()
	{
		if(lastLerp > lerp)
		{
			waitingDown2();
			//return;
		}
		
		transform.localPosition = Vector3.Lerp(posStart, posEnd, lerp);
	}
	
	void waitingDown2()
	{
		if(lastLerp < lerp)
		{
			waitingUp2();
		}
	}
	
	void waitingUp2()
	{
		if(lastLerp > lerp)
		{
			movingDown();
		}
	}
	
	void movingDown()
	{
		if(lastLerp < lerp)
		{
			waitingUp();
			//return;
		}
		
		transform.localPosition = Vector3.Lerp(posStart,posEnd,lerp);
	}
}
