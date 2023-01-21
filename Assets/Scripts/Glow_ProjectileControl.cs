using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glow_ProjectileControl : MonoBehaviour
{
    
    public GameObject glowBullet;
    [SerializeField] GameObject currentGlowBullet;
    [SerializeField]Rigidbody2D rb;
    [SerializeField]float speed;
    [SerializeField]Transform player;
    [SerializeField]bool isShot;
    public List<GameObject> glowProjectiles;
    public int curProjNum;


    private void OnEnable() {
        AutoReloadBullet();
        currentGlowBullet = transform.GetChild(0).gameObject;//When the script starts finds the controllers child and makes that the current bullet
        currentGlowBullet.GetComponent<FollowMouse>().enabled = true;//turns on follow mouse script
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();//finds the player through its tag
    }
    void Update()
    {

        if (!isShot)
        {
            currentGlowBullet.transform.position = player.position;//sets the bullets position on the players position
            rb = currentGlowBullet.GetComponent<Rigidbody2D>();//Finds the rigidbody when the bullet isn't shot.
        }

        //Sets the current glowBullet to the selected glow

        if (Input.GetKeyDown(KeyCode.E))
        {
            Shooting();
        }
        //Sets glow and telekinesis objects to be fired
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            curProjNum = 0;
            StartCoroutine(respawnItem(1f));
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            curProjNum = 1;
            StartCoroutine(respawnItem(1f));
        }
    }

    void Shooting()
    {
        isShot = true;//turns is shot on
        rb.AddForce(currentGlowBullet.transform.up * speed, ForceMode2D.Impulse);//Shoots the bullet in the direction its facing multiplied by speed
        currentGlowBullet.GetComponent<FollowMouse>().enabled = false;//Turns followmouse script off
        StartCoroutine(respawnItem(3f));//starts the respawn function
    }

    IEnumerator respawnItem(float time)//Customizable time for respawn
    {
        yield return new WaitForSeconds(time);//Wait for a certain amount of time
        Destroy(currentGlowBullet);//Destroy the object that was shot
        currentGlowBullet = Instantiate(glowProjectiles[curProjNum], (Vector2)transform.position, Quaternion.identity);//Spawn a new bullet replacing the old bullet
        currentGlowBullet.transform.parent = gameObject.transform;//Puts the bullet under the controller as a child
        currentGlowBullet.transform.localScale = new Vector3(6, 8, 7);//Fixes the scaling of the bullet
        isShot = false;//turns isshot back off
    }

    void AutoReloadBullet()
    {
        currentGlowBullet = Instantiate(glowProjectiles[curProjNum], (Vector2)transform.position, Quaternion.identity);//Spawn a new bullet replacing the old bullet
        currentGlowBullet.transform.parent = gameObject.transform;//Puts the bullet under the controller as a child
        currentGlowBullet.transform.localScale = new Vector3(6, 8, 7);//Fixes the scaling of the bullet
        isShot = false;//turns isshot back off
    }
}
