using UnityEngine;
using System.Collections;

namespace OTM {
public class _debug : MonoBehaviour {

		public GameObject guard;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

		void OnTriggerEnter2D(Collider2D other) {

			guard.GetComponent<GuardScript> ().startTurn ();
		}

}
}
