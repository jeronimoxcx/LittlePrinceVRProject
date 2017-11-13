using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecieveMagneticForce : MonoBehaviour {

    private float disabletime;
    private int disable_active = 0;
    private int followmode = 0;
    private GameObject followobj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (disabletime < Time.time && disable_active==1)
            gameObject.SetActive(false);
        if (followmode==1)
        {
            gameObject.GetComponent<Rigidbody>().velocity = (followobj.transform.position - gameObject.transform.position) + (followobj.GetComponent<Rigidbody>().velocity * 0.5F);
            if (!followobj.activeSelf)
                gameObject.SetActive(false);
        }
    }

    void Follow(GameObject Attack)
    {
        disabletime = Time.time + 3.0F;
        disable_active = 1;
        followmode = 1;
        followobj = Attack;
        //Debug.Log("Message Received");
        float starttime = Time.time;
    }

    void Away(GameObject Attack)
    {
        gameObject.GetComponent<Rigidbody>().velocity = (gameObject.transform.position - Attack.transform.position);

    }

    void Print()
    {
        Debug.Log("Message Received");
    }

}
