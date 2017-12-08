using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSwitch : MonoBehaviour {
   
	

    public void LoadScene(int level)
    {
        Application.LoadLevel(level);
    }
}
