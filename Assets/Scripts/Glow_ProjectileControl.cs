using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Glow_ProjectileControl : MonoBehaviour
{
    #region Bullet Variables
    public GameObject[] glowProjectiles;
    public static int curProjNum = 1;
    [SerializeField]Rigidbody2D rb;
    [SerializeField]float speed;
    Transform player;
    #endregion

    [SerializeField]Glow glow;
    public Light2D glowLight;
    public bool isShot;
    public bool oneShot = false;

    [SerializeField]Color[] diffGlowColors;
    
    private void OnEnable() {
        glowProjectiles[curProjNum].GetComponent<FollowMouse>().enabled = true;//turns on follow mouse script
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();//finds the player through its tag
        glow = GameObject.FindGameObjectWithTag("Player").GetComponent<Glow>();//Finds the script in playe called Glow
        rb = glowProjectiles[curProjNum].GetComponent<Rigidbody2D>();//finds its childs rigidbody2D
        glowLight = GetComponent<Light2D>();//finds Light2D script
    }

    void Update()
    {
        
        if (isShot)
        {
            print("isshot is on");
        }
        #region Glow bool
        if (Glow.isGlowActive)//Checks if glow is on, if so then activate the glow arrow plus the light it emits
        {
            glowProjectiles[curProjNum].SetActive(true);
            glowLight.enabled = true;
            print("Glow is on");
        }
        else
        {
            glowProjectiles[curProjNum].SetActive(false);
            glowLight.enabled = false;
            isShot = false;
            oneShot = false;   
            PlayerMovement.isPossessing = false;
        }

        if (PlayerMovement.isPossessing)
        {
            glowProjectiles[curProjNum].SetActive(false);
        }
        #endregion


        #region arrowKeys
        //Change to shift to change glow - Made it where it can only be switched when the arrow has not been shot and glow is active
        //Changed to remove plant growth
        if (Glow.isGlowActive && !isShot)
        {

            glowLight.color = diffGlowColors[curProjNum];
            
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                glowProjectiles[curProjNum].SetActive(false);
                if (curProjNum < 1)
                {
                    curProjNum += 1;
                }   
                else
                {
                    curProjNum = 0;
                }
                
                ReloadBullet();
            }
            
        }
        #endregion

        

        if (Glow.isGlowActive && Input.GetKeyDown(KeyCode.Mouse0))//The player is able to shoot when glow is on and the left mouse button is clicked
        {
            Shooting();
        }
    }

    void Shooting()
    {
        isShot = true;//turns is shot on
        
        if (!oneShot)//Checks to see if the player shot once 
        {
            rb.AddForce(glowProjectiles[curProjNum].transform.up * speed, ForceMode2D.Impulse);//Shoots the bullet in the direction its facing multiplied by speed
            glowProjectiles[curProjNum].GetComponent<FollowMouse>().enabled = false;//Turns followmouse script off
            oneShot = true;
        }
    }

    public void ReloadBullet()
    {
        glowProjectiles[curProjNum].SetActive(false);
        //glowProjectiles[curProjNum].transform.position = transform.position;
        rb = glowProjectiles[curProjNum].GetComponent<Rigidbody2D>();
        glowProjectiles[curProjNum].SetActive(true);
        isShot = false;
        oneShot = false;
        
    }
}
