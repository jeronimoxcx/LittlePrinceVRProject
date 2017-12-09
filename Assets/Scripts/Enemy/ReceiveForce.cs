using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveForce : MonoBehaviour {

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
        isStuck = false;

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
        gameObject.GetComponent<Rigidbody>().velocity = pulledRoseSpeed * (curDir+updatedDir);
    }

    /* -----------------------------------------------------------------------------------------------------------------------------------------*/
    /* [Magnetid Force- Monopole, magnetic bar] */
    public void Follow(float[] parameters)
    {
        isPulledToRose = false;
        Vector3 target = new Vector3(parameters[0], parameters[1], parameters[2]);
        Vector3 r = target - gameObject.transform.position;
        /*
        if (!inGage && parameters[4] > 0)
        {
            if (comboSlider.currentGage < 10)
            {
                comboSlider.currentGage++;
                inGage = true;
            }
        }else
        {
            Debug.Log("I'm not counting");
        }
        */
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
        isStuck = true;
    }

    public void StuckToPW(float[] parameters)
    {
        if(isStuck)
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

    /* -----------------------------------------------------------------------------------------------------------------------------------------*/
    /* For the flat magnetic field */
    void Slowdown()
    {
        pulledRoseSpeed = pulledRoseSpeed * param.PW_FieldSlownFactor;
    }

    void Fastenup()
    {
        pulledRoseSpeed = pulledRoseSpeed * param.PW_FieldFastenFactor;
    }


}
