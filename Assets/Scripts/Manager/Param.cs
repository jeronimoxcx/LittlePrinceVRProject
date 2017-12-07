using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Param : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    /* Control Level 
     * Lv 1
     * [Rose]
     *     - RS_PullToRoseSpeed = 10.0f;
     *     - RS_EnemyApprachAngle = 0.01f;
     * 
     * [Enemy Generator]
     *     - shootingTimeItvMin = 0.5f;
     *     - shootingTimeItvMax = 1.5f;
     *     - numPerOnceMin = 1;
     *     - numPerOnceMin = 3;
     *     
     * [Magnetic Force]
     *     1. Coulomb Force constants 
     *          - MF_CoulombForceFollowC = 100.0f;
     *          - MF_CoulombForceAwayC = 20.0f;
     *     2. Charge (일단 고정)
     *          - MF_ChargeEnemy = 10.0f;
     *          - MF_ChargeMono = 10.0f;
     *          - MF_ChargeBar = 10.0f;
     *     3. Find Range
     *          - MF_FindRange = 5.0f; //F가 25이상일 때
     *          - MF_StopForcingRange = 1.0f;
     *          
     * [Player Weapons]
     *     1. Monopole
     *          - PW_Mono_NumOfEnemyOnce = 5;
     *          
     * 
     * */

    /*------------------------------------------------------------------------------------------------------------------------------------------------------*/
    /* Controll parameters: Pulled to Rose */
    public float RS_PullToRoseSpeed = 10.0f; 
    public float RS_EnemyApprachAngle = 0.01f; // if this value is low, enemies spread more


    /*------------------------------------------------------------------------------------------------------------------------------------------------------*/
    /* Controll parameters: Enemy Generator (Enemy Manager) */
    public float EM_shootingTimeItvMin = 0.5f;
    public float EM_shootingTimeItvMax = 1.5f;
    public int EM_numPerOnceMin = 2;
    public int EM_numPerOnceMax = 5;

    /*------------------------------------------------------------------------------------------------------------------------------------------------------*/
    /* Controll parameters: Magnetic Force */
    //1. Coulomb Force constants
    public float MF_CFfollowC = 1.0f;
    public float MF_CFawayC = 1.0f;

    //2. Charge
    public float MF_ChargeEnemy = 10.0f; //magnetic charge (1~10)
    public float MF_ChargeMono = 10.0f; //magnetic charge (1~10)
    public float MF_ChargeBar = 10.0f;

    //3. Find Range
    public float MF_FindRange = 5.0f; //range in which magnetic force can reach 
    public float MF_StopForcingRange = 1.0f; //(In follow mode) When the distance btw enemy and monopole is in this value, the monopole stop forcing coulomb force. ("attached")

    /*------------------------------------------------------------------------------------------------------------------------------------------------------*/
    /* Controll parameters: Player Weapons */
    public int PW_Mono_NumOfEnemyOnce = 5;

    public float PW_BarShootingPower = 10.0f;

    public float PW_FieldShootingPower = 10.0f;
    public float PW_FieldSlownFactor = 0.1f;
    public float PW_FieldFastenFactor = 1.1f;



    /*------------------------------------------------------------------------------------------------------------------------------------------------------*/
    /* About stage and level */
    //Start
    public float LV_StartTime = 2.0f;
    //Level 1,2,3 (Common)
    public float LV_showTextTime = 2.0f;
    public float LV_playTime = 3.0f;
    //Level3
    public float LV3_waitInPoseTimeMin = 1.0f;
    public float LV3_waitInPoseTimeMax = 3.0f;
    public int LV3_teleportTotNum = 10;

}
