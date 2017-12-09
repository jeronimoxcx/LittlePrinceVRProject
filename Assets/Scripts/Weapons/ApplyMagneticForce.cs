using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ApplyMagneticForce : MonoBehaviour {

    Param param;

    private int magAble = 1; //자력발동 눌렀을 때 한번만 발동되게.
    private bool isExerting = false;
    private Collider[] hitColliders;
    private int enemyCounter = 0;



    void OnEnable()
    {
        param = GameObject.Find("Param").GetComponent<Param>();
        magAble = 1; 
        isExerting = false;
        enemyCounter = 0;

        //BarGageSlider = GameObject.Find("BarGageSlider").GetComponent<Slider>();
        //inGage = false;

    }

    void Update()
    {
        ExertMagneticForce();
        KeepStuck();
        //if (isExerting)
        //    ExertMagneticForce();
    }

    void ApplyMagneticField(Vector3 center)
    {
        //return when this monopole is already turned on
        if (magAble == 0) return;

        //else
        magAble = 0;
        isExerting = true;
    }

    void ExertMagneticForce()
    {
        if (enemyCounter < param.PW_Mono_NumOfEnemyOnce)
        {
            //find colliders in the proper range
            hitColliders = Physics.OverlapSphere(gameObject.transform.position, param.MF_FindRange);

            for (int i = 0; i < hitColliders.Length; i++)
            {
                if (hitColliders[i].name.Contains("Enemy"))
                {
                    float[] parameters = setParams();

                    if (hitColliders[i].tag != gameObject.tag)
                    {
                        hitColliders[i].SendMessage("Follow", parameters);

                       
                    }
                    else if (hitColliders[i].tag == gameObject.tag)
                    {   
                        hitColliders[i].SendMessage("Away", parameters);
                    }

                }

            }

        }
    }

    private void KeepStuck()
    {
        hitColliders = Physics.OverlapSphere(gameObject.transform.position, param.MF_FindRange/2);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].name.Contains("Enemy")) { 
                float[] parameters = setParams();
                if (hitColliders[i].tag != gameObject.tag)
                {
                    hitColliders[i].SendMessage("StuckToPW", parameters);
                }
            }
        }
    }

    private float[] setParams()
    {
        float[] parameters = new float[5];
        parameters[0] = gameObject.transform.position.x;
        parameters[1] = gameObject.transform.position.y;
        parameters[2] = gameObject.transform.position.z;
        parameters[3] = param.MF_ChargeMono;
        parameters[4] = param.monopoleIndex;

        return parameters;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name.Contains("Enemy"))
            enemyCounter++;
    }
}
