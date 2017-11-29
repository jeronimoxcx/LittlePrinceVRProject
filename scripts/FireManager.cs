using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour {
    public Transform cameraTransform;
    public MemoryPool pool;
    public Transform firePosition_Mono_N;
    public Transform firePosition_Mono_S;
    public Transform firePosition_Bar;
    public GameObject BarMagnet;
    public float power = 20.0f;
    private int monoNLimit = 3;
    private int monoSLimit = 3;
    private int barLimit = 3;

    private Vector3 monoposition;
    

	void Update () {
        if (Input.GetButtonDown("Fire1"))
            firemonoN();
        
        if (Input.GetButtonDown("Fire2"))
        {
            monoNLimit = 3;
            GameObject[] monoNs;
            monoNs = GameObject.FindGameObjectsWithTag("N");

            int listlen = monoNs.Length;

            for (int i=0; i<listlen; i++)
            {
                if (monoNs[i].name.Contains("Monopole"))
                {
                    monoposition = monoNs[i].transform.position;
                    monoNs[i].SendMessage("ApplyMagneticField",monoposition);
                }
            }
        }

        
        if (Input.GetKeyDown(KeyCode.Q))
            firemonoS();
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            monoNLimit = 3;
            GameObject[] monoSs;
            monoSs = GameObject.FindGameObjectsWithTag("S");

            int listlen = monoSs.Length;

            for (int i = 0; i < listlen; i++)
            {
                if (monoSs[i].name.Contains("Monopole"))
                {
                    monoposition = monoSs[i].transform.position;
                    monoSs[i].SendMessage("ApplyMagneticField", monoposition);
                }
            }
        }

        if (Input.GetButtonDown("Jump"))
            fireBar();

        if (Input.GetKeyDown(KeyCode.Z))
            fireMField_N();

        if (Input.GetKeyDown(KeyCode.C))
            fireMField_S();
        
    }

    void firemonoN()
    {
        if (monoNLimit != 0)
        {
            
            GameObject temp = pool.GetMono_N();

            temp.transform.position =
                firePosition_Mono_N.position;

            temp.GetComponent<Rigidbody>().velocity =
                cameraTransform.forward * power;

            monoNLimit -= 1;
        }
    }

    void firemonoS()
    {
        if (monoSLimit != 0)
        {
            GameObject temp = pool.GetMono_S();

            temp.transform.position =
                firePosition_Mono_S.position;

            temp.GetComponent<Rigidbody>().velocity =
                cameraTransform.forward * power;

            monoSLimit -= 1;
        }
    }

    void fireBar()
    {
        if (barLimit > 0)
        {
            GameObject temp = pool.GetBar();

            temp.transform.position = firePosition_Bar.position;

            temp.SendMessage("fly", cameraTransform.forward);

            barLimit -= 1;
        }
    }

    void fireMField_N()
    {
        GameObject temp = pool.GetMField_N();

        temp.transform.position = firePosition_Bar.position;

        temp.SendMessage("fly", cameraTransform.forward);
        
    }

    void fireMField_S()
    {
        GameObject temp = pool.GetMField_S();

        temp.transform.position = firePosition_Bar.position;

        temp.SendMessage("fly", cameraTransform.forward);
    }


}
