using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class sensitivity : MonoBehaviour {



	Text text;
	GameObject obj;



	// Use this for initialization
	void Start () {
	
		text = GetComponent <Text>();



		obj = GameObject.Find("white_button");


	}
	
	// Update is called once per frame
	void Update () {

		text.text =  obj.GetComponent<slide3>().Sensitivity.ToString();

		//text.text = "sensitivity: "+ obj.;
	
	}
}
