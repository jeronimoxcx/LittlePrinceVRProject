using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {
    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name.Contains("Bomb"))
        {
            Destroy(col.gameObject);
        }
        else if (col.gameObject.name.Contains("Player"))
        {
            col.transform.position = 
                new Vector3(45, 10, -45);
        }
    }

}
