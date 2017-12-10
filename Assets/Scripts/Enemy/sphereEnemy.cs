using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereEnemy : MonoBehaviour {

    private Param param;
    private Rigidbody rb;

    private Vector3 rose;
    private bool isPulledToRose;

    private float pulledRoseSpeed;
    private Transform objectStuckTo;
    private Vector3 impactPosOffset;
    private Vector3 impactRotOffset;
    private bool isStuck;
    private bool inGage;

    void OnEnable()
    {
        param = GameObject.Find("Param").GetComponent<Param>();
        rose = GameObject.Find("Rose").transform.position;
        rb = gameObject.GetComponent<Rigidbody>();

        isPulledToRose = true;
        pulledRoseSpeed = param.RS_PullToRoseSpeed;
    }

    void Update()
    {
        if (isPulledToRose) pulledToRose(pulledRoseSpeed);
    }

    /* -----------------------------------------------------------------------------------------------------------------------------------------*/
    /* [ROSE] */
    public void pulledToRose(float pullToRoseSpeed)
    {
        Vector3 curDir = gameObject.GetComponent<Rigidbody>().velocity.normalized;
        Vector3 towardDir = (rose - gameObject.transform.position).normalized;
        Vector3 updatedDir = Vector3.Lerp(curDir, towardDir, param.RS_EnemyApprachAngle).normalized;
        gameObject.GetComponent<Rigidbody>().velocity = pulledRoseSpeed * 0.5f * (curDir + updatedDir);
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == gameObject.tag && collision.collider.name.Contains("pw"))
        {
            foreach (Transform child in transform)
            {   
                child.gameObject.AddComponent<SphereCollider>();
                child.gameObject.AddComponent<Rigidbody>().useGravity = false;
                child.gameObject.GetComponent<ReceiveForce>().enabled = true;
            }
        }
    }
}
