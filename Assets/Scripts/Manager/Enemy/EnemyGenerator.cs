using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGenerator: MonoBehaviour {

    //About Instantiating enemies

    Param param;

    private bool isWorking = true;

    public EnemyPool pool;

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
                shootingTimeInterval = Random.Range(param.EM_shootingTimeItvMin, param.EM_shootingTimeItvMax);

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
        int numEnemy = Random.Range(param.EM_numPerOnceMin, param.EM_numPerOnceMax);

        for(int i=0; i<numEnemy; i++)
        {
            GameObject temp = pool.GetObject();

            //set position
            temp.transform.position = FirePositionTransform.position;

            Vector3 initialVelocity = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-1.0f, 5.0f), 0);
            //Vector3 initialVelocity = new Vector3(0.1f, -0.5f, -0.5f);
            initialVelocity.Normalize();

            temp.GetComponent<Rigidbody>().velocity = initialVelocity;
            temp.transform.rotation = new Quaternion(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f),0);
        }
    }
}

