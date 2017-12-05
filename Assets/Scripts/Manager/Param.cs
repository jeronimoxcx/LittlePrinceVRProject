using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Param : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    /* About stage and level */
    //Start
    public float LV_StartTime = 2.0f;
    //Level 1,2,3
    public float LV_showTextTime = 2.0f;
    public float LV_playTime = 3.0f;

    /* Force constants */
    public float RF_PullToRoseC = 1.0f; //like gravity constant

    public float MF_CoulombForceFollowC = 10.0f;
    public float MF_CoulombForceAwayC = 5.0f;

    /* Monopole */
    public float MF_ChargeMono = 10.0f; //magnetic charge (1~10)
    public float MF_FindRange = 50.0f; //range in which magnetic force can reach 

    /* Magnetic bar */
    public float MF_ChargeBar = 10.0f;
    public float barShootingPower = 10.0f;

    /* M_field */
    public float fieldShootingPower = 10.0f;

    /* Enemy */
    public float MF_ChargeEnemy = 10.0f; //magnetic charge (1~10)
    //todo: enemy마다 적당한 값 찾기
    public float MF_StopForcingRange = 1.0f; //(In follow mode) When the distance btw enemy and monopole is in this value, the monopole stop forcing coulomb force. ("attached")

    /* Enemy Generator */
    public float enemyShootingPower = 10.0f;

    public float shootingTimeItvMin = 0.5f;
    public float shootingTimeItvMax = 1.5f;

}
