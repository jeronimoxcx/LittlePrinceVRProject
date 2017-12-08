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
    private int barLimit = 40;
    private bool up = false;
    private bool down = false;

    private float shootInterval = 0.0f;
    private bool shootAction = false;

    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    private Vector3 monoposition;

    public SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    public SteamVR_TrackedObject trackedObj;

    public bool signal;
    //public bool signal_L;
    //public GameObject controllerLeft;

    // Use this for initialization
    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
       // controllerLeft = GameObject.Find("Controller (left)");
    }

    // Update is called once per frame
    void Update()
    {
        signal = controller.GetPress(gripButton);
       // signal_L = controllerLeft.GetComponent<FireManager_L>().signal;
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
                firemonoN();
                GameObject monoN;
                monoN = GameObject.FindWithTag("N");
                if (monoN != null) {
                    Debug.Log("monoN name" + monoN.name);
                    if (monoN.name.Contains("Monopole"))
                    {
                        monoposition = monoN.transform.position;
                        monoN.SendMessage("ApplyMagneticField", monoposition);
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



            /*
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
            }*/
        }
        
        /*
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
        */
    }

    void firemonoN()
    {
        Debug.Log("Fired");

        

        GameObject temp = pool.GetMono_N();

        temp.transform.position =
            firePosition_N.position;

        temp.GetComponent<Rigidbody>().velocity =
            firePosition_N.forward * power;

            
    }
    /*
    void fireMField_N()
    {
        GameObject temp = pool.GetMField_N();

        temp.transform.position = firePosition_N.position;

        temp.SendMessage("fly", firePosition_N.forward);
    }*/

    /*
    void fireBar()
    {
        if (barLimit > 0)
        {
            GameObject temp = pool.GetBar();

            temp.transform.position = firePosition_N.position;

            temp.SendMessage("fly", firePosition_N.forward);

            barLimit -= 1;
        }
    }*/
}

