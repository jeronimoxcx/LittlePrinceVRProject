using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScroll : MonoBehaviour {

    public TextMesh levelIndicator;
    public int levelNum=1;

    public bool gameOver = false;
	// Use this for initialization
	void Start () {
        //levelIndicator.text = "Level " + levelNum;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
