using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GlowActivator : MonoBehaviour
{
    public Glow_ProjectileControl glowProjectile;
    public Collider2D bc;
    [SerializeField]GameObject[] camBoxCollider;
    public float bulletTimer;

    private void Start() {
        camBoxCollider = GameObject.FindGameObjectsWithTag("CamSwitcher");//finds all the gameObjects that have the tag Camswitcher
    }

    private void OnEnable() {
        foreach (GameObject col in camBoxCollider)
        {
            Physics2D.IgnoreCollision(col.GetComponent<Collider2D>(), GetComponent<Collider2D>());//ignores all the gameObjects collison with the tag CamSwitcher
        }
        bulletTimer = 0f;
        glowProjectile = GameObject.FindGameObjectWithTag("ProjectileController").GetComponent<Glow_ProjectileControl>();
        bc = gameObject.GetComponent<Collider2D>();
        GetComponent<FollowMouse>().enabled = true;
        
    }
    private void OnDisable() {
        this.transform.position = glowProjectile.gameObject.transform.position;
    }
    private void Update()
    {   
        if (glowProjectile.isShot)
        {
            bulletTimer += Time.deltaTime;
            if (bulletTimer >= 3f)
            {
                glowProjectile.ReloadBullet();
            }
        }

        if (!glowProjectile.isShot)
        {
            bc.enabled = false;
            transform.position = glowProjectile.transform.position;
        }
        else
        {
            bc.enabled = true;
        }
    }

    

    private void OnTriggerEnter2D(Collider2D other) {
        //Checks this is a tele arrow and other object is a teleob   
        if (glowProjectile.isShot)
        {
            if (other.gameObject.tag == "TeleObj" && gameObject.tag == "Telekinesis")
            {
                Glow.currentPossessedObj = other.gameObject;
                Glow.currentPossessedObj.GetComponent<TeleObj>().isPoss = true;
                PlayerMovement.isPossessing = true;
                //The dumbest way to add .1 to the y of the colliding object so that it isnt touching the floor
                Transform hi = other.gameObject.GetComponent<Transform>();
                hi.position += new Vector3(0, 0.5f, 0);
                other.gameObject.GetComponent<Transform>().position = hi.position;
                glowProjectile.ReloadBullet();
            }
            //Check the other gameObject is a light ob and this is the light glow arrow
            else if (this.gameObject.tag == "Light")
            {
                
                var lightObj = other.gameObject.GetComponent<ILightAbility>();
                lightObj.ActivatePower();
                glowProjectile.ReloadBullet();
            }
        }

        glowProjectile.ReloadBullet();
    }
}
