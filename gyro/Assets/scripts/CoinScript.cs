using UnityEngine;
using System.Collections;


namespace OTM
{
    public class CoinScript : MonoBehaviour
    {

        private GameObject self;

        private GameObject timer;
        public int coinvalue;

        // Use this for initialization
        void Start()
        {
            self = this.gameObject;
            timer = GameObject.Find("sTime");
            coinvalue = 200;
        }

        // Update is called once per frame
        void Update()
        {

            transform.RotateAround(this.transform.position, new Vector3(0, 1,0), 75 * Time.deltaTime);
        }


        void OnTriggerEnter2D(Collider2D other)
        {

            if (other.gameObject.CompareTag("Player"))
            {
                timer.GetComponent<timer>().addtime(coinvalue);
                GetComponent<SoundFXScript>().playSoundFXz();
                Destroy(GetComponent<SpriteRenderer>());

                Destroy(this.gameObject,1);
                // gameObject.SetActive(false);
               
            }

        }






    }
}