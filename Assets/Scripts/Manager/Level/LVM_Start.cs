using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LVM_Start : MonoBehaviour {

    private Param param;
    private float timer = 0.0f;

    private void Start()
    {
        param = GameObject.Find("Param").GetComponent<Param>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > param.LV_StartTime) SceneManager.LoadScene("Level1");
    }
}
