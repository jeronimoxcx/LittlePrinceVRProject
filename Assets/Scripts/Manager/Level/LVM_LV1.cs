using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LVM_LV1 : MonoBehaviour {

    private Param param;

<<<<<<< HEAD
    public GameObject spaceshipRed;
    public GameObject spaceshipBlue;
    public EnemyGenerator enemyGeneratorRed;
    public EnemyGenerator enemyGeneratorBlue;
    public GameObject rose;
=======
    public GameObject enemyGeneratorRed;
    public GameObject enemyGeneratorBlue;
>>>>>>> 16f6718cb9e667bd846482d652550db896968bac
    public GameObject levelScroll;
    public TextMesh levelText;

    private float timer=0.0f;

    private void Start()
    {
        param = GameObject.Find("Param").GetComponent<Param>();
        levelScroll = GameObject.Find("Scroll");
        levelText = GameObject.Find("leveltext").GetComponent<TextMesh>();
    }


    void Update () {
<<<<<<< HEAD

        if (timer < param.LV_showTextTime+40)
        {
            timer += Time.deltaTime;
            //levelText.text = ("Level 1");
            //shootSphereEnemyN(3);
            shootItemEnemyS(3);
=======
        if (Rose.gameover)
        {
            levelScroll.SetActive(true);
            levelText.text = "Game Over!";
        }
        if (timer < param.LV_showTextTime)
        {
            timer += Time.deltaTime;
            levelText.text = ("Level 1");
>>>>>>> 16f6718cb9e667bd846482d652550db896968bac
            
        }
        ////MODE1: spaceships are static, shoot only one type per each.
        //else if (timer < param.LV_showTextTime+ 10) 
        //{   
        //    timer += Time.deltaTime;
        //    shootBasicEnemyN(1.0f);
        //    shootBasicEnemyS(1.0f);
        //    shootItemEnemyN(3.0f);
        //    shootItemEnemyS(3.0f);
        //}
        ////MODE2: spaceships are moving, shoot only one type per each.
        //else if (timer < param.LV_showTextTime + 20)
        //{
        //    timer += Time.deltaTime;
        //    MoveSpaceShipRed(2.0f, 8);
        //    MoveSpaceShipBlue(2.0f, 8);
        //    shootBasicEnemyN(1.0f);
        //    shootBasicEnemyS(1.0f);
        //    shootItemEnemyN(3.0f);
        //    shootItemEnemyS(3.0f);

<<<<<<< HEAD
        //}
        ////MODE3: spaceships are moving, faster
        //else if (timer < param.LV_showTextTime + 30)
=======
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
>>>>>>> 16f6718cb9e667bd846482d652550db896968bac
        //{
        //    timer += Time.deltaTime;
        //    MoveSpaceShipRed(2.0f, 10);
        //    MoveSpaceShipBlue(2.0f, 10);
        //    shootBasicEnemyN(0.5f);
        //    shootBasicEnemyS(0.5f);
        //    shootItemEnemyN(3.0f);
        //    shootItemEnemyS(3.0f);
        //    shootSphereEnemyN(3.0f);
        //    shootSphereEnemyS(3.0f);
        //    shootWormEnemyN(3.0f);
        //    shootWormEnemyS(3.0f);

        //}
        ////MODE4: becoming harder
        //else if (timer < param.LV_showTextTime + 50)
        //{
        //    timer += Time.deltaTime;
        //    MoveSpaceShipRed(2.0f, 10);
        //    MoveSpaceShipBlue(2.0f, 10);
        //    shootBasicEnemyN(0.5f);
        //    shootBasicEnemyS(0.5f);
        //    shootItemEnemyN(3.0f);
        //    shootItemEnemyS(3.0f);
        //    shootSphereEnemyN(3.0f);
        //    shootSphereEnemyS(3.0f);
        //    shootWormEnemyN(3.0f);
        //    shootWormEnemyS(3.0f);

        //}
        else 
        {
            //todo: set parameters or not
            SceneManager.LoadScene("Level2");
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
            velChangeItvRed = Random.Range(timeInterval * 0.5f, timeInterval * 1.5f);

            float randX = Random.Range(-15.0f, 15.0f);
            float randY = Random.Range(10.0f, 30.0f);
            spaceshipRed.GetComponent<Rigidbody>().velocity = speed*(new Vector3(randX - spaceshipRed.transform.position.x, randY - spaceshipRed.transform.position.y, 0)).normalized;
            spaceshipRed.transform.LookAt(rose.transform.position);
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
            velChangeItvBlue = Random.Range(timeInterval * 0.5f, timeInterval * 1.5f);

            float randX = Random.Range(-15.0f, 15.0f);
            float randY = Random.Range(10.0f, 30.0f);
            spaceshipBlue.GetComponent<Rigidbody>().velocity = speed*(new Vector3(randX - spaceshipRed.transform.position.x, randY - spaceshipRed.transform.position.y, 0)).normalized;
            spaceshipRed.transform.LookAt(rose.transform.position);
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
            basicEtimerN  += Time.deltaTime;
        }
    }

    private float basicEtimerS = 0.0f;
    private float basicEtimeItvS = 0.0f;

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

    /* Worm Enemy ------------------------------------------------------------------------------*/

    private float wormEtimerN = 0.0f;
    private float wormEtimeItvN = 0.0f;

    public void shootWormEnemyN(float timeInterval)
    {
        if (wormEtimerN >= wormEtimeItvN)
        {
            wormEtimerN = 0.0f;
            wormEtimeItvN = Random.Range(timeInterval * 0.5f, timeInterval * 1.5f);
            enemyGeneratorRed.shootWormEnemy();
        }
        else
        {
            wormEtimerN += Time.deltaTime;
        }
    }

    private float wormEtimerS = 0.0f;
    private float wormEtimeItvS = 0.0f;

    public void shootWormEnemyS(float timeInterval)
    {
        if (wormEtimerS >= wormEtimeItvS)
        {
            wormEtimerS = 0.0f;
            wormEtimeItvS = Random.Range(timeInterval * 0.5f, timeInterval * 1.5f);
            enemyGeneratorBlue.shootWormEnemy();
        }
        else
        {
            wormEtimerS += Time.deltaTime;
        }
    }

}
