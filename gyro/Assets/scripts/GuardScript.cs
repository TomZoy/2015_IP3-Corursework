using UnityEngine;
using System.Collections;

namespace OTM {
public class GuardScript : MonoBehaviour {

	public float moovingSpeed;
	public bool isMove;
	public bool isTurn;

	private float x;
	private float y;

	private Vector2 rotation;
	public float rotZ;

	private Vector3 relative;
	
	


	// Use this for initialization
	void Start () {
		rotation.x = 0;
		rotation.y = 0;

		isMove = true;
		isTurn = true;

	}
	
	// Update is called once per frame
	void Update () {

		walk ();
	}


	void walk()
	{

		
		//Vector2 leandir = new Vector2 (Random.Range (-1, 1) * 100.0f, Random.Range (-1, 1) * 100.0f) * 10.0f;


		if (isTurn) {
			transform.RotateAround (this.transform.position, new Vector3 (0, 0, 1), 20 * Time.deltaTime);

			rotZ = this.transform.rotation.z;
		}


			//leandir = leandir + this.rigidbody2D.velocity;
		//rotation.x = this.transform.rotation.x;
		//rotation.y = this.transform.rotation.y;


		//relative = transform.InverseTransformDirection(Vector3.right);
		//relative = transform.InverseTransformDirection(this.transform.localRotation);

		if (isMove) {
			transform.Translate (Vector3.up * 50.00f * Time.deltaTime);
		}	
		//this.rigidbody2D.AddForce (relative*100.0f, ForceMode2D.Force);


	
	}

	void walk2()
	{
		Vector3 moveDirection =  gameObject.transform.position - new Vector3(gameObject.transform.position.x+5.00f,gameObject.transform.position.y,gameObject.transform.position.z); // + new Vector3 (Random.Range (1, 2), Random.Range (0, 1),0.00f)) - gameObject.transform.position;
		if (moveDirection != Vector3.zero)
		{
			float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);

			transform.Translate (moveDirection*10.00f* Time.deltaTime);
		}
	}
		


}
}
