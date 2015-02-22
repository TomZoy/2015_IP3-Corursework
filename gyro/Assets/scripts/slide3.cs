using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class slide3 : MonoBehaviour {


	private Vector3 previousPosition;
	public float Sensitivity;
	private GameObject obj;

	private GameObject  SSlider;

	// Use this for initialization
	void Start () {

		previousPosition = transform.position;
		Sensitivity = 20.0f;

		SSlider = GameObject.Find("Slider");
	
	}
	
	// Update is called once per frame
	void Update () {

		Sensitivity = SSlider.GetComponent<Slider>().normalizedValue;

		transform.Translate(Input.acceleration.x * Time.deltaTime * Sensitivity ,Input.acceleration.y * Time.deltaTime * Sensitivity,0);
		
		if (Input.touchCount > 0 && 
		    Input.GetTouch(0).phase == TouchPhase.Moved) {
			
			Sensitivity = Sensitivity + 5.0f;
	
	}
}
}