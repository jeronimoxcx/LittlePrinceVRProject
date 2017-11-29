using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGenerator: MonoBehaviour {

    //About Instantiating enemies
    public EnemyPool pool;
    private GameObject temp;
    private float power = 10.0f;
	public Transform FirePositionTransform;
    
    private float shootingTimeInterval = 0.0f;
    private float shootingTimer = 0.0f;

    //About Controlling level
    private float level1EndTime = 10.0f; //end time
    private float level2EndTime = 20.0f; //end time
    private float levelTimer = 0.0f;
    public Text levelText;

	void Update () {

        //Level1
        if( levelTimer < level1EndTime )
        {
            //levelText.text = ("Level 1");
            if (shootingTimer >= shootingTimeInterval)
            {
                shootingTimer = 0;
                shootingTimeInterval = setshootingTimeIntervalLevel1();

                Shoot();
            }
            else
                shootingTimer += Time.deltaTime;

            levelTimer += Time.deltaTime;
        }
        //Level2 
        else if (levelTimer < level2EndTime)
        {
            Debug.Log("start level2");
            //levelText.text = ("Level 2");
            if (shootingTimer >= shootingTimeInterval)
            {
                shootingTimer = 0;
                shootingTimeInterval = setshootingTimeIntervalLevel2();

                Shoot();
            }
            else
                shootingTimer += Time.deltaTime;

            levelTimer += Time.deltaTime;
        }
        //Level3
        else
        {
            //levelText.text = ("Level 3");
        }

	}

    private void Shoot()
    {
        temp = pool.GetObject();

        //set position
        temp.transform.position = FirePositionTransform.position;

        //seung-wook
        temp.GetComponent<Rigidbody>().velocity = ((GameObject.Find("Single_Rose").transform.position - temp.transform.position).normalized) * power;

        //sun-young (parabolic motion)
        //set velocity
        /*
                Vector3 initialVelocity = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0);
                initialVelocity.Normalize();
                initialVelocity *= power;

                temp.GetComponent<Rigidbody>().velocity = initialVelocity;
          */
    }

    private float setshootingTimeIntervalLevel1()
    {
        return Random.Range(1.0f, 2.5f);
    }

    private float setshootingTimeIntervalLevel2()
    {
        return Random.Range(0.5f, 1.0f);
    }

}

