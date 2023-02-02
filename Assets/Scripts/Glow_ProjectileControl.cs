using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Glow_ProjectileControl : MonoBehaviour
{
    #region Bullet Variables
    public List<GameObject> glowProjectiles;
    public int curProjNum;
    [SerializeField] GameObject currentGlowBullet;
    [SerializeField]Rigidbody2D rb;
    [SerializeField]float speed;
    Transform player;
    Vector3 setScaleForBullet = new Vector3(3, 8, 7);
    #endregion

    [SerializeField]Glow glow;
    public Light2D glowLight;
    public static bool isShot;
    [SerializeField]Color[] diffGlowColors;

    private void OnEnable() {
        AutoReloadBullet();
        currentGlowBullet = transform.GetChild(0).gameObject;//When the script starts finds the controllers child and makes that the current bullet
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
        isShot = false;//turns isshot back off
    }
    
    void Update()
    {
        #region Glow bool
        if (Glow.isGlowActive)//Checks if the glow ability has changed and turns on the projectile
        {
            currentGlowBullet.SetActive(true);
            glowLight.enabled = true;
            /*switch (glow.glowAB)
            {
                
                case Glow.glowAbility.Light:
                    curProjNum = 0;
                    glowLight.color = diffGlowColors[0];
                    break;
                case Glow.glowAbility.Telekinesis:
                    curProjNum = 1;
                    glowLight.color = diffGlowColors[1];
                    break;
                case Glow.glowAbility.Growth:
                    curProjNum = 2;
                    glowLight.color = diffGlowColors[2];
                    break;
            }*/
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

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (curProjNum > 0)
            {
                curProjNum -= 1;
            }
            else
            {
                curProjNum = 2;
            }
            glowLight.color = diffGlowColors[curProjNum];
            AutoReloadBullet();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (curProjNum < 2)
            {
                curProjNum += 1;
            }
            else
            {
                curProjNum = 0;
            }
            glowLight.color = diffGlowColors[curProjNum];
            AutoReloadBullet();
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
        rb.AddForce(currentGlowBullet.transform.up * speed, ForceMode2D.Impulse);//Shoots the bullet in the direction its facing multiplied by speed
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
        isShot = false;//turns isshot back off
    }
}
