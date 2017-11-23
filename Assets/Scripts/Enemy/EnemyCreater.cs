using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreater : MonoBehaviour {

    public EnemyPool pool;

    private float power = 10.0f;
	public Transform FirePositionTransform;
    private GameObject temp;

    private float timeInterval = 0.0f;
    private float time = 0.0f;
    

	void Update () {

        if (time >= timeInterval)
        {   
            time = 0;
            timeInterval = Random.Range(0.5f, 1.5f);
       
            Shoot();
        }
        else
            time += Time.deltaTime;    
	}

    private void Shoot()
    {
        temp = pool.GetObject();

        //set position
        temp.transform.position = FirePositionTransform.position;

        //set velocity
        Vector3 initialVelocity = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0);
        initialVelocity.Normalize();
        initialVelocity *= power;

        temp.GetComponent<Rigidbody>().velocity = initialVelocity;
    }
}

