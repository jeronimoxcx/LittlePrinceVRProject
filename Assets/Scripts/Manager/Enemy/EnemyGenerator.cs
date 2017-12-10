using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGenerator : MonoBehaviour
{

    //About Instantiating enemies

    Param param;
    public EnemyPool pool;
    public Transform FirePositionTransform;


    void Start()
    {
        param = GameObject.Find("Param").GetComponent<Param>();
    }

    public void shootBasicEnemy()
    {
        int numEnemy = Random.Range(param.EM_numPerOnceMin, param.EM_numPerOnceMax);
        Debug.Log(numEnemy);

        for (int i = 0; i < numEnemy; i++)
        {
            GameObject temp = pool.GetObject();
            initializeState(temp);
        }
    }

    public void shootItemEnemy()
    {
        GameObject temp = pool.GetItemObject();
        initializeState(temp);
    }

    public void shootSphereEnemy()
    {
        GameObject temp = pool.GetSphereEnemy();
        initializeState(temp);
    }


    private GameObject initializeState(GameObject enemy)
    {

        //position
        enemy.transform.position = FirePositionTransform.position;
        //velocity
        Vector3 initialVelocity = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-1.0f, 5.0f), 0);
        initialVelocity.Normalize();
        enemy.GetComponent<Rigidbody>().velocity = initialVelocity;
        //rotation
        enemy.transform.rotation = new Quaternion(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), 0);
        return enemy;

    }

}
