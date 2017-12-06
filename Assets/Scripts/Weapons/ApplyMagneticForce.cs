using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ApplyMagneticForce : MonoBehaviour {

    Param param;

    private int magAble = 1; //자력발동 눌렀을 때 한번만 발동되게.
    private bool isExerting = false;
    private Collider[] hitColliders;


    public Slider BarGageSlider;
    public int maxGage = 10;
    private int currentGage = 0;
    private bool inGage = false;
    int countfollow = 0;

    void OnEnable()
    {
        param = GameObject.Find("Param").GetComponent<Param>();
        magAble = 1; 
        isExerting = false;


        //BarGageSlider = GameObject.Find("BarGageSlider").GetComponent<Slider>();
        inGage = false;
    }

    void Update()
    {
        ExertMagneticForce();
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
        //find colliders in the proper range
        hitColliders = Physics.OverlapSphere(gameObject.transform.position, param.MF_FindRange);

        float[] parameters = new float[4];
        parameters[0] = gameObject.transform.position.x;
        parameters[1] = gameObject.transform.position.y;
        parameters[2] = gameObject.transform.position.z;
        parameters[3] = param.MF_ChargeMono;

        for (int i = 0; i < hitColliders.Length; i++)
        {

            if (hitColliders[i].name.Contains("Enemy"))
            {
                

                if (hitColliders[i].tag != gameObject.tag)
                {
                    hitColliders[i].SendMessage("Follow", parameters);

                    if (!inGage)
                    {
                        countfollow++;
                        Debug.Log("number of balls followed" + countfollow);
                    }
                    if (!inGage && currentGage < maxGage)
                    {
                        currentGage++;
                        Debug.Log("current Gage" + currentGage);
                        BarGageSlider.value = currentGage;
                        inGage = true;
                    }
                }
                else if (hitColliders[i].tag == gameObject.tag)
                {
                    hitColliders[i].SendMessage("Away", parameters);
                }


                

            }

        }
    }
    

}
