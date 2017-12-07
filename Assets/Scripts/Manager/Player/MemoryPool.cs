using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPool : MonoBehaviour {
    public GameObject Mono_N;
    public GameObject Mono_S;
    public GameObject M_Field_N;
    public GameObject M_Field_S;
    public GameObject Bar_Mag;
    public int poolSize = 50;
    private int barLimit = 40;

    GameObject[] Mono_N_Pool;
    GameObject[] Mono_S_Pool;
    GameObject[] M_Field_N_Pool;
    GameObject[] M_Field_S_Pool;
    GameObject[] Bar_Pool;

    // Use this for initialization
    void Start () {
        Mono_N_Pool = new GameObject[poolSize];
        Mono_S_Pool = new GameObject[poolSize];
        M_Field_N_Pool = new GameObject[poolSize];
        M_Field_S_Pool = new GameObject[poolSize];

        Bar_Pool = new GameObject[barLimit];
        for (int i = 0; i<poolSize; i++)
        {
            Mono_N_Pool[i] = (GameObject)Instantiate(Mono_N);
            Mono_N_Pool[i].SetActive(false);
            Mono_S_Pool[i] = (GameObject)Instantiate(Mono_S);
            Mono_S_Pool[i].SetActive(false);

            M_Field_N_Pool[i] = (GameObject)Instantiate(M_Field_N);
            M_Field_N_Pool[i].SetActive(false);
            M_Field_S_Pool[i] = (GameObject)Instantiate(M_Field_S);
            M_Field_S_Pool[i].SetActive(false);
        }
        for (int i = 0; i<barLimit; i++)
        {
            Bar_Pool[i] = (GameObject)Instantiate(Bar_Mag);
            Bar_Pool[i].SetActive(false);
        }
	}

	public GameObject GetMono_N()
    {
        
        for(int i = 0; i<poolSize; i++)
        {
            if (!Mono_N_Pool[i].activeSelf)
            {
                Mono_N_Pool[i].SetActive(true);
                //Debug.Log("getmono");
                return Mono_N_Pool[i];
            }
        }
        return null;
    }

    public GameObject GetMono_S()
    {

        for (int i = 0; i < poolSize; i++)
        {
            if (!Mono_S_Pool[i].activeSelf)
            {
                Mono_S_Pool[i].SetActive(true);
                return Mono_S_Pool[i];
            }
        }
        return null;
    }


    public GameObject GetBar()
    {
        for (int i = 0; i < barLimit; i++)
        {
            if (!Bar_Pool[i].activeSelf)
            {
                Bar_Pool[i].SetActive(true);
                return Bar_Pool[i];
            }
        }
        return null;
    }

    public GameObject GetMField_N()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if (!M_Field_N_Pool[i].activeSelf)
            {
                M_Field_N_Pool[i].SetActive(true);
                return M_Field_N_Pool[i];
            }
        }
        return null;
    }

    public GameObject GetMField_S()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if (!M_Field_S_Pool[i].activeSelf)
            {
                M_Field_S_Pool[i].SetActive(true);
                return M_Field_S_Pool[i];
            }
        }
        return null;
    }

}
