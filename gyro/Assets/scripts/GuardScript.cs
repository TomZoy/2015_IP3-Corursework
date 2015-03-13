using UnityEngine;
using System.Collections;

namespace OTM {
public class GuardScript : MonoBehaviour {

	public float moovingSpeed;
	public bool isMove;
	public bool isTurning;


	private float x;
	private float y;

	private Vector2 rotation;
	public float rotZ;

	private Vector3 relative;

	private float startAngle;
	
	


	// Use this for initialization
	void Start () {
		rotation.x = 0;
		rotation.y = 0;

		isMove = false;
		isTurning = false;

	}
	
	// Update is called once per frame
	void Update () {

		//walk ();
		
	   if (isTurning) {
				turnAround();

			}

	}

		public void startTurn ()
		{
			startAngle = transform.localRotation.eulerAngles.z;
			isTurning = true;
		}



    void turnAround()
	{


			

			transform.RotateAround (this.transform.position, new Vector3 (0, 0, 1), 20 * Time.deltaTime);	
			rotZ = transform.localRotation.eulerAngles.z;
				
		    if (rotZ > (startAngle+180.00f)) {isTurning = false; }

	}

	void walk()
	{

		
		//Vector2 leandir = new Vector2 (Random.Range (-1, 1) * 100.0f, Random.Range (-1, 1) * 100.0f) * 10.0f;





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


		


}
}
