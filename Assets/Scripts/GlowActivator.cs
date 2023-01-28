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
        
        if (other.gameObject.tag == "TeleObj")
        {
            if (Glow_ProjectileControl.isShot)
            {
                glowProjectile.AutoReloadBullet();
                Glow.currentPossessedObj = other.gameObject;
                Glow.currentPossessedObj.GetComponent<TeleObj>().isPoss = true;
                PlayerMovement.isPossessing = true;
            }
        }

        if (other.gameObject.tag == "LightObj")
        {
            other.gameObject.GetComponent<ILightAbility>().ActivatePower();
            glowProjectile.AutoReloadBullet();
        }
    }
}
