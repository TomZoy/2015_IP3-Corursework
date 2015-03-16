using UnityEngine;
using System.Collections;

namespace OTM {
public class GuardScript : MonoBehaviour {

	public float moovingSpeed;

    public enum GuardStates { patrolWalk, patrolTurn };

    public GuardStates GuardState;

	public bool isTurning;




	private Vector3 startRotation;
    private Vector3 targetAngle;

	public bool isOrigDir;
	public float rotZ;
	



	
	


	// Use this for initialization
	void Start () {

        GuardState = GuardStates.patrolWalk;

        targetAngle.x = 0;
        targetAngle.y = 0;

		startRotation = transform.localRotation.eulerAngles;
		rotZ = transform.localRotation.eulerAngles.z;
		isTurning = false;
		isOrigDir = true;

	}
	
	// Update is called once per frame
	void Update () 
	{

        if (GuardState == GuardStates.patrolWalk)
        {
            walk();
        }
        else if (GuardState == GuardStates.patrolTurn)
        {
            turnAround();
        }


}

		public void startTurn ()
		{
            if (GuardState != GuardStates.patrolTurn)
			{
                GuardState = GuardStates.patrolTurn;

				targetAngle.z = transform.localRotation.eulerAngles.z + 180f;
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

                GuardState = GuardStates.patrolWalk;
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
