using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecieveMagneticForce : MonoBehaviour {

    private float disabletime;
    private int disable_active = 0;

    private float glowtime;
    private int glowtimer = 0;

    private float slowtime;
    private int slowtimer = 0;
        
    private int followmode = 0;
    private GameObject followobj;
    
    private string showtext;
    private TextMesh textMesh;

    public GameObject GlowEffect;
    public int M_force;
    public GameObject text;
    
    
	// Use this for initialization
	void Start () {
        showtext = M_force.ToString();
        textMesh = text.GetComponent(typeof(TextMesh)) as TextMesh;
        textMesh.text = showtext;
    }
	
	// Update is called once per frame
	void Update () {
        if (disabletime < Time.time && disable_active == 1)
            disable_self();
        
        if (followmode==1)
        {
            if (!followobj.activeSelf)
               disable_self();
            
            gameObject.GetComponent<Rigidbody>().velocity =
                (followobj.transform.position - gameObject.transform.position);
        }
        else if(slowtimer == 1 && slowtime < Time.time)
        {
            slowtimer = 0;
            gameObject.GetComponent<Rigidbody>().velocity *= 5.0F;
        }

        if (glowtimer == 1 && glowtime < Time.time)
        {
            GlowOff();
            glowtimer = 0;
        }

        


    }

    void Follow(GameObject Attack)
    {
        if (followmode == 0)
        {
            disabletime = Time.time + 3.0F;
            disable_active = 1;
            followmode = 1;
            followobj = Attack;
            //Debug.Log("Message Received");
            Glow();
            float starttime = Time.time;
        }
    }

    void Away(GameObject Attack)
    {
        gameObject.GetComponent<Rigidbody>().velocity = (gameObject.transform.position - Attack.transform.position);
        glowtimer = 1;
        glowtime = Time.time + 3.0F;
        
        Glow();

    }

    void disable_self()
    {
        GlowOff();
        followmode = 0;
        gameObject.SetActive(false);
        disable_active = 0;
    }

    void Glow()
    {
        GlowEffect.SetActive(true);
        textMesh.gameObject.SetActive(false);
    }

    void GlowOff()
    {
        GlowEffect.SetActive(false);
        textMesh.gameObject.SetActive(true);
    }
    
    void Slowdown()
    {
        slowtime = Time.time + 5.0F;
        slowtimer = 1;
        gameObject.GetComponent<Rigidbody>().velocity *= 0.2F;
    }

}
