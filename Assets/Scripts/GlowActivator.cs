using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowActivator : MonoBehaviour
{
    public Glow_ProjectileControl glowProjectile;

    private void OnEnable() {
        glowProjectile = GameObject.FindGameObjectWithTag("ProjectileController").GetComponent<Glow_ProjectileControl>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        //Checks this is a tele arrow and other object is a teleob
        if (other.gameObject.tag == "TeleObj" && gameObject.tag == "Telekinesis")
        {
            if (Glow_ProjectileControl.isShot)
            {
                glowProjectile.AutoReloadBullet();
                Glow.currentPossessedObj = other.gameObject;
                Glow.currentPossessedObj.GetComponent<TeleObj>().isPoss = true;
                PlayerMovement.isPossessing = true;
            }
        }
        //Check the other gameObject is a light ob and this is the light glow arrow
        if (other.gameObject.tag == "LightObj" && gameObject.tag == "Light")
        {
            other.gameObject.GetComponent<ILightAbility>().ActivatePower();
            glowProjectile.AutoReloadBullet();
        }
    }
}
