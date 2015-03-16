﻿// Author: Zoltan Tompa 2015

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



        public int tmp = 0;

        // Use this for initialization
        void Start()
        {

            tmp = 0;


            Sensitivity = 250.0f;

            prevCameraTrigger = "";
            obj = GameObject.Find("Main Camera");

            // Disable screen dimming
            Screen.sleepTimeout = SleepTimeout.NeverSleep;


            this.rigidbody2D.drag = 5.0f;
            InvokeRepeating("drunkMovement", 2.00f, 1.50f);

            hidingBoxesList = GameObject.FindGameObjectsWithTag("hidingB");
            tmp = hidingBoxesList.Length;


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

                if (hidingBoxesList[i].GetComponent<Hiding>().isPlayerInside == true) { isHiden = true; Debug.Log("here"); }
                i++;
 
            }
            Debug.Log(i);

            if (isHiden)
            {
                Debug.LogWarning("you are in the safe zone!");
                isDrunkOn = false;
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

            // testing SuspBar
            SuspBar.size = suspicion / 100f;


            //transform.Translate(Input.acceleration.x * Time.deltaTime * Sensitivity ,Input.acceleration.y * Time.deltaTime * Sensitivity,0);
            movePlayer(Input.acceleration.x, Input.acceleration.y);

            if (Input.GetKey("w"))
            {
                movePlayer(0.0f, 1.0f);
            }
            else if (Input.GetKey("s"))
            {
                movePlayer(0.0f, -1.0f);
            }
            else if (Input.GetKey("a"))
            {
                movePlayer(-1.0f, 0.0f);
            }
            else if (Input.GetKey("d"))
            {
                movePlayer(1.0f, 0.0f);
            }



            seeIfHidden();
            


        }

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

        void drunkMovement()
        {
            if (isDrunkOn)
            {
                Vector2 leandir = new Vector2(Random.Range(-1, 1) * 100.0f, Random.Range(-1, 1) * 100.0f) * 100.0f;
                this.rigidbody2D.AddForce(leandir, ForceMode2D.Force);
                Debug.LogWarning("drunk kick");
            }
        }

        public void suspFullRestart()
        {

            suspicion = 0;
            transform.position = startPos;
            Debug.Log("try again =)");
        }


    } //closing class
} //closing namespace
