using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class comboSlider : MonoBehaviour {
    //bar magnet
    public MemoryPool pool;
    public Transform firePosition_L;
    public Transform firePosition_R;
    public GameObject BarMagnet;
    public float power = 20.0f;

    public bool signal_R;
    public bool signal_L;
    public GameObject controllerLeft;
    public GameObject controllerRight;

    //combo slider
    public GameObject BarSliderPanel;
    public GameObject[] BarIcons;
    public static int maxGage = 5;
    public static int currentGage = 0;

    private Vector3 firePosition_M;
    private bool alreadyIn = false;
    public bool useBar = false;

    // Use this for initialization
    void Start () {
        BarSliderPanel = GameObject.Find("BarSliderPanel");
        BarIcons = new GameObject[maxGage];
        for(int i = 0; i < maxGage; i++)
        {
            BarIcons[i] = GameObject.Find("BarIcon"+i);
            BarIcons[i].SetActive(false);
        }
        BarSliderPanel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pos_start = new Vector3(firePosition_L.position.x, firePosition_L.position.y, firePosition_L.position.z);
        Vector3 pos_end = new Vector3(firePosition_R.position.x, firePosition_R.position.y, firePosition_R.position.z);
        firePosition_M = Vector3.Lerp(pos_start, pos_end, 0.5f);


        

        signal_R = controllerRight.GetComponent<FireManager_R>().signal;
        signal_L = controllerLeft.GetComponent<FireManager_L>().signal;

        if (useBar && signal_R && signal_L)
        {
            if (!alreadyIn)
            {
                alreadyIn = true;
                fireBar();
                BarIcons[currentGage].SetActive(false);
            }
        }
        else
            alreadyIn = false;
        

        if (currentGage >0)
        {
            BarSliderPanel.SetActive(true);
            for(int i = 0; i < currentGage; i++)
            {
                BarIcons[i].SetActive(true);
            }
            useBar = true;
        }
        else
        {
            BarSliderPanel.SetActive(false);
            useBar = false;
        }
        



    }
    
    void fireBar()
    {
        if (currentGage > 0)
        {
            
            
            GameObject temp = pool.GetBar();

            temp.transform.position = firePosition_M;

            temp.SendMessage("fly", firePosition_L.forward);

            currentGage -= 1;
        }
    }
}
