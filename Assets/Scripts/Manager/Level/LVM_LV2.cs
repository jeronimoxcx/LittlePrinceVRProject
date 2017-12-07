using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LVM_LV2 : MonoBehaviour {

    private Param param;

    public GameObject enemyGeneratorRed;
    public GameObject enemyGeneratorBlue;
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
            text.text = ("Level2");
        }
        else if (timer < param.LV_showTextTime + param.LV_playTime)
        {
            timer += Time.deltaTime;

            if (onceFlag == 1)
            {
                onceFlag = 0;
                text.text = ("");
                enemyGeneratorRed.SendMessage("StartWorking");
                enemyGeneratorBlue.SendMessage("StartWorking");
            }
        }
        else
        {
            SceneManager.LoadScene("Level3");
        }
    }
}
