using UnityEngine;
using System.Collections;

public class EndGameScript : MonoBehaviour {


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<SoundFXScript>().playSoundFXz();
            Debug.Log("Congrats, you made it to the end!");
            
            
            // --------------- scene changing here to main HUB  ---------------------- //
        }
    }
}
