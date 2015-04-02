using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timer : MonoBehaviour {

    private int time;

	// Use this for initialization
	void Start () {
        time = 0;
        InvokeRepeating("timerMethod", 0.10f, 0.10f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void timerMethod()
    {
        time++;
        GameObject.Find("sTime").GetComponent<Text>().text = time.ToString();
    }
}
