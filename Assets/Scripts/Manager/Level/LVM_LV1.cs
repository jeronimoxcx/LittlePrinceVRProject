using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LVM_LV1 : MonoBehaviour
{

    private Param param;

    public GameObject spaceshipRed;
    public GameObject spaceshipBlue;

    public EnemyGenerator enemyGeneratorRed;
    public EnemyGenerator enemyGeneratorBlue;
    public GameObject rose;
    int numOfCurRedEnemy = 0;
    int numOfCurBlueEnemy = 0;

    public GameObject levelScroll;
    public TextMesh levelText;
    public GameObject barSlider;
    public GameObject gameStatusCanvas;
    public Text status;
    public GameObject nextLevelButton;
    public GameObject tryAgainButton;
    public Text remainTime;

    public GameObject controllerRight;
    public GameObject controllerLeft;
    public GameObject L_Hand;
    public GameObject R_Hand;

    public int restartCount=0;
    public static bool remainGameOver = false;



    private float timer = 0.0f;
    private int onceFlag = 1;

    private void Awake()
    {
        param = GameObject.Find("Param").GetComponent<Param>();
        levelScroll = GameObject.Find("Scroll");
        levelText = GameObject.Find("leveltext").GetComponent<TextMesh>();

        nextLevelButton = GameObject.Find("NextLevel");
        tryAgainButton = GameObject.Find("TryAgain");

        controllerLeft.GetComponent<SteamVR_LaserPointer>().enabled = false;
        controllerRight.GetComponent<SteamVR_LaserPointer>().enabled = false;

        //todo:  이거 이상
        gameStatusCanvas.SetActive(false);

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

            barSlider.SetActive(false);
            gameStatusCanvas.SetActive(true);
            status.text = "Game Over";
            nextLevelButton.SetActive(false);
            remainTime.text = "";

            //deactive all enemy
            enemyGeneratorRed.gameObject.SetActive(false);
            enemyGeneratorBlue.gameObject.SetActive(false);
            spaceshipRed.SetActive(false);
            spaceshipBlue.SetActive(false);

            GameObject[] allObjectsN = GameObject.FindGameObjectsWithTag("N");
            GameObject[] allObjectsS = GameObject.FindGameObjectsWithTag("S");

            foreach (GameObject go in allObjectsN) go.SetActive(false);
            foreach (GameObject go in allObjectsS) go.SetActive(false);

            return;

        }
        

        if (timer < param.LV_showTextTime)
        {
            timer += Time.deltaTime;
            levelText.text = ("Level 1");

        }
        //MODE1: spaceships are static, shoot only one type per each.
        else if (timer < param.LV_showTextTime + 13)
        {
            levelScroll.SetActive(false);

            timer += Time.deltaTime;
            //todo:  남은 시간
            remainTime.text = "TIME: " + (60 - timer);

            shootBasicEnemyN(1.0f);
            shootBasicEnemyS(1.0f);
            shootItemEnemyN(3.0f);
            shootItemEnemyS(3.0f);
        }
        //MODE2: spaceships are moving, shoot only one type per each.
        else if (timer < param.LV_showTextTime + 58)
        {
            timer += Time.deltaTime;
            remainTime.text = "TIME: " + (60 - timer);

            MoveSpaceShipRed(3.0f, 10 );
            MoveSpaceShipBlue(3.0f, 10 );
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
            else if (timerForLimitS < 7.0f + Random.Range(-2.0f, 2.0f))
            {
                timerForLimitS += Time.deltaTime;
            }
            else
            {
                timerForLimitS = 0;
            }

            shootItemEnemyN(7.0f);
            shootItemEnemyS(7.0f);

        }
        else
        {
            //todo: set parameters or not
            if (!Rose.gameover)
            {
                controllerLeft.GetComponent<SteamVR_LaserPointer>().enabled = true;
                controllerRight.GetComponent<SteamVR_LaserPointer>().enabled = true;
                controllerLeft.GetComponent<VRUIInput>().enabled = true;
                controllerRight.GetComponent<VRUIInput>().enabled = true;
                controllerLeft.GetComponent<FireManager_L>().enabled = false;
                controllerRight.GetComponent<FireManager_R>().enabled = false;
                L_Hand.SetActive(false);
                R_Hand.SetActive(false);

                barSlider.SetActive(false);
                gameStatusCanvas.SetActive(true);
                status.text = "Proceed to Next Level";
                status.fontSize = 50;
                tryAgainButton.SetActive(false);
                return;
            }
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
    private float sphereEtimeItvN = 0.0f;

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