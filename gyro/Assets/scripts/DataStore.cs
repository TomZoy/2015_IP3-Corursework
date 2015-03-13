using UnityEngine;
using System.Collections;

namespace OTM {
public static class DataStore {

	public static int gameTime =0;

	// Use this for initialization
	static void Start () {

	}
	
	// Update is called once per frame
	static void  Update () {
	
	}

	static void countTime()
	{
		gameTime++;
	}

}
}