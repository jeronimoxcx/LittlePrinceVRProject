using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarMagnet : MonoBehaviour {

    private Param param;

    public GameObject bar_N;
    public GameObject bar_S;

    private Vector3 flydirection;
    private Vector3 velocity;
    private Collider[] hitColliders;

    private void OnEnable()
    {
        param = GameObject.Find("Param").GetComponent<Param>();
    }

    void Update()
    {
        ExertMagneticForce();

        transform.Rotate(Vector3.up);
        transform.position += velocity * Time.deltaTime;

    }

    void ExertMagneticForce()
    {
        //find colliders in the proper range
        hitColliders = Physics.OverlapSphere(gameObject.transform.position, param.MF_FindRange);

        //barS, barN으로 바꾸어주어야함
        float[] parametersBarS = new float[6];
        parametersBarS[0] = bar_S.transform.position.x;
        parametersBarS[1] = bar_S.transform.position.y;
        parametersBarS[2] = bar_S.transform.position.z;
        parametersBarS[3] = param.MF_ChargeBar;
        parametersBarS[4] = param.barMagnetIndex;
        parametersBarS[5] = gameObject.GetInstanceID();

        float[] parametersBarN = new float[6];
        parametersBarN[0] = bar_N.transform.position.x;
        parametersBarN[1] = bar_N.transform.position.y;
        parametersBarN[2] = bar_N.transform.position.z;
        parametersBarN[3] = param.MF_ChargeBar;
        parametersBarN[4] = param.barMagnetIndex;
        parametersBarN[5] = gameObject.GetInstanceID();

        for (int i = 0; i < hitColliders.Length; i++)
        {

            if (hitColliders[i].name.Contains("Enemy"))
            {
                if (hitColliders[i].tag == "N")
                    hitColliders[i].SendMessage("Follow", parametersBarS);

                else if (hitColliders[i].tag == "S")
                    hitColliders[i].SendMessage("Follow", parametersBarN);
            }

        }
    }


    void fly(Vector3 direction)
    {
        flydirection = direction;
        velocity = flydirection * param.PW_BarShootingPower;
    }
}
