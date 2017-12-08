using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_field : MonoBehaviour {

    private Param param;

    private Vector3 flydirection;
    private Vector3 velocity;

    private int startflying = 0;
    private float flytime;

    // Use this for initialization
    void OnEnable () {
        param = GameObject.Find("Param").GetComponent<Param>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += velocity * Time.deltaTime;
        if (startflying == 1 && flytime < Time.time)
        {
            gameObject.SetActive(false);
            startflying = 0;
        }

    }

    void OnTriggerExit(Collider col)
    {
        if (col.name.Contains("Enemy"))
        {
            //col.SendMessage("Slowdown");
            //if (col.tag != gameObject.tag) 승욱쓰꺼임
            if (col.tag == gameObject.tag)
            {
                col.SendMessage("Slowdown");
            }
            else
            {
                col.SendMessage("Fastenup");
            }
        }
    }

    void fly(Vector3 direction)
    {
        flydirection = direction;
        velocity = flydirection * param.PW_FieldShootingPower;
        startflying = 1;
        flytime = Time.time + 7.5f;
    }
}
