using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGenerator: MonoBehaviour {

    Param param;

    public EnemyPool pool;
    private GameObject temp;

	public Transform FirePositionTransform;

    public Text levelText;
    
    private float shootingTimeInterval = 0.0f;
    private float shootingTimer = 0.0f;

    void Start()
    {
        param = GameObject.Find("Param").GetComponent<Param>();
    }

    void Update()
    {

        if (shootingTimer >= shootingTimeInterval)
        {
            shootingTimer = 0;
            shootingTimeInterval = Random.Range(param.shootingTimeItvRangeMin, param.shootingTimeItvRangeMax);

            Shoot();

        }
        else
            shootingTimer += Time.deltaTime;


        //   levelTimer += Time.deltaTime;

        ////Level1
        //if( levelTimer < level1EndTime )
        //{
        //    //levelText.text = ("Level 1");
        //    if (shootingTimer >= shootingTimeInterval)
        //    {
        //        shootingTimer = 0;
        //        shootingTimeInterval = setshootingTimeIntervalLevel1();

        //        Shoot();
        //    }
        //    else
        //        shootingTimer += Time.deltaTime;

        //    levelTimer += Time.deltaTime;
        //}
        ////Level2 
        //else if (levelTimer < level2EndTime)
        //{
        //    Debug.Log("start level2");
        //    //levelText.text = ("Level 2");
        //    if (shootingTimer >= shootingTimeInterval)
        //    {
        //        shootingTimer = 0;
        //        shootingTimeInterval = setshootingTimeIntervalLevel2();

        //        Shoot();
        //    }
        //    else
        //        shootingTimer += Time.deltaTime;

        //    levelTimer += Time.deltaTime;
        //}
        ////Level3
        //else
        //{
        //    //levelText.text = ("Level 3");
        //}

    }

    private void Shoot()
    {
        temp = pool.GetObject();

        //set position
        temp.transform.position = FirePositionTransform.position;

        //sun-young (parabolic motion)
        Vector3 initialVelocity = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-1.0f, 5.0f), 0);
        initialVelocity.Normalize();
        initialVelocity *= param.enemyShootingPower;

        temp.GetComponent<Rigidbody>().velocity = initialVelocity;
          
    }

}

