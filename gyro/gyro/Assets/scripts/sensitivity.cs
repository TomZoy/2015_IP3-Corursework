// Author: Zoltan Tompa 2015

using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class sensitivity : MonoBehaviour {



	Text text;
	GameObject obj;



	// Use this for initialization
	void Start () {
	
		text = GetComponent <Text>();



		obj = GameObject.Find("Player");


	}
	
	// Update is called once per frame
	void Update () {

		text.text =  obj.GetComponent<PlayerScript>().Sensitivity.ToString();

		//text.text = "sensitivity: "+ obj.;
	
	}
}
