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
        gameObject.GetComponent<Rigidbody>().velocity = pulledRoseSpeed * 0.75f* towardDir;
    }


    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OncollisionEnter");
        
        if (collision.collider.tag == gameObject.tag && collision.collider.name.Contains("Monopole"))
        {
            foreach (Transform child in transform)
            {   
                child.gameObject.AddComponent<SphereCollider>();
                child.gameObject.AddComponent<Rigidbody>().useGravity = false;
                
                child.gameObject.GetComponent<ReceiveForce>().enabled = true;
            }
        }
    }


    public void Follow(float[] parameters)
    {
        if (parameters[4] == param.barMagnetIndex)
        {
            receiveForce(parameters);
        }
    }

    private void receiveForce(float[] parameters)
    {
        isPulledToRose = false;
        Vector3 target = new Vector3(parameters[0], parameters[1], parameters[2]);
        Vector3 r = target - gameObject.transform.position;

        if (!inGage && parameters[4] == 1)
        {
            Debug.Log("maxGage " + comboSlider.maxGage);
            if (comboSlider.currentGage < comboSlider.maxGage)
            {

                comboSlider.currentGage++;
                inGage = true;
                Debug.Log("currentGage " + comboSlider.currentGage);
            }
        }
        else
        {
            //Debug.Log("I'm not counting");
        }

        //Coulomb force
        if (r.magnitude > param.MF_StopForcingRange)
        {
            rb.AddForce(param.MF_CFfollowC * (param.MF_ChargeEnemy * parameters[3] * r / Mathf.Pow(r.magnitude, 3)));
        }
        //When two magnets are very close: attach 
        rb.velocity = 10 * r.normalized;
    }

    public void Away(float[] parameters) { return; }
    public void StuckToPW(float[] parameters) { return; }

}
