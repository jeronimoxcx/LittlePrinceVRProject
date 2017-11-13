using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

    public GameObject Player;
    public MemoryPool pool;

    private float nextGenTime = 0.0f;
    public float period = 1.0f;

    public float EnemySpeed = 20.0F;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextGenTime)
        {
            nextGenTime += period;
            // execute block of code here
            Vector3 GenPosition = new Vector3(Random.Range(-50, 50), Random.Range(10, 60), 100);

            GameObject temp = pool.GetEnemy1_S();

            temp.transform.position = GenPosition;

            temp.GetComponent<Rigidbody>().velocity = ((Player.transform.position - temp.transform.position).normalized) * EnemySpeed;

        }

    }
}
