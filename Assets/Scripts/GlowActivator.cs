using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowActivator : MonoBehaviour
{
    public Glow_ProjectileControl glowProjectile;
    public BoxCollider2D bc;
    GameObject[] camBoxCollider;

    private void Start() {
        camBoxCollider = GameObject.FindGameObjectsWithTag("CamSwitcher");//finds all the gameObjects that have the tag Camswitcher
        foreach (GameObject col in camBoxCollider)
        {
            Physics2D.IgnoreCollision(col.GetComponent<BoxCollider2D>(), GetComponent<Collider2D>());//ignores all the gameObjects collison with the tag CamSwitcher
        }
    }

    private void OnEnable() {
        glowProjectile = GameObject.FindGameObjectWithTag("ProjectileController").GetComponent<Glow_ProjectileControl>();
        bc = gameObject.GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (Glow_ProjectileControl.isShot != true)
        {
            bc.enabled = false;
        }
        else
        {
            bc.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        //Checks this is a tele arrow and other object is a teleob
        if (Glow_ProjectileControl.isShot)
        {
            if (other.gameObject.tag == "TeleObj" && gameObject.tag == "Telekinesis")
            {
                if (Glow_ProjectileControl.isShot)
                {
                    glowProjectile.AutoReloadBullet();
                    Glow.currentPossessedObj = other.gameObject;
                    Glow.currentPossessedObj.GetComponent<TeleObj>().isPoss = true;
                    PlayerMovement.isPossessing = true;
                    //The dumbest way to add .1 to the y of the colliding object so that it isnt touching the floor
                    Transform hi = other.gameObject.GetComponent<Transform>();
                    hi.position += new Vector3(0, 0.5f, 0);
                    other.gameObject.GetComponent<Transform>().position = hi.position;
                }
            }
            //Check the other gameObject is a light ob and this is the light glow arrow
            else if (other.gameObject.tag == "LightObj" && gameObject.tag == "Light")
            {
                other.gameObject.GetComponent<ILightAbility>().ActivatePower();
                glowProjectile.AutoReloadBullet();
            }
            //Add something so that object is destroyed on all collisions so that it cannot go through walls
            else if (Glow_ProjectileControl.isShot)
            {
                //Test this
                glowProjectile.AutoReloadBullet();
            }
        }
    }
}
