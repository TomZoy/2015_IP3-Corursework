// Author: Zoltan Tompa 2015

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

	public float Sensitivity;

	private GameObject  SSlider;
	public string prevCameraTrigger;
	private GameObject obj;
	public static int sleepTimeout; 
	public bool isDrunkOn;

	public int suspicion = 0;
	public Scrollbar SuspBar;
	
	// Use this for initialization
	void Start () {
		
		Sensitivity = 250.0f;
		//SSlider = GameObject.Find("Slider");

		prevCameraTrigger = "";
		obj = GameObject.Find ("Main Camera");

		// Disable screen dimming
		Screen.sleepTimeout = SleepTimeout.NeverSleep;


		this.rigidbody2D.drag = 10.0f;
		InvokeRepeating ("drunkMovement",2.00f,1.50f);

		//InvokeRepeating ("countTime",1.00f,1.00f);
	}
	
	// Update is called once per frame
	void Update () {

		// testing SuspBar
		SuspBar.size = suspicion/100f;

		//Sensitivity = SSlider.GetComponent<Slider>().normalizedValue*1000;
		
		//transform.Translate(Input.acceleration.x * Time.deltaTime * Sensitivity ,Input.acceleration.y * Time.deltaTime * Sensitivity,0);
		movePlayer (Input.acceleration.x, Input.acceleration.y);

		if (Input.GetKey ("w")) {
			movePlayer (0.0f, 1.0f);
		}
		else if (Input.GetKey ("s")) {
			movePlayer (0.0f, -1.0f);
		}
		else if (Input.GetKey ("a")) {
			movePlayer (-1.0f, 0.0f);
		}
		else if (Input.GetKey ("d")) {
			movePlayer (1.0f, 0.0f);
		}


		/*if (Input.touchCount > 0 && 
		    Input.GetTouch(0).phase == TouchPhase.Moved) {
			
			Sensitivity = Sensitivity + 5.0f;

			}*/


	}

	void movePlayer (float x, float y)
	{
		transform.Translate(x * Time.deltaTime * Sensitivity ,y * Time.deltaTime * Sensitivity,0);
	}

	void OnTriggerEnter2D(Collider2D other) {

		if (prevCameraTrigger != other.gameObject.name) {
			obj.GetComponent<FollowingCamera2> ().setRestriction (other.gameObject.name);
			obj.GetComponent<FollowingCamera2> ().verticalMin=-1069.00f;
			obj.GetComponent<FollowingCamera2> ().verticalMax=-1069.00f;
			prevCameraTrigger = other.gameObject.name;
			Debug.LogWarning ("trigger change ");
		}
	}

	//void AddForce(Vector2 force, ForceMode2D = ForceMode2D.Force);

	void drunkMovement()
	{
		if (isDrunkOn) {
			Vector2 leandir = new Vector2 (Random.Range (-1, 1) * 100.0f, Random.Range (-1, 1) * 100.0f) * 100.0f;
			this.rigidbody2D.AddForce (leandir, ForceMode2D.Force);
			Debug.LogWarning ("drunk kick");
		}
	}
	

}
