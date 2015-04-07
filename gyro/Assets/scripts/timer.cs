using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace OTM
{
    public class timer : MonoBehaviour
    {

        public int time;
        private GameObject player;

        // Use this for initialization
        void Start()
        {
            time = 8000;
            InvokeRepeating("timerMethod", 0.01f, 0.01f);
            player = GameObject.Find("Player");
        }

        // Update is called once per frame
        void Update()
        {

        }

        void timerMethod()
        {
            time--;
            GameObject.Find("sTime").GetComponent<Text>().text = "" + time.ToString();

            if (time < 0) { timeUp(); }
        }

        void timeUp()
        {
            time = 2500;
            player.GetComponent<PlayerScript>().suspFullRestart();

        }
    }
}