#pragma strict

var tilt : Vector3 = Vector3.zero;
var speed : float;

private var previousPosition : Vector3;

@script RequireComponent(Rigidbody)
function Start()
{
	previousPosition = transform.position;
}


function Update () {
	tilt.x = -Input.acceleration.y;
	tilt.z = Input.acceleration.x;
	
	GetComponent.<Rigidbody>().AddForce(tilt * speed * Time.deltaTime);
}

function LateUpdate()
{
	var movement : Vector3 = transform.position - previousPosition;
	
	movement = Vector3(movement.z,0,  -movement.x);
	
	previousPosition = transform.position;	
	
}