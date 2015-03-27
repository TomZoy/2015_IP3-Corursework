using UnityEngine;
using System.Collections;

public class ChangeCharacterSprite : MonoBehaviour {


    public Sprite[] playerSprites;// = new Sprite[4];
    public Sprite[] guardSprites;

    private float prevX;
    private float prevY;
    private float sensitivity;

        void Start()
    {
        if (this.tag == "Player")
        {
            playerSprites = Resources.LoadAll<Sprite>("playerSprites");
            sensitivity = 1.00f;
        }
        if (this.tag == "Guard")
        {
            guardSprites = Resources.LoadAll<Sprite>("guardSprites");
            sensitivity = 0.00f;
        }

    }
	
	// Update is called once per frame
	void Update () {

        float Xdiff = Mathf.Abs(prevX - transform.position.x);
        float Ydiff = Mathf.Abs(prevY - transform.position.y);

        if (Xdiff > Ydiff) //the movement on the X is bigger than on the Y
        {
            if ((prevX < transform.position.x) && (Xdiff > sensitivity)) //travelin to the right
                change(3);
            if ((prevX > transform.position.x)&& (Xdiff > sensitivity)) //traveling to the left
                change(2);
        }
        else 
        {
            if ((prevY < transform.position.y) && (Ydiff > sensitivity)) //travelin to the right
                change(1);
            if ((prevY > transform.position.y) && (Ydiff > sensitivity)) //traveling to the left
                change(0);
        }

        prevX = transform.position.x;
        prevY = transform.position.y;
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


}