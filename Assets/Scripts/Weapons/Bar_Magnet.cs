using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar_Magnet : MonoBehaviour {

    public GameObject bar_N;
    public GameObject bar_S;
    public int M_force = 5;
    //public Transform cameraTransform;

    private Vector3 flydirection;
    private Vector3 velocity;
    private int power = 10;
    private float disabletime;
    private int disable_active = 0;
    private Collider[] hitColliders;


    // Use this for initialization
    void Start () {
        
            
    }
	
	// Update is called once per frame
	void Update () {
        if (disable_active==0)
        {
            disabletime = Time.time + 10;
            disable_active = 1;
        }

        hitColliders = Physics.OverlapSphere(transform.position, M_force);


        int i = 0;
        while(i < hitColliders.Length)
        {
            if (hitColliders[i].name.Contains("Enemy"))
            {
                if (hitColliders[i].tag == "N")
                    hitColliders[i].SendMessage("Follow", bar_S);

                else if (hitColliders[i].tag == "S")
                    hitColliders[i].SendMessage("Follow", bar_N);
            }
            i++;
        }

        transform.Rotate(Vector3.up);

        if (disabletime < Time.time && disable_active == 1)
        {
            while(i < hitColliders.Length)
            {
                hitColliders[i].SendMessage("disable_self");
            }
            gameObject.SetActive(false);
            disable_active = 0;            
        }
        else
        {
            transform.position += velocity * Time.deltaTime;
        }

    }

    void fly (Vector3 direction)
    {
        flydirection = direction;
        velocity = flydirection * power;
    }
}
