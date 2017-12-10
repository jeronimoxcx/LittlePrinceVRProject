using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSwitch : MonoBehaviour {
    public int currLevel = 0;

    public string[] levelNames = new string[2] { "HTCViveTest", "Level2" };
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
            currLevel = (currLevel + 1) % 2;
            SteamVR_LoadLevel.Begin(levelNames[currLevel]);
        
	}
}
