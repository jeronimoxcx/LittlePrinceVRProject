using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rose : MonoBehaviour {
    public TextMesh roseHp; // = new TextMesh();
    public int healthPoint = 20;
    public GameObject particleEffect;

    public bool gameover = false;

    private void Start()
    {

        roseHp.text = "hp : " + healthPoint;
        //roseHp = gameObject.AddComponent<TextMesh>();
    }


    private void OnCollisionEnter(Collision collision)
    {

        Instantiate(particleEffect,collision.contacts[0].point, Quaternion.identity);

        collision.gameObject.SetActive(false);

        //Debug.Log(collision.gameObject.name);
        healthPoint--;
        if (gameover) return;
       
        if (healthPoint <= 0)
        {
            roseHp.text = "I'm Dead you moron!";
            gameover = true;
        }
        else
        {
            roseHp.text = "hp : " + healthPoint;
        }
    }
}
