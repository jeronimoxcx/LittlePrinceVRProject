﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_ReceiveForce : MonoBehaviour {

    private Param param;
    private Rigidbody rb;

    private Vector3 rose;
    private bool isPulledToRose;

    private float pulledRoseSpeed;
    private bool isStuck;
    private bool inGage;

    void OnEnable()
    {
        param = GameObject.Find("Param").GetComponent<Param>();
        rose = GameObject.Find("Rose").transform.position;
        rb = gameObject.GetComponent<Rigidbody>();

        isPulledToRose = true;
        pulledRoseSpeed = param.RS_PullToRoseSpeed;
        isStuck = false;
        numOfMono = 0;
        monoList = new ArrayList();

        inGage = false;
        //barGageSlider = GameObject.Find("BarGageSlider").GetComponent<Slider>();

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
        // gameObject.GetComponent<Rigidbody>().velocity = pulledRoseSpeed * (curDir + updatedDir);
        gameObject.GetComponent<Rigidbody>().velocity = pulledRoseSpeed * (towardDir);
    }

    /* -----------------------------------------------------------------------------------------------------------------------------------------*/
    /* [Magnetid Force- Monopole, magnetic bar] */

    int numOfMono = 0;
    ArrayList monoList; 

    public void Follow(float[] parameters)
    {
        if(parameters[4] == param.barMagnetIndex)
        {
            receiveForce(parameters);
        }
        else
        {
            if (!monoList.Contains(parameters[5]))
            {
                    numOfMono++;
                    monoList.Add(parameters[5]);
                    //Debug.Log("numOfMono:" + numOfMono);
                }
                if(numOfMono>3){
                    receiveForce(parameters);
                }
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

    private void OnCollisionEnter(Collision collision)
    {   

        if(numOfMono>3) 
            isStuck = true;
    }

    public void StuckToPW(float[] parameters)
    {
        if (isStuck)
        {
            Vector3 target = new Vector3(parameters[0], parameters[1], parameters[2]);
            Vector3 r = target - gameObject.transform.position;
            rb.velocity = 15 * r.normalized;
        }
    }

    public void Away(float[] parameters)
    {
        Vector3 target = new Vector3(parameters[0], parameters[1], parameters[2]);
        Vector3 r = gameObject.transform.position - target;

        rb.AddForce(param.MF_CFawayC * param.MF_ChargeEnemy * parameters[3] * r / Mathf.Pow(r.magnitude, 3));
    }

}
