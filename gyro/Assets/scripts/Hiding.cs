using UnityEngine;
using System.Collections;

namespace OTM {
public class Hiding : MonoBehaviour {

		private bool outerCorssed = true;
		public bool innerStaying = false;


	public void flipOuterCorssed()
	{
			outerCorssed = !outerCorssed;
	}

		// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

			if ((outerCorssed)&&(innerStaying))
			{
				Debug.LogWarning ("you are in the safe zone!");
				GameObject.Find("Player").GetComponent<PlayerScript>().isDrunkOn = false;
			}
			else 
			{
				GameObject.Find("Player").GetComponent<PlayerScript>().isDrunkOn = true;
			}


	}

} //closing class
} //closing namespace