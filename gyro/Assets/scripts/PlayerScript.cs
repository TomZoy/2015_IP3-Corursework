// Author: Zoltan Tompa 2015

using UnityEngine;
using System.Collections;
using UnityEngine.UI;


namespace OTM
{
    public class PlayerScript : MonoBehaviour
    {

        public float Sensitivity;

        public string prevCameraTrigger;
        private GameObject obj;
        public static int sleepTimeout;
        public bool isDrunkOn;

        public bool isHiden;




        public int suspicion = 0; //goes from 0-1
        public Scrollbar SuspBar;

        public Vector3 startPos = new Vector3(0.00f, 0.00f, 0.00f);

        public GameObject[] hidingBoxesList;




        // Use this for initialization
        void Start()
        {

            Sensitivity = 250.0f;

            prevCameraTrigger = "";
            obj = GameObject.Find("Main Camera");

            // Disable screen dimming
            Screen.sleepTimeout = SleepTimeout.NeverSleep;


            this.rigidbody2D.drag = 5.0f;
            InvokeRepeating("drunkMovement", 2.00f, 1.50f);

            hidingBoxesList = GameObject.FindGameObjectsWithTag("hidingB");

            isDrunkOn = true;

        }

        public int getSuspicion
        {
            get
            {
                return suspicion;
            }
        }

        //method to iterate through all hidingboxes (with tag "hidingB") and see if any reports true
        private void seeIfHidden()
        {
            //assume player is not hiden
            isHiden = false;


            int i = 0;
            int t = hidingBoxesList.Length;

            while( i <(t))
            {

                if (hidingBoxesList[i].GetComponent<Hiding>().isPlayerInside == true) { isHiden = true;}
                i++;
 
            }
            Debug.Log(i);

            if (isHiden)
            {
                Debug.LogWarning("you are in the safe zone!");
                isDrunkOn = false;
            }
            else
            {
                Debug.LogWarning("you are out from safe zone!");
                isDrunkOn = true;
            }

        }





        public void setSuspicion(int s)
        {
            suspicion = s;
        }

        public void incSuspicion(int s)
        {
            suspicion = suspicion + s;
        }

        public void decSuspicion(int s)
        {
            suspicion = suspicion - s;
        }


        // Update is called once per frame
        void Update()
        {

            // displaying the SuspBar
            SuspBar.size = suspicion / 100f;


            //calling a method to move the player
            getPlayerInput();


            //check if player is hidden
            seeIfHidden();
            


        }

        void getPlayerInput()
        {
            //detect mobile device input
            movePlayer(Input.acceleration.x, Input.acceleration.y);

            //detect kayboard input
            if (Input.GetKey("w"))        { movePlayer(0.0f, 1.0f);  }
            else if (Input.GetKey("s"))   { movePlayer(0.0f, -1.0f); }
            else if (Input.GetKey("a"))   { movePlayer(-1.0f, 0.0f); }
            else if (Input.GetKey("d"))   { movePlayer(1.0f, 0.0f);  }
        }

        //method to actually move the player based on the input
        void movePlayer(float x, float y)
        {
            transform.Translate(x * Time.deltaTime * Sensitivity, y * Time.deltaTime * Sensitivity, 0);
        }

        void OnTriggerEnter2D(Collider2D other)
        {

            if (prevCameraTrigger != other.gameObject.name)
            {
                obj.GetComponent<FollowingCamera2>().setRestriction(other.gameObject.name);
                obj.GetComponent<FollowingCamera2>().verticalMin = -1069.00f;
                obj.GetComponent<FollowingCamera2>().verticalMax = -1069.00f;
                prevCameraTrigger = other.gameObject.name;
                Debug.LogWarning("trigger change ");
            }
        }

        //method to simulate "drunk movement/kick"
        //invoked from Playerscript/Start periodically
        void drunkMovement()
        {
            if (isDrunkOn)
            {
                Vector2 leandir = new Vector2(Random.Range(-1, 1) * 100.0f, Random.Range(-1, 1) * 100.0f) * 100.0f;
                this.rigidbody2D.AddForce(leandir, ForceMode2D.Force);
                Debug.LogWarning("drunk kick");
            }
        }

        //method to reset the player upon dead
        public void suspFullRestart()
        {

            suspicion = 0;
            transform.position = startPos;
            Debug.Log("try again =)");
        }


    } //closing class
} //closing namespace
