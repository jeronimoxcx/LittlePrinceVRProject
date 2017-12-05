using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LVM_LV3 : MonoBehaviour {

    private Param param;

    public Text text;

    private float timer = 0.0f;
    private int onceFlag = 1;

    private void Start()
    {
        param = GameObject.Find("Param").GetComponent<Param>();
    }

    void Update()
    {

        if (timer < param.LV_showTextTime)
        {
            timer += Time.deltaTime;
            text.text = ("Level3");
        }
        else if (timer < param.LV_showTextTime + param.LV_playTime)
        {
            timer += Time.deltaTime;

            if (onceFlag == 1)
            {
                onceFlag = 0;
                text.text = ("");
            }
        }
        else
        {
            SceneManager.LoadScene("Finish");
        }
    }
}
