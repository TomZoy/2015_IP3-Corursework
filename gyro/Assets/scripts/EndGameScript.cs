using UnityEngine;
using System.Collections;

public class EndGameScript : MonoBehaviour {


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Congrats, you made it to the end!");
        }
    }
}
