using UnityEngine;
using System.Collections;

namespace OTM {
public class Hiding : MonoBehaviour {

		private bool outerCorssed = true;
		public bool innerStaying = false;
		
		public bool isPlayerInside;


	public void flipOuterCorssed()
	{
			outerCorssed = !outerCorssed;
	}

		// Use this for initialization
	void Start () {

        isPlayerInside = false;
	}
	
	// Update is called once per frame
	void Update () {

			if ((outerCorssed)&&(innerStaying))
			{
                isPlayerInside = true;
			}
			
			else
			{
                isPlayerInside = false;
			}

	}

} //closing class
} //closing namespace