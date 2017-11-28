using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyMagneticForce : MonoBehaviour {

    public int M_force;

    private int M_radius = 15;
    private int magAble = 1;
    private float disabletime;
    private int disable_active = 0;
    private Collider[] hitColliders;


    public GameObject controllerRight;
    public GameObject controllerLeft;
    public bool signal_R;
    public bool signal_L;
    // Use this for initialization
    void Start()
    {
        controllerRight = GameObject.Find("Controller (right)");
        controllerLeft = GameObject.Find("Controller (left)");
    }

    // Update is called once per frame
    void Update()
    {
        signal_R = controllerRight.GetComponent<FireManager_R>().signal;
        signal_L = controllerLeft.GetComponent<FireManager_L>().signal;
        if ((signal_L && gameObject.tag=="S") || (signal_R && gameObject.tag == "N"))
        {
            if (magAble == 1)
            {
                ApplyMagneticField(transform.position, M_radius);
                magAble = 0;
            }
        }
        if (disabletime < Time.time && disable_active == 1)
        {
            gameObject.SetActive(false);
            disable_active = 0;
            magAble = 1;
        }

    }

    void ApplyMagneticField(Vector3 center, float radius)
    {
        disabletime = Time.time + 3.0F;
        disable_active = 1;

        hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;
        int mForce = M_force;
        while (i < hitColliders.Length)
        {
            //Debug.Log(hitColliders[i].tag);
            //if (hitColliders[i].tag == "N" || hitColliders[i].tag == "S")
            if (hitColliders[i].name.Contains("Enemy"))
            {
                if (hitColliders[i].tag != gameObject.tag)
                {
                    mForce -= hitColliders[i].GetComponent<RecieveMagneticForce>().M_force;
                    if (mForce >= 0)
                    {
                        hitColliders[i].SendMessage("Follow", gameObject);
                    }
                }
                if (hitColliders[i].tag == gameObject.tag)
                    hitColliders[i].SendMessage("Away", gameObject);
            }
            i++;
        }
    }
}
