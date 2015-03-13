//from http://www.chrisgaunt.com/2014/07/18/smooth-follow-camera-2D-v1.0.0/

using UnityEngine;
using System.Collections;

namespace OTM {
public class FollowingCamera2 : MonoBehaviour {

	public Transform target;
	private Vector3 velocity = Vector3.zero;
	public float smoothTime = 0.15f;
	public bool verticalMaxEnabled = false;
	public float verticalMax = 0f;
	public bool verticalMinEnabled = false;
	public float verticalMin = 0f;
	public bool horizontalMaxEnabled = false;
	public float horizontalMax = 0f;
	public bool horizontalMinEnabled = false;
	public float horizontalMin = 0f;


	public string restriction;

	public void setRestriction(string a)
	{
		restriction = a;
	}


	void Update () {

		calcRestrictions ();

		//if (target) {


			Vector3 targetPosition = target.position;


			if (verticalMinEnabled && verticalMaxEnabled) {
				targetPosition.y = Mathf.Clamp(target.position.y, verticalMin, verticalMax);
			} else if (verticalMinEnabled) {
				targetPosition.y = Mathf.Clamp(target.position.y, verticalMin, target.position.y);
			} else if (verticalMaxEnabled) {
				targetPosition.y = Mathf.Clamp(target.position.y, target.position.y, verticalMax);
			}

			if (horizontalMinEnabled && horizontalMaxEnabled) {
				targetPosition.x = Mathf.Clamp(target.position.x, horizontalMin, horizontalMax);
			} else if (horizontalMinEnabled) {
				targetPosition.x = Mathf.Clamp(target.position.x, horizontalMin, target.position.x);
			} else if (horizontalMaxEnabled) {
				targetPosition.x = Mathf.Clamp(target.position.x, target.position.x, horizontalMax);
			}

			targetPosition.z = -100.00f;
			transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
		//}
	}

	void calcRestrictions()
	{
		switch (restriction) {
		
		case ("vert_trigger"):
			verticalMaxEnabled = true;
			verticalMinEnabled = true;
			horizontalMaxEnabled = false;
			horizontalMinEnabled = false;		
			//Debug.LogWarning ("vert_trigger ACTIVE");
			break;
		

		case ("hor_trigger"):
			horizontalMaxEnabled = true;
			horizontalMinEnabled = true;
			verticalMaxEnabled = false;
			verticalMinEnabled = false;
			//Debug.LogWarning ("HOR_trigger ACTIVE");
			break;

		default:
			horizontalMaxEnabled = false;
			horizontalMinEnabled = false;
			verticalMaxEnabled = false;
			verticalMinEnabled = false;
			//Debug.LogWarning ("triggers DISABLED");
			break;
	}

	}

}
}