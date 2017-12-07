﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

    Param param;
    private Vector3 rosePose;
    private Vector3 bossInitialPose;
    private Vector3 pathPerOnce; 

    private bool isWorking = false;

    private float timer = 0.0f;
    private float waitTime = 1.0f;

    //About Halo
    GameObject haloRed;
    GameObject haloBlue;
    GameObject haloPurple;
    private const int MODE_RED = 1;
    private const int MODE_BLUE = 2;
    private const int MODE_PURPLE = 3;

    private int curMODE;

    void Start()
    {
        param = GameObject.Find("Param").GetComponent<Param>();
        rosePose = GameObject.Find("Rose").transform.position;
        bossInitialPose = gameObject.transform.position;
        pathPerOnce = (rosePose - bossInitialPose)/param.LV3_teleportTotNum;
        haloRed = transform.Find("Halo_Red").gameObject;
        haloBlue = transform.Find("Halo_Blue").gameObject;
        haloPurple = transform.Find("Halo_Purple").gameObject;

        SetMode();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (curMODE == MODE_RED)
        {
            if (collision.collider.tag == "S")
                Debug.Log("Hit boss in MODE_RED! It should be damaged");
            if (collision.collider.tag == "N")
                oneStepBack();

        } else if (curMODE == MODE_BLUE)
        {
            if (collision.collider.tag == "N")
                Debug.Log("Hit boss in MODE_BLUE! It should be damaged");
            if (collision.collider.tag == "S")
                oneStepBack();

        } else if (curMODE == MODE_PURPLE)
        {
            Debug.Log("Hit boss in MODE_PURPLE! It should be damaged");
        } else
            Debug.Log("No mode in boss");       
    }

    void Update () {
        if (isWorking)
        {
            if (timer > waitTime)
            {
                timer = 0.0f;
                waitTime = Random.Range(param.LV3_waitInPoseTimeMin, param.LV3_waitInPoseTimeMax);

                Teleport();
                SetMode();
            }
            else //attack
            {   
                timer += Time.deltaTime;
            }
                
        }
    }

    public void StartWorking()
    {
        isWorking = true;
    }

    public void Teleport()
    {
        float randX = Random.Range(-10.0f, 10.0f);
        float randY = Random.Range(10.0f, 20.0f);
        gameObject.transform.position = new Vector3(randX, randY, gameObject.transform.position.z+ pathPerOnce.z);
        gameObject.transform.LookAt(rosePose);
    }

    public void oneStepBack()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - pathPerOnce.z);
        gameObject.transform.LookAt(rosePose);
    }

    public void SetMode()
    {
        curMODE = Random.Range(1, 4);
        if (curMODE == MODE_RED)
        {
            haloRed.SetActive(true);
            haloBlue.SetActive(false);
            haloPurple.SetActive(false);
        }
        else if (curMODE == MODE_BLUE)
        {
            haloRed.SetActive(false);
            haloBlue.SetActive(true);
            haloPurple.SetActive(false);
        }
        else if (curMODE == MODE_PURPLE)
        {
            haloRed.SetActive(false);
            haloBlue.SetActive(false);
            haloPurple.SetActive(true);
        }
        else
            Debug.Log("No mode in Boss");
    }

}