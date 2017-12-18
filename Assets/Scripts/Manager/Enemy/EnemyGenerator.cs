using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGenerator : MonoBehaviour
{

    //About Instantiating enemies

    Param param;
    public GameObject rose;
    public EnemyPool pool;
    public Transform FirePositionTransform;
    public bool isWorking;

    void Start()
    {
        param = GameObject.Find("Param").GetComponent<Param>();
    }

    public void shootBasicEnemy()
    {
            GameObject temp = pool.GetObject();
            initializeState(temp);
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
        Vector3 target = rose.transform.position;
        Vector3 initialVelocity = target - enemy.transform.position;
        initialVelocity.Normalize();
        enemy.GetComponent<Rigidbody>().velocity = initialVelocity;
        //rotation
        
        return enemy;

    }

    private GameObject initializeStateParabolic(GameObject enemy)
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

    public void StartWorking()
    {
        isWorking = true;
    }

    public void StopWorking()
    {
        isWorking = false;
    }

}

