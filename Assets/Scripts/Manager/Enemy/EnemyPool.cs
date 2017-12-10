using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{

    public GameObject enemyPrefab, enemyItemPrefab, sphereEnemyPrefab;

    public int poolSize;

    GameObject[] enemyPool, enemyItemPool;

    void Start()
    {
        //Initialize pools
        enemyPool = new GameObject[poolSize];
        enemyItemPool = new GameObject[poolSize / 2];

        for (int i = 0; i < poolSize; i++)
        {
            enemyPool[i] = (GameObject)Instantiate(enemyPrefab);
            enemyPool[i].SetActive(false);
        }

        for (int i = 0; i < poolSize / 2; i++)
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
                enemyPool[i].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                enemyPool[i].transform.rotation = new Quaternion(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), 0);
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
                enemyItemPool[i].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                enemyItemPool[i].transform.rotation = new Quaternion(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), 0);
                enemyItemPool[i].SetActive(true);
                return enemyItemPool[i];
            }
        }
        return null;
    }

    public GameObject GetSphereEnemy()
    {
        return (GameObject)Instantiate(sphereEnemyPrefab);
    }

}
