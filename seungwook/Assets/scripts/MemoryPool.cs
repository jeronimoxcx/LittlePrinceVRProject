using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPool : MonoBehaviour {
    public GameObject Mono_N;
    public GameObject Mono_S;
    public GameObject Enemy1_S;
    public int poolSize = 50;
    
    GameObject[] Mono_N_Pool;
    GameObject[] Mono_S_Pool;
    GameObject[] Enemy1_S_Pool;

    // Use this for initialization
    void Start () {
        Mono_N_Pool = new GameObject[poolSize];
        Mono_S_Pool = new GameObject[poolSize];
        Enemy1_S_Pool = new GameObject[poolSize];
        for (int i = 0; i<poolSize; i++)
        {
            Mono_N_Pool[i] = (GameObject)Instantiate(Mono_N);
            Mono_N_Pool[i].SetActive(false);
            Mono_S_Pool[i] = (GameObject)Instantiate(Mono_S);
            Mono_S_Pool[i].SetActive(false);
            Enemy1_S_Pool[i] = (GameObject)Instantiate(Enemy1_S);
            Enemy1_S_Pool[i].SetActive(false);
        }
	}

	public GameObject GetMono_N()
    {
        
        for(int i = 0; i<poolSize; i++)
        {
            if (!Mono_N_Pool[i].activeSelf)
            {
                Mono_N_Pool[i].SetActive(true);
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


    public GameObject GetEnemy1_S()
    {

        for (int i = 0; i < poolSize; i++)
        {
            if (!Enemy1_S_Pool[i].activeSelf)
            {
                Enemy1_S_Pool[i].SetActive(true);
                return Enemy1_S_Pool[i];
            }
        }
        return null;
    }

}
