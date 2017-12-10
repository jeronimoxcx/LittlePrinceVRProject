using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{

    public GameObject enemyPrefab, enemyItemPrefab, sphereEnemyPrefab;

    public int poolSize;

    GameObject[] enemyPool, enemyItemPool, sphereEnemyPool;

    void Start()
    {
        //Initialize pools
        enemyPool = new GameObject[poolSize];
        enemyItemPool = new GameObject[poolSize / 2];
        sphereEnemyPool = new GameObject[poolSize / 2];

        for (int i = 0; i < poolSize; i++)
        {
            enemyPool[i] = (GameObject)Instantiate(enemyPrefab);
            enemyPool[i].SetActive(false);
        }

        for (int i = 0; i < poolSize / 2; i++)
        {
            enemyItemPool[i] = (GameObject)Instantiate(enemyItemPrefab);
            enemyItemPool[i].SetActive(false);

            //sphereEnemyPool[i] = (GameObject)Instantiate(sphereEnemyPrefab);
            //sphereEnemyPool[i].SetActive(false);

        }

    }

    public GameObject GetObject()
    {
        //Debug.Log("GetObject");
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

    public GameObject GetSphereEnemy()
    {
        //for (int i = 0; i < poolSize; i++)
        //{
        //    if (!sphereEnemyPool[i].active)
        //    {
        //        sphereEnemyPool[i].SetActive(true);
        //        return sphereEnemyPool[i];
        //    }
        //}
        Debug.Log("getsphereenemy");
        return (GameObject)Instantiate(sphereEnemyPrefab);
    }

}