using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveForce : MonoBehaviour {


    Param param;
    public Rigidbody rb;

    void Start()
    {
        param = GameObject.Find("Param").GetComponent<Param>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {

    }

    public void Follow(float[] parameters)
    {
        Vector3 r = new Vector3(
            parameters[0] - gameObject.transform.position.x,
            parameters[1] - gameObject.transform.position.y,
            parameters[2] - gameObject.transform.position.z);

        if (r.magnitude > param.MF_StopForcingRange)
        {
            rb.AddForce(param.MF_CoulombForceC * (param.MF_ChargeEnemy * parameters[3] * r / Mathf.Pow(r.magnitude, 3)));
            //Debug.Log("magnetic force: " + (param.MF_CoulombForceC * (param.MF_ChargeEnemy * parameters[3] * r / Mathf.Pow(r.magnitude, 3)).magnitude));
        }
        else rb.velocity = 10*r;
    }

    public void Away(float[] parameters)
    {
        Vector3 r = new Vector3(
            gameObject.transform.position.x - parameters[0],
            gameObject.transform.position.y - parameters[1],
            gameObject.transform.position.z - parameters[2]);

        rb.AddForce(param.MF_CoulombForceC * param.MF_ChargeEnemy * parameters[3] * r / Mathf.Pow(r.magnitude, 3));

    }
}
