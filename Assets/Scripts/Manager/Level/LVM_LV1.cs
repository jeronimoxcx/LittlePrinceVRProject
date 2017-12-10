using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LVM_LV1 : MonoBehaviour {

    private Param param;

    public GameObject enemyGeneratorRed;
    public GameObject enemyGeneratorBlue;
    public GameObject levelScroll;
    public TextMesh levelText;
    public GameObject gameStatusCanvas;
    public Text status;
    public GameObject nextLevelButton;
    public GameObject tryAgainButton;

    public GameObject controllerRight;
    public GameObject controllerLeft;
    public GameObject L_Hand;
    public GameObject R_Hand;



    private float timer=0.0f;
    private int onceFlag = 1;

    private void Start()
    {
        resetGame();

    }

    public void resetGame()
    {
        param = GameObject.Find("Param").GetComponent<Param>();
        levelScroll = GameObject.Find("Scroll");
        levelText = GameObject.Find("leveltext").GetComponent<TextMesh>();
        gameStatusCanvas = GameObject.Find("GameStatusCanvas");
        nextLevelButton = GameObject.Find("NextLevel");
        tryAgainButton = GameObject.Find("TryAgain");

        gameStatusCanvas.SetActive(false);
        controllerLeft.GetComponent<SteamVR_LaserPointer>().enabled = false;
        controllerRight.GetComponent<SteamVR_LaserPointer>().enabled = false;
    }

    void Update () {
        if (Rose.gameover)
        {
            controllerLeft.GetComponent<SteamVR_LaserPointer>().enabled = true;
            controllerRight.GetComponent<SteamVR_LaserPointer>().enabled = true;
            controllerLeft.GetComponent<FireManager_L>().enabled = false;
            controllerRight.GetComponent<FireManager_R>().enabled = false;
            L_Hand.SetActive(false);
            R_Hand.SetActive(false);
            enemyGeneratorRed.SendMessage("StopWorking");
            enemyGeneratorBlue.SendMessage("StopWorking");

            gameStatusCanvas.SetActive(true);
            status.text = "Game Over";
            nextLevelButton.SetActive(false);

        }
        if (timer < param.LV_showTextTime)
        {
            timer += Time.deltaTime;
            levelText.text = ("Level 1");
            
        }
        else //if (timer < param.LV_showTextTime+param.LV_playTime) 
        {
            timer += Time.deltaTime;

            if (onceFlag == 1)
            {
                onceFlag = 0;
                levelScroll.SetActive(false);
                levelText.text = "";
                enemyGeneratorRed.SendMessage("StartWorking");
                enemyGeneratorBlue.SendMessage("StartWorking");
            }
        }
        //else 
        //{
         
        //    SceneManager.LoadScene("Level2");
        //}
    }
}
