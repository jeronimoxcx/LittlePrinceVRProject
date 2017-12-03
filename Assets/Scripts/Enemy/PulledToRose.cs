using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulledToRose : MonoBehaviour {

    Param param;
    Vector3 rose;
    Rigidbody rb;


    void Start()
    {
        param = GameObject.Find("Param").GetComponent<Param>();
        rose = GameObject.Find("Rose").transform.position;
        rose.z += 2.0f;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {   
        Vector3 r = rose - gameObject.transform.position;

        if (gameObject.transform.position.z > 20)
        {
            rb.AddForce(param.RF_PullToRoseC * r.normalized);
        }
        else if (r.magnitude > 3)
        {
            rb.AddForce((param.RF_PullToRoseC + Mathf.Pow(param.RF_PullToRoseC, 4) / Mathf.Pow(r.magnitude, 2)) * r.normalized);
        }else {
            
            rb.AddForce((param.RF_PullToRoseC + Mathf.Pow(param.RF_PullToRoseC, 2) / Mathf.Pow(r.magnitude, 2)) * r.normalized);
        }
        //rb.AddForce( param.pullToRoseC * r /Mathf.Pow(r.magnitude, 2) );
        //Debug.Log("to rose: "+ (param.pullToRoseC * r / Mathf.Pow(r.magnitude, 2)));
    }
}
