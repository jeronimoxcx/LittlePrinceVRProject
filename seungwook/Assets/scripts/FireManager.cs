﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour {
    public Transform cameraTransform;
    public MemoryPool pool;
    public Transform firePosition_Mono_N;
    public Transform firePosition_Mono_S;
    public Transform firePosition_Bar;
    public GameObject BarMagnet;
    public float power = 20.0f;
    private int monoNLimit = 3;
    private int monoSLimit = 3;
    private int barLimit = 3;

	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            firemonoN();
            
        }

        if (Input.GetButtonDown("Fire2"))
        {
            monoNLimit = 3;
            
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            firemonoS();
            
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            monoSLimit = 3;
            
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            fireBar();
        }

    }

    void firemonoN()
    {
        if (monoNLimit != 0)
        {
            
            GameObject temp = pool.GetMono_N();

            temp.transform.position =
                firePosition_Mono_N.position;

            temp.GetComponent<Rigidbody>().velocity =
                cameraTransform.forward * power;

            monoNLimit -= 1;

            //Debug.Log(monoNLimit);
        }
    }

    void firemonoS()
    {
        if (monoSLimit != 0)
        {
            GameObject temp = pool.GetMono_S();

            temp.transform.position =
                firePosition_Mono_S.position;

            temp.GetComponent<Rigidbody>().velocity =
                cameraTransform.forward * power;

            monoSLimit -= 1;

            //Debug.Log(monoSLimit);
        }
    }

    void fireBar()
    {
        if (barLimit > 0)
        {
            GameObject temp = pool.GetBar();

            temp.transform.position = firePosition_Bar.position;
            
            //temp.GetComponent<Rigidbody>().velocity = cameraTransform.forward * power;

            temp.SendMessage("fly", cameraTransform.forward);

            barLimit -= 1;
        }
    }


}
