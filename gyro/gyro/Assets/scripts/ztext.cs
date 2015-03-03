using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ztext : MonoBehaviour {

	Text text;




	// Use this for initialization
	void Start () {
	
		text = GetComponent <Text>();


	}
	
	// Update is called once per frame
	void Update () {

		text.text = "Z-Axis: " + Input.acceleration.z;
	
	}
}
