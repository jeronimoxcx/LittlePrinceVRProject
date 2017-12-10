using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningScene : MonoBehaviour {
    private float movespeed = 0.04f;
    Vector3 movevec;
    public GameObject myImg;
    public GameObject myTitle;
    float starttime;
    float titletimer = 0;

    // Use this for initialization
    void Start () {
        movevec = new Vector3(0, 1, 1) * movespeed;
        starttime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position += movevec;
        if (starttime < Time.time - 15.0f)
        {
            myImg.SetActive(true);
            myTitle.SetActive(true);
            titletimer += Time.deltaTime;
            if (titletimer > 2.0f)
            {
                Application.LoadLevel(2);
            }


        }
	}
}
