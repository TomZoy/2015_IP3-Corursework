#pragma strict



private var previousPosition : Vector3;

public var Sensitivity : float;


function Start()
{
	previousPosition = transform.position;
	Sensitivity = 20.0f;
}


function Update () {



transform.Translate(Input.acceleration.x * Time.deltaTime * Sensitivity ,Input.acceleration.y * Time.deltaTime * Sensitivity,0);

if (Input.touchCount > 0 && 
		  Input.GetTouch(0).phase == TouchPhase.Moved) {
		
Sensitivity = Sensitivity + 5.0f;

		}


}

