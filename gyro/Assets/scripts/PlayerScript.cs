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
        public int Drunklevel; //the smaller the number the more drunk she is. 0 = 100%

        private float sensitivity;
        public bool isHiden;


        Animator anim;


        public int suspicion = 0; //goes from 0-1
        public Scrollbar SuspBar;

        public Vector3 startPos; // = new Vector3(0.00f, 0.00f, 0.00f);

        public GameObject[] hidingBoxesList;


        private Color hidenC = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        private Color visibleC = new Color(1.0f, 1.0f, 1.0f, 1f);



        // Use this for initialization
        void Start()
        {

            Sensitivity = 250.0f;
            sensitivity = 0.10f;

            startPos = GameObject.Find("startPosMarker").transform.position;

            prevCameraTrigger = "";
            obj = GameObject.Find("Main Camera");

            // Disable screen dimming
            Screen.sleepTimeout = SleepTimeout.NeverSleep;

            // Fix orientation to portrait
            Screen.orientation = ScreenOrientation.Portrait;


            this.rigidbody2D.drag = 5.0f;
            InvokeRepeating("drunkMovement", 0.50f, 0.50f);

            hidingBoxesList = GameObject.FindGameObjectsWithTag("hidingB");

            isDrunkOn = true;

            anim = GetComponent<Animator>();

            Drunklevel = 5;

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


                this.GetComponent<SpriteRenderer>().color = hidenC;
                isDrunkOn = false;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().color = visibleC; // Set to opaque black
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
            if (Input.GetKey("w"))        { movePlayer(0.00f, 1.0f);  }
            else if (Input.GetKey("s"))   { movePlayer(0.00f, -1.0f); }
            else if (Input.GetKey("a"))   { movePlayer(-1.0f, 0.0f); }
            else if (Input.GetKey("d"))   { movePlayer(1.0f, 0.0f);  }
        }

        //method to actually move the player based on the input
        void movePlayer(float x, float y)
        {
            transform.Translate(x * Time.deltaTime * Sensitivity, y * Time.deltaTime * Sensitivity, 0);
            detect(x * Sensitivity, y * Sensitivity);
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
                if (Random.Range(0, Drunklevel) == 0)
                {
                    float f = 1000.0f;
                    if (Random.Range(0, 2) == 0) { f = -1000.0f; }


                    Vector2 leandir = new Vector2( Random.Range(5, 11) * f, Random.Range(5, 11) * f);
                    this.rigidbody2D.AddForce(leandir, ForceMode2D.Force);
                    GetComponent<SoundFXScript>().playSoundFXz();
                    Debug.LogWarning("drunk kick");
                }
            }
        }

        //method to reset the player upon dead
        public void suspFullRestart()
        {

            suspicion = 0;
            transform.position = startPos;
            GameObject.Find("startPosMarker").GetComponent<SoundFXScript>().playSoundFXz();
            Debug.Log("try again =)");
        }




        //overloaded version for Player to call, used to control the Animator
        public void detect(float x, float y)
        {
            anim.SetInteger("direction", -1);

            if (Mathf.Abs(x) > Mathf.Abs(y)) //the movement on the X is bigger than on the Y
            {
                if ((x > 0) && (Mathf.Abs(x) > sensitivity)) //travelin to the right
                    anim.SetInteger("direction",2);

                if ((x < 0) && (Mathf.Abs(x) > sensitivity)) //traveling to the left
                    anim.SetInteger("direction", 0);
            }
            else
            {
                if ((y > 0) && (Mathf.Abs(y) > sensitivity)) //travelin to the right
                    anim.SetInteger("direction", 1);
                if ((y < 0) && (Mathf.Abs(y) > sensitivity)) //traveling to the left
                    anim.SetInteger("direction", 3);
            }

        }



    } //closing class
} //closing namespace
