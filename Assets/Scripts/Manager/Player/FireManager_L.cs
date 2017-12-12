﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager_L : MonoBehaviour
{
    public MemoryPool pool;
    public Transform firePosition_S;
    public GameObject BarMagnet;
    public float power = 20.0f;
    private int barLimit = 40;
    private bool up = false;
    private bool down = false;


    private float shootInterval = 0.0f;
    private bool shootAction = false;


    private Vector3 monoposition;

    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    public SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    public SteamVR_TrackedObject trackedObj;

    public bool signal;
    public bool signal_R;
    public GameObject controllerRight;


    // Use this for initialization
    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        controllerRight = GameObject.Find("Controller (right)");
    }

    // Update is called once per frame
    void Update()
    {
        signal = controller.GetPress(gripButton);
        //signal_R = controllerRight.GetComponent<FireManager_R>().signal;
        if (controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }


        if (controller.GetPress(triggerButton))
        {
            if (!shootAction)
            {
                shootAction = true;
                firemonoS();
                GameObject monoS;
                monoS = GameObject.FindWithTag("S");
                if (monoS != null)
                {
                    Debug.Log("monoS name" + monoS.name);
                    if (monoS.name.Contains("Monopole"))
                    {
                        monoposition = monoS.transform.position;
                        monoS.SendMessage("ApplyMagneticField", monoposition);
                    }

                }
            }
            else
            {
                shootInterval += Time.deltaTime;
                if (shootInterval > 0.2f)
                {
                    shootInterval = 0.0f;
                    shootAction = false;

                }
            }
        }
        /*
        if (signal&&signal_R)
            fireBar();*/
/*
        if (controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {

            if (controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).y > 0.5f && !up)
            {
                up = true;
                firemonoS();
                Debug.Log("Dpad Up");
            }
            else if (controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).y < -0.5 && !down)
            {
                down = true;
                fireMField_S();
                Debug.Log("Dpad Down");
            }


        }
        else
        {
            up = false;
            down = false;

        }*/

    }

    void firemonoS()
    {
        Debug.Log("Fired");


        GameObject temp = pool.GetMono_S();

        temp.transform.position =
            firePosition_S.position;

        temp.GetComponent<Rigidbody>().velocity =
            firePosition_S.forward * power;


    }
/*
    void fireMField_S()
    {
        GameObject temp = pool.GetMField_S();

        temp.transform.position = firePosition_S.position;

        temp.SendMessage("fly", firePosition_S.forward);
    }*/

    /*
    void fireBar()
    {
        if (barLimit > 0)
        {
            GameObject temp = pool.GetBar();

            temp.transform.position = firePosition_S.position;

            temp.SendMessage("fly", firePosition_S.forward);

            barLimit -= 1;
        }
    }*/
}

