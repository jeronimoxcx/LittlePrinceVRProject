using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LVM_LV3 : MonoBehaviour {

    private Param param;

    public GameObject bossSpaceShip;
    public GameObject boss;

    public GameObject spaceshipRed;
    public GameObject spaceshipBlue;

    public EnemyGenerator enemyGeneratorRed;
    public EnemyGenerator enemyGeneratorBlue;
    public GameObject rose;

    public GameObject levelScroll;
    public TextMesh levelText;

    public GameObject barUI; //king hp
    public GameObject barSlider; //barmagnet icon slider
    public GameObject gameStatusCanvas;
    public Text status;
    public GameObject nextLevelButton;
    public GameObject tryAgainButton;

    public GameObject controllerRight;
    public GameObject controllerLeft;
    public GameObject L_Hand;
    public GameObject R_Hand;

    //Space Ship animation
    float spaceShipAppearTime = 3.0f;
    Vector3 spaceShipStartPose;
    Vector3 spaceShipTargetPose;   
    Vector3 spaceShipVelocity;

    //Boss animation 
    float bossAppearTime = 1.0f;

    private float timer = 0.0f;
    private int onceFlag = 1;

    private void Start()
    {
        param = GameObject.Find("Param").GetComponent<Param>();
        boss.SetActive(false);

        levelScroll = GameObject.Find("Scroll");
        levelText = GameObject.Find("leveltext").GetComponent<TextMesh>();
        barUI = GameObject.Find("BarSlider");
        barUI.SetActive(false);
        nextLevelButton = GameObject.Find("NextLevel");
        tryAgainButton = GameObject.Find("TryAgain");

        gameStatusCanvas.SetActive(false);

        controllerLeft.GetComponent<SteamVR_LaserPointer>().enabled = false;
        controllerRight.GetComponent<SteamVR_LaserPointer>().enabled = false;


        //For space ship animation
        spaceShipStartPose = new Vector3(-6.7f, 25.6f, 70.4f);
        spaceShipTargetPose = new Vector3(-6.7f, 15.85f, 35.51f);
        spaceShipVelocity = (spaceShipTargetPose - spaceShipStartPose) / spaceShipAppearTime;
    }


    private float timerForLimitN = 0f;
    private float timerForLimitS = 0f;

    void Update()
    {
        if (Rose.gameover)
        {

            controllerLeft.GetComponent<SteamVR_LaserPointer>().enabled = true;
            controllerRight.GetComponent<SteamVR_LaserPointer>().enabled = true;
            controllerLeft.GetComponent<VRUIInput>().enabled = true;
            controllerRight.GetComponent<VRUIInput>().enabled = true;
            controllerLeft.GetComponent<FireManager_L>().enabled = false;
            controllerRight.GetComponent<FireManager_R>().enabled = false;
            L_Hand.SetActive(false);
            R_Hand.SetActive(false);

            barUI.SetActive(false);
            gameStatusCanvas.SetActive(true);
            status.text = "Game Over";
            nextLevelButton.SetActive(false);
            return;

        }
        else if (Boss.bossHp.value <= 0)
        {
            boss.SetActive(false);
            controllerLeft.GetComponent<SteamVR_LaserPointer>().enabled = true;
            controllerRight.GetComponent<SteamVR_LaserPointer>().enabled = true;
            controllerLeft.GetComponent<VRUIInput>().enabled = true;
            controllerRight.GetComponent<VRUIInput>().enabled = true;
            controllerLeft.GetComponent<FireManager_L>().enabled = false;
            controllerRight.GetComponent<FireManager_R>().enabled = false;
            L_Hand.SetActive(false);
            R_Hand.SetActive(false);

            barUI.SetActive(false);
            gameStatusCanvas.SetActive(true);
            status.text = "Congratulations";
            status.fontSize = 50;
            tryAgainButton.SetActive(false);
            return;
        }

        if (timer < param.LV_showTextTime)
        {
            timer += Time.deltaTime;
            levelText.text = ("Level 3");
        } // Appear space ship
        else if(timer < param.LV_showTextTime + spaceShipAppearTime)
        {
            timer += Time.deltaTime;
            levelScroll.SetActive(false);
            levelText.text = ("");
            bossSpaceShip.GetComponent<Rigidbody>().velocity = spaceShipVelocity;

        }
        else if (timer < param.LV_showTextTime + spaceShipAppearTime+0.5)
        {
            timer += Time.deltaTime;
            bossSpaceShip.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
        // Appear boss
        else if (timer < param.LV_showTextTime + spaceShipAppearTime+0.5 + bossAppearTime)
        {
            timer += Time.deltaTime;
            boss.SetActive(true);
            barUI.SetActive(true);
        }

        else if (timer < param.LV_showTextTime + spaceShipAppearTime+60)
        {
            levelScroll.SetActive(false);

            timer += Time.deltaTime;

            if (onceFlag == 1)
            {
                onceFlag = 0;
                boss.SendMessage("StartWorking");
            }
            //todo:  남은 시간

            MoveSpaceShipRed(3.0f, 10);
            MoveSpaceShipBlue(3.0f, 10);

            if (spaceshipRed.transform.position.x < -50 || spaceshipRed.transform.position.x > 50)
                spaceshipRed.GetComponent<Rigidbody>().velocity = new Vector3(-spaceshipRed.GetComponent<Rigidbody>().velocity.x, spaceshipRed.GetComponent<Rigidbody>().velocity.y, 0);
            if (spaceshipRed.transform.position.y < -10 || spaceshipRed.transform.position.y > 50)
                spaceshipRed.GetComponent<Rigidbody>().velocity = new Vector3(spaceshipRed.GetComponent<Rigidbody>().velocity.x, -spaceshipRed.GetComponent<Rigidbody>().velocity.y, 0);
            if (spaceshipBlue.transform.position.x < -50 || spaceshipBlue.transform.position.x > 50)
                spaceshipBlue.GetComponent<Rigidbody>().velocity = new Vector3(-spaceshipBlue.GetComponent<Rigidbody>().velocity.x, spaceshipBlue.GetComponent<Rigidbody>().velocity.y, 0);
            if (spaceshipBlue.transform.position.y < -10 || spaceshipBlue.transform.position.y > 50)
                spaceshipBlue.GetComponent<Rigidbody>().velocity = new Vector3(spaceshipBlue.GetComponent<Rigidbody>().velocity.x, -spaceshipBlue.GetComponent<Rigidbody>().velocity.y, 0);

            //Enemy N
            if (timerForLimitN < 0.8f + Random.Range(-0.1f, 0.1f))
            {
                shootBasicEnemyN(0.1f);
                timerForLimitN += Time.deltaTime;
            }
            else if (timerForLimitN < 7.0f + Random.Range(-2.0f, 2.0f))
            {
                timerForLimitN += Time.deltaTime;
            }
            else
            {
                timerForLimitN = 0;
            }

            //Enemy S
            if (timerForLimitS < 0.8f + Random.Range(-0.1f, 0.1f))
            {
                shootBasicEnemyS(0.1f);
                timerForLimitS += Time.deltaTime;
            }
            else if (timerForLimitS < 5.0f + Random.Range(-2.0f, 2.0f))
            {
                timerForLimitS += Time.deltaTime;
            }
            else
            {
                timerForLimitS = 0;
            }
            shootItemEnemyN(5.0f);
            shootItemEnemyS(5.0f);
            shootSphereEnemyN(7.0f);
            shootSphereEnemyN(7.0f);
        }
        
    }

    /* Move spaceships -------------------------------------------------------------------------------*/

    float velChangeTimerRed = 0.0f;
    float velChangeItvRed = 0.0f;

    public void MoveSpaceShipRed(float timeInterval, float speed)
    {
        if (velChangeTimerRed >= velChangeItvRed)
        {
            velChangeTimerRed = 0.0f;
            velChangeItvRed = Random.Range(timeInterval * 0.5f, timeInterval * 2.0f);

            Vector3 vel = spaceshipRed.GetComponent<Rigidbody>().velocity.normalized;
            float randX = Random.Range(-15.0f, 15.0f);
            float randY = Random.Range(10.0f, 30.0f);

            spaceshipRed.GetComponent<Rigidbody>().velocity = speed * (new Vector3(randX - spaceshipRed.transform.position.x, randY - spaceshipRed.transform.position.y, 0)).normalized;
            //spaceshipRed.transform.LookAt(rose.transform.position);
        }
        else
            velChangeTimerRed += Time.deltaTime;
    }

    float velChangeTimerBlue = 0.0f;
    float velChangeItvBlue = 0.0f;

    public void MoveSpaceShipBlue(float timeInterval, float speed)
    {
        if (velChangeTimerBlue >= velChangeItvBlue)
        {
            velChangeTimerBlue = 0.0f;
            velChangeItvBlue = Random.Range(timeInterval * 0.5f, timeInterval * 2.0f);

            Vector3 vel = spaceshipBlue.GetComponent<Rigidbody>().velocity.normalized;
            float randX = Random.Range(-15.0f, 15.0f);
            float randY = Random.Range(10.0f, 30.0f);

            spaceshipBlue.GetComponent<Rigidbody>().velocity = speed * (new Vector3(randX - spaceshipBlue.transform.position.x, randY - spaceshipBlue.transform.position.y, 0)).normalized;
            //spaceshipBlue.transform.LookAt(rose.transform.position);
        }
        else
            velChangeTimerBlue += Time.deltaTime;
    }

    /* Basic Enemy ------------------------------------------------------------------------------*/
    private float basicEtimerN = 0.0f;
    private float basicEtimeItvN = 0.0f;

    public void shootBasicEnemyN(float timeInterval)
    {
        if (basicEtimerN >= basicEtimeItvN)
        {
            basicEtimerN = 0.0f;
            basicEtimeItvN = Random.Range(timeInterval * 0.5f, timeInterval * 1.5f);
            enemyGeneratorRed.shootBasicEnemy();
        }
        else
        {
            basicEtimerN += Time.deltaTime;
        }
    }

    private float basicEtimerS = 0.0f;
    private float basicEtimeItvS = 2.0f;

    public void shootBasicEnemyS(float timeInterval)
    {
        if (basicEtimerS >= basicEtimeItvS)
        {
            basicEtimerS = 0.0f;
            basicEtimeItvS = Random.Range(timeInterval * 0.5f, timeInterval * 1.5f);
            enemyGeneratorBlue.shootBasicEnemy();
        }
        else
        {
            basicEtimerS += Time.deltaTime;
        }
    }

    /* Item(Bar magnet) Enemy ------------------------------------------------------------------------------*/

    private float itemEtimerN = 0.0f;
    private float itemEtimeItvN = 0.0f;

    public void shootItemEnemyN(float timeInterval)
    {
        if (itemEtimerN >= itemEtimeItvN)
        {
            itemEtimerN = 0.0f;
            itemEtimeItvN = Random.Range(timeInterval * 0.5f, timeInterval * 1.5f);
            enemyGeneratorRed.shootItemEnemy();
        }
        else
        {
            itemEtimerN += Time.deltaTime;
        }
    }

    private float itemEtimerS = 0.0f;
    private float itemEtimeItvS = 0.0f;

    public void shootItemEnemyS(float timeInterval)
    {
        if (itemEtimerS >= itemEtimeItvS)
        {
            itemEtimerS = 0.0f;
            itemEtimeItvS = Random.Range(timeInterval * 0.5f, timeInterval * 1.5f);
            enemyGeneratorBlue.shootItemEnemy();
        }
        else
        {
            itemEtimerS += Time.deltaTime;
        }
    }

    /* Sphere Enemy ------------------------------------------------------------------------------*/


    private float sphereEtimerN = 0.0f;
    private float sphereEtimeItvN = 3.0f;

    public void shootSphereEnemyN(float timeInterval)
    {
        if (sphereEtimerN >= sphereEtimeItvN)
        {
            sphereEtimerN = 0.0f;
            sphereEtimeItvN = Random.Range(timeInterval * 0.5f, timeInterval * 1.5f);
            enemyGeneratorRed.shootSphereEnemy();
        }
        else
        {
            sphereEtimerN += Time.deltaTime;
        }
    }

    private float sphereEtimerS = 0.0f;
    private float sphereEtimeItvS = 0.0f;

    public void shootSphereEnemyS(float timeInterval)
    {
        if (sphereEtimerS >= sphereEtimeItvS)
        {
            sphereEtimerS = 0.0f;
            sphereEtimeItvS = Random.Range(timeInterval * 0.5f, timeInterval * 1.5f);
            enemyGeneratorBlue.shootSphereEnemy();
        }
        else
        {
            sphereEtimerS += Time.deltaTime;
        }
    }
}
