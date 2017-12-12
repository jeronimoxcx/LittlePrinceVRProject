using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class restartGame : MonoBehaviour {

    private Param param;

    public GameObject LevelManager;
    public GameObject levelScroll;
    public TextMesh levelText;
    public GameObject barSlider;
    public GameObject gameStatusCanvas;
    public Text status;
    public GameObject nextLevelButton;
    public GameObject tryAgainButton;

    public GameObject controllerRight;
    public GameObject controllerLeft;
    public GameObject L_Hand;
    public GameObject R_Hand;

    private void Start()
    {
        //LevelManager = GameObject.Find("Level Manager");

    }

    public void LoadScene(int level)
    {
        switch (level)
        {
            case 1:
                LevelManager.GetComponent<LVM_LV1>().enabled = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Debug.Log("lol");
                comboSlider.currentGage = 0;
                Rose.gameover = false;
                LevelManager.GetComponent<LVM_LV1>().enabled = true;
                return;
            case 2:
                LevelManager.GetComponent<LVM_LV2>().enabled = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Debug.Log("lol");
                comboSlider.currentGage = 0;
                Rose.gameover = false;
                LevelManager.GetComponent<LVM_LV2>().enabled = true;
                return;
            case 3:
                LevelManager.GetComponent<LVM_LV3>().enabled = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Debug.Log("lol");
                comboSlider.currentGage = 0;
                Rose.gameover = false;
                LevelManager.GetComponent<LVM_LV3>().enabled = true;
                return;

        }
        

    }

    // Use this for initialization
    public void Restart (int level) {
        /*
        param = GameObject.Find("Param").GetComponent<Param>();
        levelScroll = GameObject.Find("Scroll");
        levelText = GameObject.Find("leveltext").GetComponent<TextMesh>();

        nextLevelButton = GameObject.Find("NextLevel");
        tryAgainButton = GameObject.Find("TryAgain");

        gameStatusCanvas.SetActive(false);
        controllerLeft.GetComponent<SteamVR_LaserPointer>().enabled = false;
        controllerRight.GetComponent<SteamVR_LaserPointer>().enabled = false;*/
        LevelManager.SetActive(false);
        //LevelManager.

        Application.LoadLevel(level);
    }
	
	
}
