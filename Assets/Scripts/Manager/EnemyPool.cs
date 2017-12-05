using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour {

    public GameObject enemyPrefab;
    public int poolSize;

    GameObject[] enemyPool;

    // Use this for initialization
    void Start()
    {
        enemyPool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            enemyPool[i] = (GameObject)Instantiate(enemyPrefab);
            enemyPool[i].SetActive(false);
        }
    }

    public GameObject GetObject()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if (!enemyPool[i].active)
            {
                enemyPool[i].GetComponent<ReceiveForce>().setIsPulledRoseTrue();
                enemyPool[i].SetActive(true);
                return enemyPool[i];
            }
        }
        return null;
    }
}
