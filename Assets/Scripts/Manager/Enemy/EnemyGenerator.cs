using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGenerator: MonoBehaviour {

    //About Instantiating enemies

    Param param;

    private bool isWorking = true;

    public EnemyPool pool;
    private GameObject temp;

	public Transform FirePositionTransform;
    
    private float shootingTimeInterval = 0.0f;
    private float shootingTimer = 0.0f;

    void Start()
    {
        param = GameObject.Find("Param").GetComponent<Param>();
    }

    void Update()
    {
        if (isWorking)
        {
            if (shootingTimer >= shootingTimeInterval)
            {
                shootingTimer = 0;
                shootingTimeInterval = Random.Range(param.shootingTimeItvMin, param.shootingTimeItvMax);

                Shoot();

            }
            else
                shootingTimer += Time.deltaTime;
        }

    }

    public void StartWorking()
    {
        isWorking = true;
    }

    public void StopWorking()
    {
        isWorking = false;
    }

    private void Shoot()
    {
        temp = pool.GetObject();

        //set position
        temp.transform.position = FirePositionTransform.position;

        Vector3 initialVelocity = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-1.0f, 5.0f), 0);
        initialVelocity.Normalize();
        initialVelocity *= param.enemyShootingPower;

        temp.GetComponent<Rigidbody>().velocity = initialVelocity;
          
    }
}

