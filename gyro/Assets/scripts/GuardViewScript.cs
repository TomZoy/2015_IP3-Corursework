using UnityEngine;
using System.Collections;

public class GuardViewScript : MonoBehaviour {


	public float entertime;
	private GameObject player;

	// Use this for initialization
	void Start () {
	
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		
		if (other.gameObject.CompareTag("Player")) {
			
			Debug.LogWarning ("I see you :PP Enter");
			entertime = Time.time;
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		
		if (other.gameObject.CompareTag("Player")) {
			
			Debug.LogWarning ("I see you :PP ");

			if (Mathf.FloorToInt(Time.time - entertime)> 1 )
			{
				Debug.LogWarning ("I see you :PP for 1 sec");
				player.SendMessage("incSuspicion",1);
				entertime = Time.time;

			}
		}
	}
}
