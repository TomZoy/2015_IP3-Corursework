using UnityEngine;
using System.Collections;

namespace OTM {
public class Hiding_reporter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerExit2D(Collider2D other) {
		
		if ((other.gameObject.CompareTag ("Player")) && (this.gameObject.name == "outer")) {
			this.GetComponentInParent<Hiding> ().flipOuterCorssed ();

			Debug.Log (" outer exit");
		}

		if ((other.gameObject.CompareTag("Player")) && (this.gameObject.name=="inner")) {
				this.GetComponentInParent<Hiding>().innerStaying = false;
				
				Debug.Log("staying");
		}
	}

		void OnTriggerEnter2D(Collider2D other) {
			
			if ((other.gameObject.CompareTag("Player")) && (this.gameObject.name=="outer")) {
				this.GetComponentInParent<Hiding>().flipOuterCorssed();
				
				Debug.Log(" outer enter");
			}
		}

		void OnTriggerStay2D(Collider2D other) {
			
			if ((other.gameObject.CompareTag("Player")) && (this.gameObject.name=="inner")) {
				this.GetComponentInParent<Hiding>().innerStaying = true;
				
				Debug.Log("staying");
			}
		}

}
}