using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour {

    private Collider[] hitColliders;

    private void OnCollisionEnter(Collision collision)
    {
        hitColliders = Physics.OverlapSphere(collision.gameObject.transform.position, 2);

        for (int i=0; i<hitColliders.Length; i++)
        {
            if (hitColliders[i].gameObject.tag != "Collector" && hitColliders[i].gameObject.name != "Sphere")
            {                
                hitColliders[i].gameObject.SetActive(false);
            }
        }
    }
}
