using UnityEngine;
using System.Collections;

namespace OTM
{
    public class GuardScript : MonoBehaviour
    {

        public float moovingSpeed;

        public enum GuardStates { patrolWalk, patrolTurn };

        public GuardStates GuardState;


        private Vector3 startRotation;
        private Vector3 targetAngle;

        public bool isOrigDir;
        public float rotZ;

        private float prevX;
        private float prevY;

  


        // Use this for initialization
        void Start()
        {

            GuardState = GuardStates.patrolWalk;

            targetAngle.x = 0;
            targetAngle.y = 0;

            moovingSpeed = 50.0f;

            startRotation = transform.localRotation.eulerAngles;
            rotZ = transform.localRotation.eulerAngles.z;
            isOrigDir = true;


        }

        // Update is called once per frame
        void Update()
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

        public void startTurn()
        {
            if (GuardState != GuardStates.patrolTurn)
            {
                GuardState = GuardStates.patrolTurn;

                targetAngle.z = transform.localRotation.eulerAngles.z + 180f;
                if (targetAngle.z > 360) { targetAngle.z = targetAngle.z - 360; }
                isOrigDir = !isOrigDir;
                Debug.Log("turning");
            }
        }



        void turnAround()
        {
            //rotate around-ing
            transform.RotateAround(this.transform.position, new Vector3(0, 0, 1), 75 * Time.deltaTime);
            //lerping
            //transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngle, 0.5f * Time.deltaTime);

            if ((transform.eulerAngles.z > (targetAngle.z - 1f)) && (transform.eulerAngles.z < (targetAngle.z + 1f)))
            {


                if (isOrigDir)
                {
                    transform.eulerAngles = startRotation;
                }

                else
                {
                    transform.eulerAngles = new Vector3(startRotation.x, startRotation.y, (startRotation.z + 180.00f));
                }

                GuardState = GuardStates.patrolWalk;
            }

        }

        void walk()
        {

            transform.Translate(Vector3.up * moovingSpeed * Time.deltaTime);

        }




    }
}