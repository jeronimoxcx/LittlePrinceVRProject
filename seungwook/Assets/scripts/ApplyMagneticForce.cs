using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyMagneticForce : MonoBehaviour {

    public int M_force;
    public bool is_N;

    private int magAble = 1;
    private float disabletime;
    private int disable_active = 0;
    private Collider[] hitColliders;

    // Use this for initialization
    /*void Start()
    {
        hitColliders = Physics.OverlapSphere(transform.position, M_force);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].tag == "N" || hitColliders[i].tag == "S")
            {
                Debug.Log(hitColliders[i]);
                //hitColliders[i].SendMessage("Follow", gameObject);
                hitColliders[i].SendMessage("Print");
            }
            i++;
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E) && gameObject.tag=="S") || (Input.GetButtonDown("Fire2") && gameObject.tag == "N"))
        {
            if (magAble == 1)
            {
                ApplyMagneticField(transform.position, M_force);
                magAble = 0;
            }
        }
        if (disabletime < Time.time && disable_active == 1)
            gameObject.SetActive(false);

    }

    void ApplyMagneticField(Vector3 center, float radius)
    {
        disabletime = Time.time + 5.0F;
        disable_active = 1;

        hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;
        while (i < hitColliders.Length)
        {
            //Debug.Log(hitColliders[i].tag);
            if (hitColliders[i].tag == "N" || hitColliders[i].tag == "S")
            {
                if (hitColliders[i].tag != gameObject.tag)
                {
                    hitColliders[i].SendMessage("Follow", gameObject);
                }
                if (hitColliders[i].tag == gameObject.tag)
                {
                    hitColliders[i].SendMessage("Away", gameObject);
                }
            }
            i++;
        }
    }
}
