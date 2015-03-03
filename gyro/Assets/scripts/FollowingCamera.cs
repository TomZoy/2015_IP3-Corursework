// Author: Zoltan Tompa 2015

/* script uses SmoothFollow2D.js (built in) as startingpoint
 * 
 * #pragma strict

var target : Transform;
var smoothTime = 0.3;
private var thisTransform : Transform;
private var velocity : Vector2;

function Start()
{
	thisTransform = transform;
}

function Update() 
{
	thisTransform.position.x = Mathf.SmoothDamp( thisTransform.position.x, 
		target.position.x, velocity.x, smoothTime);
	thisTransform.position.y = Mathf.SmoothDamp( thisTransform.position.y, 
		target.position.y, velocity.y, smoothTime);
}

*/

using UnityEngine;
using System.Collections;

public class FollowingCamera : MonoBehaviour {

	public GameObject cameraTarget; // object to look at or follow
	public GameObject player; // player object for moving

	public float smoothTime = 0.1f; // time for dampen
	public bool cameraFollowX = true; // camera follows on horizontal
	public bool cameraFollowY = true; // camera follows on vertical
	public bool cameraFollowHeight = true; // camera follow CameraTarget object height
	public float cameraHeight = 2.5f; // height of camera adjustable
	public Vector2 velocity; // speed of camera movement
	private Transform thisTransform; // camera Transform


	/*
	// Use this for initialization
	void Start () {
		thisTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
	
		thisTransform.position.x = Mathf.SmoothDamp( thisTransform.position.x,player.transform.position.x, velocity.x, smoothTime);
		thisTransform.position.y = Mathf.SmoothDamp( thisTransform.position.y,player.transform.position.y, velocity.y, smoothTime);


	}
	 */
}
