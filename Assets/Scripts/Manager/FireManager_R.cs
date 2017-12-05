using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager_R : MonoBehaviour
{
    public MemoryPool pool;
    public Transform firePosition_N;
    public GameObject BarMagnet;
    public float power = 20.0f;
    private int monoNLimit = 3;
    private int barLimit = 3;
    private bool up = false;
    private bool down = false;

    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    private Vector3 monoposition;

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
            monoNLimit = 3;
            GameObject[] monoNs;
            monoNs = GameObject.FindGameObjectsWithTag("N");

            int listlen = monoNs.Length;

            for (int i = 0; i < listlen; i++)
            {
                if (monoNs[i].name.Contains("Monopole"))
                {
                    monoposition = monoNs[i].transform.position;
                    monoNs[i].SendMessage("ApplyMagneticField", monoposition);
                }
            }
        }

        if (controller.GetPressDown(gripButton))
            fireBar();

        if (controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {

            if (controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).y > 0.5f && !up)
            {
                up = true;
                firemonoN();
                Debug.Log("up");
            }
            else if (controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).y < -0.5 && !down)
            {
                down = true;
                fireMField_N();
                Debug.Log("down");
            }


        }
        else
        {
            up = false;
            down = false;

        }

    }

    void firemonoN()
    {
        Debug.Log("Fired");

        if (monoNLimit != 0)
        {

            GameObject temp = pool.GetMono_N();

            temp.transform.position =
                firePosition_N.position;

            temp.GetComponent<Rigidbody>().velocity =
                firePosition_N.forward * power;

            monoNLimit -= 1;

            Debug.Log(monoNLimit);
        }
    }

    void fireMField_N()
    {
        GameObject temp = pool.GetMField_N();

        temp.transform.position = firePosition_N.position;

        temp.SendMessage("fly", firePosition_N.forward);
    }


    void fireBar()
    {
        if (barLimit > 0)
        {
            GameObject temp = pool.GetBar();

            temp.transform.position = firePosition_N.position;

            temp.SendMessage("fly", firePosition_N.forward);

            barLimit -= 1;
        }
    }
}

