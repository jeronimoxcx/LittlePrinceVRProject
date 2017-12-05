using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulledToRose : MonoBehaviour {

    Param param;
    Vector3 rose;
    Vector3 modirose;
    Rigidbody rb;


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
        Vector3 r = rose - gameObject.transform.position;
        Vector3 modir = modirose - gameObject.transform.position;
        Vector3 force;

        if (gameObject.transform.position.z > 20)
        {
            force = param.RF_PullToRoseC * modir.normalized;
            rb.AddForce(force);
            //Debug.Log("r:" + r.magnitude);
            //Debug.Log("Force:" + force.magnitude);
        }
        else if (r.magnitude > 8)
        {
            force = (param.RF_PullToRoseC + Mathf.Pow(param.RF_PullToRoseC, 4) / Mathf.Pow(modir.magnitude, 2)) * modir.normalized;
            rb.AddForce(force);
            //Debug.Log("r:" + r.magnitude);
            //Debug.Log("Force:" + force.magnitude);

        }
        else {
            force = Mathf.Pow(param.RF_PullToRoseC, 3) * r.normalized;
            rb.AddForce(force);
            //Debug.Log("r:" + r.magnitude);
            //Debug.Log("Force:" + force.magnitude);
            //rb.AddForce(param.RF_PullToRoseC / Mathf.Pow(r.magnitude, 2) * r);
            //rb.AddForce((param.RF_PullToRoseC + Mathf.Pow(param.RF_PullToRoseC, 2) / Mathf.Pow(r.magnitude, 2)) * r.normalized);
        }
        //rb.AddForce( param.pullToRoseC * r /Mathf.Pow(r.magnitude, 2) );
        //Debug.Log("to rose: "+ (param.pullToRoseC * r / Mathf.Pow(r.magnitude, 2)));
    }
}
