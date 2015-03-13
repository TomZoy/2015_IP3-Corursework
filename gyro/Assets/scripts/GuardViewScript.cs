using UnityEngine;
using System.Collections;


namespace OTM {
public class GuardViewScript : MonoBehaviour {


	private float entertime;
	private float exittime;
	private bool isPayerInView;
	private GameObject player;

	// Use this for initialization
	void Start () {
	
		player = GameObject.Find("Player");
		isPayerInView = false;
	}
	
	// Update is called once per frame
		void FixedUpdate () {

		if ((player.GetComponent<PlayerScript>().suspicion  > 0) && (isPayerInView == false)) {
			decreaseSuspition ();
			Debug.Log ("susp should dec");
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		
		if (other.gameObject.CompareTag("Player")) {
			
			Debug.LogWarning ("I see you :PP Enter");
			isPayerInView = true;
			entertime = Time.time;
		}
		
			if (other.gameObject.CompareTag("wall")) {
			
			
				GetComponentInParent<GuardScript>().startTurn();
				Debug.LogWarning ("wall ahhead !!!!");

			}
		
	}


	void OnTriggerExit2D(Collider2D other) {
		
		if (other.gameObject.CompareTag("Player")) {
			
			Debug.LogWarning ("I see you :(( exit");
			isPayerInView = false;
			exittime = Time.time;

		}
	}

	void decreaseSuspition()
	{


			if ((Time.time - exittime) > 1.00f) {

				Debug.LogWarning ("I don't see you :(( decreasing");
				player.SendMessage ("decSuspicion", 2);
				exittime = Time.time;
			
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		
		if (other.gameObject.CompareTag("Player")) {
			
			Debug.LogWarning ("I see you :PP ");

			if ((Time.time - entertime)> 0.1f )
			{
				Debug.LogWarning ("I see you :PP for 0.1 sec");
				player.SendMessage("incSuspicion",2);
				entertime = Time.time;
					Handheld.Vibrate();

				if (player.GetComponent<PlayerScript>().suspicion  >= 100) { player.GetComponent<PlayerScript>().suspFullRestart();}
			}
		}
	}
}
}
