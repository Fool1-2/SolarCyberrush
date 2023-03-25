using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Glow_ProjectileControl : MonoBehaviour
{
    #region Bullet Variables
    public List<GameObject> glowProjectiles;
    public static int curProjNum = 1;
    [SerializeField] GameObject currentGlowBullet;
    [SerializeField]Rigidbody2D rb;
    [SerializeField]float speed;
    Transform player;
    Vector3 setScaleForBullet = new Vector3(1, 1, 1);
    #endregion

    [SerializeField]Glow glow;
    public Light2D glowLight;
    public static bool isShot;
    bool oneShot = false;
    [SerializeField]Color[] diffGlowColors;
    
    private void OnEnable() {
        AutoReloadBullet();
        //currentGlowBullet = transform.GetChild(0).gameObject;//When the script starts finds the controllers child and makes that the current bullet
        currentGlowBullet.GetComponent<FollowMouse>().enabled = true;//turns on follow mouse script
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();//finds the player through its tag
        glow = GameObject.FindGameObjectWithTag("Player").GetComponent<Glow>();//Finds the script in playe called Glow
        rb = transform.GetChild(0).gameObject.GetComponent<Rigidbody2D>();//finds its childs rigidbody2D
        glowLight = GetComponent<Light2D>();//finds Light2D script
    }

    public void AutoReloadBullet()
    {

        Destroy(currentGlowBullet);
        currentGlowBullet = Instantiate(glowProjectiles[curProjNum], (Vector2)transform.position, Quaternion.identity);//Spawn a new bullet replacing the old bullet
        currentGlowBullet.transform.parent = gameObject.transform;//Puts the bullet under the controller as a child
        currentGlowBullet.transform.localScale = setScaleForBullet;//Fixes the scaling of the bullet
        oneShot = false;
        isShot = false;//turns isshot back off
    }
    
    void Update()
    {
        currentGlowBullet = transform.GetChild(0).gameObject;

        #region Glow bool
        if (Glow.isGlowActive)//Checks if the glow ability has changed and turns on the projectile
        {
            currentGlowBullet.SetActive(true);
            glowLight.enabled = true;
        }
        else
        {
            currentGlowBullet.SetActive(false);
            glowLight.enabled = false;
        }

        if (PlayerMovement.isPossessing)
        {
            currentGlowBullet.SetActive(false);
        }
        #endregion

        #region arrowKeys
        //Change to shift to change glow - Made it where it can only be switched when the arrow has not been shot and glow is active
        //Changed to remove plant growth
        if (Glow.isGlowActive && !isShot)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                glowLight.color = diffGlowColors[curProjNum];
                AutoReloadBullet();
            }
        }


        #endregion

        if (!isShot)
        {
            currentGlowBullet.transform.position = player.position;//sets the bullets position on the players position
            rb = currentGlowBullet.GetComponent<Rigidbody2D>();//Finds the rigidbody when the bullet isn't shot.
        }

        if (Glow.isGlowActive && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shooting();
        }
    }

    void Shooting()
    {
        isShot = true;//turns is shot on
        if(!oneShot) 
        {
            rb.AddForce(currentGlowBullet.transform.up * speed, ForceMode2D.Impulse);//Shoots the bullet in the direction its facing multiplied by speed
            oneShot = true;
        }
        currentGlowBullet.GetComponent<FollowMouse>().enabled = false;//Turns followmouse script off
        StartCoroutine(respawnItem(3f));//starts the respawn function
    }

    public IEnumerator respawnItem(float time)//Customizable time for respawn
    {
        yield return new WaitForSeconds(time);//Wait for a certain amount of time
        Destroy(currentGlowBullet);//Destroy the object that was shot
        currentGlowBullet = Instantiate(glowProjectiles[curProjNum], (Vector2)transform.position, Quaternion.identity);//Spawn a new bullet replacing the old bullet
        currentGlowBullet.transform.parent = gameObject.transform;//Puts the bullet under the controller as a child
        currentGlowBullet.transform.localScale = setScaleForBullet;//Fixes the scaling of the bullet
        oneShot = false;
        isShot = false;//turns isshot back off
    }
}
