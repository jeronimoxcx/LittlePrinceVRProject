using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{

    public GameObject enemyPrefab, enemyItemPrefab, sphereEnemyPrefab, wormEnemyPrefab;

    public int poolSize;

    GameObject[] enemyPool, enemyItemPool, sphereEnemyPool, wormEnemyPool;

    void Start()
    {
        //Initialize pools
        enemyPool = new GameObject[poolSize];
        enemyItemPool = new GameObject[poolSize / 2];
        sphereEnemyPool = new GameObject[poolSize / 2];
        wormEnemyPool = new GameObject[poolSize / 2];

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

            wormEnemyPool[i] = (GameObject)Instantiate(wormEnemyPrefab);
            wormEnemyPool[i].SetActive(false);
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
        return (GameObject)Instantiate(sphereEnemyPrefab);
    }

    public GameObject GetWormEnemy()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if (!wormEnemyPool[i].active)
            {
                wormEnemyPool[i].SetActive(true);
                return wormEnemyPool[i];
            }
        }
        return null;
    }

}
