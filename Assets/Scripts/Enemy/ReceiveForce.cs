using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveForce : MonoBehaviour {

    private Param param;
    private Rigidbody rb;

    private Vector3 rose;
    private Vector3 modirose;
    private bool isPulledToRose;

    void OnEnable()
    {
        param = GameObject.Find("Param").GetComponent<Param>();
        rose = GameObject.Find("Rose").transform.position;
        rose.z += 1;
        modirose = rose;
        modirose.z += 2;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isPulledToRose) pulledToRose();
    }

    /* Force related to rose */
    public void pulledToRose()
    {
        Vector3 r = rose - gameObject.transform.position;
        Vector3 modir = modirose - gameObject.transform.position;
        Vector3 force;

        if (gameObject.transform.position.z > 20)
        {
            force = param.RF_PullToRoseC * modir.normalized;
            rb.AddForce(force);
        }
        else if (r.magnitude > 8)
        {
            force = (param.RF_PullToRoseC + Mathf.Pow(param.RF_PullToRoseC, 3) / Mathf.Pow(modir.magnitude, 1)) * modir.normalized;
            rb.AddForce(force);
        }
        else
        {
            rb.velocity = Mathf.Pow(param.RF_PullToRoseC,1.5f) * r.normalized;
        }
    }

    public void setIsPulledRoseTrue()
    {
        isPulledToRose = true;
    }


    /* Force related to monopole */
    public void Follow(float[] parameters)
    {
        isPulledToRose = false;
        Vector3 target = new Vector3(parameters[0], parameters[1], parameters[2]);
        Vector3 r = target - gameObject.transform.position;

        //Coulomb force
        if (r.magnitude > param.MF_StopForcingRange)
        {
            rb.AddForce(param.MF_CoulombForceFollowC * (param.MF_ChargeEnemy * parameters[3] * r / Mathf.Pow(r.magnitude, 3)));
        }
        //When two magnets are very close: attach 
        else rb.velocity = 10 * r.normalized;
    }

    public void Away(float[] parameters)
    {
        Vector3 target = new Vector3(parameters[0], parameters[1], parameters[2]);
        Vector3 r = gameObject.transform.position - target;

        rb.AddForce(param.MF_CoulombForceAwayC * param.MF_ChargeEnemy * parameters[3] * r / Mathf.Pow(r.magnitude, 3));
    }

    /* For the flat magnetic field */
    void Slowdown()
    {
        Debug.Log("slowdown");
        Debug.Log("before:"+rb.velocity);
        rb.velocity *= 0.1F;
        Debug.Log("after:"+rb.velocity);
        //Debug.Log("Message Received");
    }

    void Fastenup()
    {
        rb.velocity *= 1.5F;
    }


}
