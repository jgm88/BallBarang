#pragma strict

var wood = false;
var towel = false;
var rope = false;

function OnTriggerEnter( other : Collider ) {
    if (other.tag == "wood") 
    {
    	wood = true;
        Destroy(other.gameObject);
    }
    if(other.tag == "towel")
    {
    	towel = true;
    	Destroy(other.gameObject);
    }
    if(other.tag == "rope")
    {
    	rope = true;
    	Destroy(other.gameObject);
    }
}

function OnGUI() 
{
	GUI.contentColor = Color.red;

	if(wood)
		GUILayout.Label("  WOOD OBTAINED");
		
	if(towel)
		GUILayout.Label("  TOWEL OBTAINED");
		
	if(rope)
		GUILayout.Label("  ROPE OBTAINED");
}