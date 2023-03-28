using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Glow_ProjectileControl : MonoBehaviour
{
    #region Bullet Variables
    public List<GameObject> glowProjectiles;
    public static int curProjNum = 1;
    [SerializeField]Rigidbody2D rb;
    [SerializeField]float speed;
    Transform player;
    #endregion

    [SerializeField]Glow glow;
    public Light2D glowLight;
    public bool isShot;
    public bool oneShot = false;
    private bool canBulletReload;

    [SerializeField]Color[] diffGlowColors;
    
    private void OnEnable() {
        glowProjectiles[curProjNum].GetComponent<FollowMouse>().enabled = true;//turns on follow mouse script
        respawnItem(.1f);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();//finds the player through its tag
        glow = GameObject.FindGameObjectWithTag("Player").GetComponent<Glow>();//Finds the script in playe called Glow
        rb = glowProjectiles[curProjNum].GetComponent<Rigidbody2D>();//finds its childs rigidbody2D
        glowLight = GetComponent<Light2D>();//finds Light2D script
    }

    void Update()
    {

        #region Glow bool
        if (Glow.isGlowActive)//Checks if glow is on, if so then activate the glow arrow plus the light it emits
        {
            glowProjectiles[curProjNum].SetActive(true);
            glowLight.enabled = true;
        }
        else
        {
            respawnItem(0);
            //glowProjectiles[curProjNum].SetActive(false);
            glowLight.enabled = false;
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
                /*
                if (curProjNum < 0)
                {
                    curProjNum += 1;
                }   
                else
                {
                    curProjNum = 0;
                }
                */
                respawnItem(.1f);
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
            respawnItem(3f);
            oneShot = true;
        }
        
    }

    public void respawnItem(float time)
    {
        canBulletReload = true;//the bullet is now able to reload
        if (canBulletReload)
        {
            float reloadTimer = 0f;//restarts the timer
            reloadTimer += Time.deltaTime;//equals it to time.delta
            if (reloadTimer >= time)
            {
                rb = glowProjectiles[curProjNum].GetComponent<Rigidbody2D>();//gets the current bullets rigidbody
                glowProjectiles[curProjNum].SetActive(false);//turns it off
                //glowProjectiles[curProjNum].transform.position = transform.position;//resets the position
                if (Glow.isGlowActive)
                {
                    glowProjectiles[curProjNum].SetActive(true);//turns it back on
                }
                glowProjectiles[curProjNum].GetComponent<FollowMouse>().enabled = true;
                oneShot = false;
                isShot = false;
                canBulletReload = false;
            }
        }
    }

    
}
