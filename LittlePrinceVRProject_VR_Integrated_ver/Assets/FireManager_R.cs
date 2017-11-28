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


    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;


    // Use this for initialization
    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }


        if (controller.GetPressDown(triggerButton))
        {
            monoNLimit = 3;
            Debug.Log(monoNLimit+"triggered(right)");
        }

        if (controller.GetPressDown(gripButton))
            fireBar();

        if (controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {

            if (controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).y > 0.5f && !up)
            {
                up = true;
                firemonoN();
                Debug.Log("Dpad Up");
            }
            else if (controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).y < -0.5 && !down)
            {
                down = true;
                fireMField_N();
                Debug.Log("Dpad Down");
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

