using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    //public GameObject bombEffect_air;
    //public GameObject bombEffect_ground;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name.Contains("Ground"))
        {
            //Instantiate(bombEffect_ground, transform.position, Quaternion.identity);
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
        
    }
    
}
