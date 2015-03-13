using UnityEngine;
using System.Collections;

namespace OTM {
public class GuardScript : MonoBehaviour {

	public float moovingSpeed;
	public bool isMove;
	public bool isTurning;




	private Vector3 startRotation;
	public bool isOrigDir;
	public float rotZ;
	


	private Vector3 targetAngle;
	
	


	// Use this for initialization
	void Start () {
		
		startRotation = transform.localRotation.eulerAngles;
		isMove = false;
		isTurning = false;
		isOrigDir = true;

	}
	
	// Update is called once per frame
	void Update () 
	{

		if (isMove) 
			{	
				walk (); 
			}
		
	   if (isTurning) 
	   		{
				isMove = false;
				turnAround();
			}
			else 
			{
				isMove = true;
			}
	}

		public void startTurn ()
		{
			if (!isTurning)
			{
				targetAngle.x = 0;
				targetAngle.y = 0;
				targetAngle.z = transform.localRotation.eulerAngles.z + 180f;
				isTurning = true;
				isOrigDir = !isOrigDir;
				
				Debug.Log("turning");
			}
		}



    void turnAround()
	{
			//rotate around-ing
			transform.RotateAround (this.transform.position, new Vector3 (0, 0, 1), 35 * Time.deltaTime);
			//lerping
			//transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngle, 0.5f * Time.deltaTime);
			
			if ((transform.eulerAngles.z > (targetAngle.z - 1f))&&(transform.eulerAngles.z < (targetAngle.z + 1f)))
			{
				
				 
				if (isOrigDir) 
				{ 
					transform.eulerAngles = startRotation; 
				} 
				
				else 
				{ 
					transform.eulerAngles = new Vector3(startRotation.x,startRotation.y,(startRotation.z + 180.00f)); 
				}
				
				isTurning = false;
			}
			
			
			
			
			
			
			
			
			
			
			
			//{isTurning = false; if (isOrigDir) { this.transform.rotation.z = (startRotation); } else { transform.rotation.z = startRotation + 180f; }}
			//if (transform.eulerAngles.z > (targetAngle.z - 1.00f)) {isTurning = false; transform.eulerAngles = targetAngle;}
//			transform.RotateAround (this.transform.position, new Vector3 (0, 0, 1), 20 * Time.deltaTime);	
//			rotZ = transform.localRotation.eulerAngles.z;
			
//			if(rotZ >= 180) {rotZ = rotZ - 180;}		
//		    if (rotZ > (startAngle+179.00f)) {isTurning = false; }

	}

	void walk()
	{

		
		//Vector2 leandir = new Vector2 (Random.Range (-1, 1) * 100.0f, Random.Range (-1, 1) * 100.0f) * 10.0f;





			//leandir = leandir + this.rigidbody2D.velocity;
		//rotation.x = this.transform.rotation.x;
		//rotation.y = this.transform.rotation.y;


		//relative = transform.InverseTransformDirection(Vector3.right);
		//relative = transform.InverseTransformDirection(this.transform.localRotation);

		
			transform.Translate (Vector3.up * 50.00f * Time.deltaTime);
			



	
	}


		


}
}
