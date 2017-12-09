using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour {

    public GameObject enemyPrefab;
    public GameObject enemyItemPrefab;
    public int poolSize;

    GameObject[] enemyPool;
    GameObject[] enemyItemPool;

    // Use this for initialization
    void Start()
    {
        //enemyPool = new GameObject[poolSize];
        //for (int i = 0; i < poolSize; i++)
        //{
        //    enemyPool[i] = (GameObject)Instantiate(enemyPrefab);
        //    enemyPool[i].SetActive(false);
        //}
        enemyItemPool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            enemyItemPool[i] = (GameObject)Instantiate(enemyItemPrefab);
            enemyItemPool[i].SetActive(false);
        }
    }

    public GameObject GetObject()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if (!enemyPool[i].active)
            {
                enemyPool[i].SetActive(true);
                return enemyPool[i];
            }
        }
        return null;
    }

    public GameObject GetItemObject()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if (!enemyItemPool[i].active)
            {
                enemyItemPool[i].SetActive(true);
                return enemyItemPool[i];
            }
        }
        return null;
    }


}
