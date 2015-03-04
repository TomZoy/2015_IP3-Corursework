using UnityEngine;
using System.Collections;

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
	void Update () {

		if ((player.GetComponent<PlayerScript>().suspicion  > 0) && (isPayerInView == false)) {
			decreaseSuspition ();
			Debug.LogError ("should dec");
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		
		if (other.gameObject.CompareTag("Player")) {
			
			Debug.LogWarning ("I see you :PP Enter");
			isPayerInView = true;
			entertime = Time.time;
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


			if (Mathf.FloorToInt (Time.time - exittime) > 1) {

				Debug.LogWarning ("I don't see you :(( decreasing");
				player.SendMessage ("decSuspicion", 5);
				exittime = Time.time;
			Debug.LogError ("should dec");
			
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		
		if (other.gameObject.CompareTag("Player")) {
			
			Debug.LogWarning ("I see you :PP ");

			if (Mathf.FloorToInt(Time.time - entertime)> 1 )
			{
				Debug.LogWarning ("I see you :PP for 1 sec");
				player.SendMessage("incSuspicion",5);
				entertime = Time.time;

			}
		}
	}
}
