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
				Debug.LogWarning ("you stepped in the safe zone!");
			}


	}


		void OnTriggerExit2D(Collider2D other) {
			
			if (other.gameObject.CompareTag("Player")) {
				

			}
		}




} //closing class
} //closing namespace