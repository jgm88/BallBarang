#pragma strict

var posStart: Vector3;
var posEnd: Vector3;
var duration: float = 1.0;

private var lerp: float = 0.0;
private var lastLerp: float = -0.01;
private var action = waitingUp;

function Start () 
{
	transform.localPosition = posStart;
}

function Update () 
{
	lerp = Mathf.PingPong(Time.time, duration) / duration;
	action();
	lastLerp = lerp;
}

function waitingUp()
{
	if(lastLerp > lerp)
	{
		action = waitingDown;
	}
}

function waitingDown()
{
	if(lastLerp < lerp)
	{
		action = movingUp;
	}
}

function movingUp()
{
	if(lastLerp > lerp)
	{
		action = waitingDown2;
		return;
	}
	
	transform.localPosition = Vector3.Lerp(posStart, posEnd, lerp);
}

function waitingDown2()
{
	if(lastLerp < lerp)
	{
		action = waitingUp2;
	}
}

function waitingUp2()
{
	if(lastLerp > lerp)
	{
		action = movingDown;
	}
}

function movingDown()
{
	if(lastLerp < lerp)
	{
		action = waitingUp;
		return;
	}
	
	transform.localPosition = Vector3.Lerp(posStart,posEnd,lerp);
}