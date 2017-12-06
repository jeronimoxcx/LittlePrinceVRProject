using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LVM_LV3 : MonoBehaviour {

    private Param param;
    public GameObject bossSpaceShip;
    public GameObject boss;

    public Text text;

    //Space Ship animation
    float spaceShipAppearTime = 3.0f;
    Vector3 spaceShipStartPose;
    Vector3 spaceShipTargetPose;   
    Vector3 spaceShipVelocity;

    //Boss animation 
    float bossAppearTime = 1.0f;

    private float timer = 0.0f;
    private int onceFlag = 1;

    private void Start()
    {
        param = GameObject.Find("Param").GetComponent<Param>();
        boss.SetActive(false);

        //For space ship animation
        spaceShipStartPose = new Vector3(-6.7f, 25.6f, 70.4f);
        spaceShipTargetPose = new Vector3(-6.7f, 15.85f, 35.51f);
        spaceShipVelocity = (spaceShipTargetPose - spaceShipStartPose) / spaceShipAppearTime;
    }

    void Update()
    {

        if (timer < param.LV_showTextTime)
        {
            timer += Time.deltaTime;
            text.text = ("Level3");
        } // Appear space ship
        else if(timer < param.LV_showTextTime + spaceShipAppearTime)
        {
            timer += Time.deltaTime;
            text.text = ("");
            bossSpaceShip.GetComponent<Rigidbody>().velocity = spaceShipVelocity;

        }
        else if (timer < param.LV_showTextTime + spaceShipAppearTime+0.5)
        {
            timer += Time.deltaTime;
            bossSpaceShip.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
        // Appear boss
        else if (timer < param.LV_showTextTime + spaceShipAppearTime+0.5 + bossAppearTime)
        {
            timer += Time.deltaTime;
            boss.SetActive(true);
        }
        else if (timer < param.LV_showTextTime + spaceShipAppearTime + param.LV_playTime)
        {
            timer += Time.deltaTime;

            if (onceFlag == 1)
            {
                onceFlag = 0;
                boss.SendMessage("StartWorking");
            }
        }
        else
        {
            SceneManager.LoadScene("Finish");
        }
    }
}
