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
    private int monoSLimit = 3;
    private int barLimit = 40;

    public bool signal_R;
    public bool signal_L;
    public GameObject controllerLeft;
    public GameObject controllerRight;

    //combo slider
    public TextMesh comboText;
    public Slider BarGageSlider;
    public int maxGage = 10;
    public static int currentGage = 0;

    private Vector3 firePosition_M;
    private bool alreadyIn = false;
    public bool useBar = false;

    // Use this for initialization
    void Start () {
        BarGageSlider = GameObject.Find("BarGageSlider").GetComponent<Slider>();
        BarGageSlider.value = currentGage;
        comboText.text = "Combo";


        Debug.Log("Left "+controllerLeft.name);

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pos_start = new Vector3(firePosition_L.position.x, firePosition_L.position.y, firePosition_L.position.z);
        Vector3 pos_end = new Vector3(firePosition_R.position.x, firePosition_R.position.y, firePosition_R.position.z);
        firePosition_M = Vector3.Lerp(pos_start, pos_end, 0.5f);


        

        signal_R = controllerRight.GetComponent<FireManager_R>().signal;
        signal_L = controllerLeft.GetComponent<FireManager_L>().signal;
        Debug.Log("currentGage" + currentGage);
        if (useBar && signal_R && signal_L)
        {
            if (!alreadyIn)
            {
                alreadyIn = true;
                fireBar();
                currentGage = 0;
            }
        }
        else
            alreadyIn = false;
        BarGageSlider.value = currentGage;

        if (currentGage >= maxGage)
        {
            
            comboText.text = "Use Bar Magnet!";
            useBar = true;
        }
        



    }
    
    void fireBar()
    {
        if (barLimit > 0)
        {
            
            
            GameObject temp = pool.GetBar();

            temp.transform.position = firePosition_M;

            temp.SendMessage("fly", firePosition_L.forward);

            barLimit -= 1;
        }
    }
}
