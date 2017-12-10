using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOnClick : MonoBehaviour {
    /*
	public void LoadScene(int level)
    {
        Application.LoadLevel(level);
    }*/
    public int currLevel = 0;
    public string[] levelNames = new string[2] { "1", "2" };
    //static LevelSwitch s = null;

    private void Start()
    {/*
        if (s == null)
            s = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);*/
    }
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            currLevel = (currLevel + 1) % 2;
            SteamVR_LoadLevel.Begin(levelNames[currLevel]);
        }
    }
}
