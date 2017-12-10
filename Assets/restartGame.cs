using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restartGame : MonoBehaviour {

    public GameObject LevelManager;

	// Use this for initialization
	void ReStart () {
        LevelManager.setAcitve(false);
        LevelManager.setActive(true);
	}
	
	
}
