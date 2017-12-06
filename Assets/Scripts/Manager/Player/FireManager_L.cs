﻿﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager_L : MonoBehaviour
{
    public MemoryPool pool;
    public Transform firePosition_S;
    public GameObject BarMagnet;
    public float power = 20.0f;
    private int monoSLimit = 3;
    private int barLimit = 3;
    private bool up = false;
    private bool down = false;

    private Vector3 monoposition;

    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    public SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    public SteamVR_TrackedObject trackedObj;

    public bool signal;

    // Use this for initialization
    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update()
    {
        signal = controller.GetPressDown(triggerButton);
        if (controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }


        if (controller.GetPressDown(triggerButton))
        {
            monoSLimit = 3;
            GameObject[] monoSs;
            monoSs = GameObject.FindGameObjectsWithTag("S");

            int listlen = monoSs.Length;

            for (int i = 0; i < listlen; i++)
            {
                if (monoSs[i].name.Contains("Monopole"))
                {
                    monoposition = monoSs[i].transform.position;
                    monoSs[i].SendMessage("ApplyMagneticField", monoposition);
                }
            }
            Debug.Log("triggered");
        }

        if (controller.GetPressDown(gripButton))
            fireBar();

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

        }

    }

    void firemonoS()
    {
        Debug.Log("Fired");
        
        if (monoSLimit != 0)
        {

            GameObject temp = pool.GetMono_S();

            temp.transform.position =
                firePosition_S.position;

            temp.GetComponent<Rigidbody>().velocity =
                firePosition_S.forward * power;

            monoSLimit -= 1;

            Debug.Log(monoSLimit);
        }
    }

    void fireMField_S()
    {
        GameObject temp = pool.GetMField_S();

        temp.transform.position = firePosition_S.position;

        temp.SendMessage("fly", firePosition_S.forward);
    }


    void fireBar()
    {
        if (barLimit > 0)
        {
            GameObject temp = pool.GetBar();

            temp.transform.position = firePosition_S.position;

            temp.SendMessage("fly", firePosition_S.forward);

            barLimit -= 1;
        }
    }
}
