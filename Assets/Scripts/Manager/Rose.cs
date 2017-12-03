using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rose : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {   
        Debug.Log("Hit Rose");
        collision.gameObject.SetActive(false);
    }
}
