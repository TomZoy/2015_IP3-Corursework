using UnityEngine;
using System.Collections;

namespace OTM
{
    public class ChangeCharacterSprite : MonoBehaviour
    {


        public Sprite[] playerSprites;// = new Sprite[4];
        public Sprite[] guardSprites;

        private float prevX;
        private float prevY;
        private float sensitivity;

        Animator anim;

        void Start()
        {
            if (this.tag == "Player")
            {
                playerSprites = Resources.LoadAll<Sprite>("playerSprites");
                sensitivity = 0.10f;
            }
            if (this.tag == "Guard")
            {
                guardSprites = Resources.LoadAll<Sprite>("guardSprites");
                sensitivity = 0.00f;
                anim = GetComponentInChildren<Animator>();
            }



        }

        // Update is called once per frame
        void FixedUpdate()
        {

            if (this.tag == "Guard")
            { detect(); }
        }

        void change(int direction)
        {
            Sprite actualSprite;
            if (this.tag == "Player")
            {
                actualSprite = playerSprites[direction];
                GetComponent<SpriteRenderer>().sprite = actualSprite;
            }

            else
            {
                actualSprite = guardSprites[direction];

                GetComponentInChildren<SpriteRenderer>().sprite = actualSprite;

            }
        }


        public void detect()
        {
            float Xdiff = Mathf.Abs(prevX - transform.position.x);
            float Ydiff = Mathf.Abs(prevY - transform.position.y);

            anim.SetInteger("guardDir", -1);

            if (Xdiff > Ydiff) //the movement on the X is bigger than on the Y
            {
                if ((prevX < transform.position.x) && (Xdiff > sensitivity)) //travelin to the right
                {
                    anim.SetInteger("guardDir", 2);
                    transform.GetChild(0).transform.localEulerAngles = new Vector3(0, 0, 90.00f);
                    
                }
                if ((prevX > transform.position.x) && (Xdiff > sensitivity)) //traveling to the left
                {
                    transform.GetChild(0).transform.localEulerAngles = new Vector3(0, 0,270.00f);
                    anim.SetInteger("guardDir", 0);
                }
            }
            else
            {
                if ((prevY < transform.position.y) && (Ydiff > sensitivity)) //travelin to the right
                {
                    anim.SetInteger("guardDir", 1);
                    //this.GetComponentInChildren<GuardSpriteManager>().refresh(0.00f);
                    transform.GetChild(0).transform.eulerAngles = new Vector3(0, 0, 0.00f);
                }
                if ((prevY > transform.position.y) && (Ydiff > sensitivity)) //traveling to the left
                {       
                    anim.SetInteger("guardDir", 3);
                    transform.GetChild(0).transform.eulerAngles = new Vector3(0, 0, 0.00f);
                }
            }

            prevX = transform.position.x;
            prevY = transform.position.y;
        }

        //overloaded version for Player to call
        public void detect(float x, float y)
        {

            if (Mathf.Abs(x) > Mathf.Abs(y)) //the movement on the X is bigger than on the Y
            {
                if ((x > 0) && (Mathf.Abs(x) > sensitivity)) //travelin to the right
                    change(3);

                if ((x < 0 ) && (Mathf.Abs(x) > sensitivity)) //traveling to the left
                    change(2);
            }
            else
            {
                if ((y > 0) && (Mathf.Abs(y) > sensitivity)) //travelin to the right
                    change(1);
                if ((y < 0) && (Mathf.Abs(y) > sensitivity)) //traveling to the left
                    change(0);
            }

        }


    }
}