using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restartGame : MonoBehaviour {

    public GameObject LevelManager;

    private void Start()
    {
        LevelManager = GameObject.Find("Level Manager");
    }

    // Use this for initialization
    void ReStart () {
        LevelManager.SetActive(false);
        LevelManager.SetActive(true);
	}
	
	
}
