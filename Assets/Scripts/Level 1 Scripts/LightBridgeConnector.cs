using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBridgeConnector : MonoBehaviour, ILightAbility
{
    [HideInInspector]public bool isActivated;
    private float activatedTimer;
    [Range(0, 20)]
    [SerializeField]private float activatedTimerEnd;
    Glow glow;
    SpriteRenderer spriteRenderer;
    [SerializeField]Sprite originalSprite, activatedSprite;


    // Start is called before the first frame update
    void Start()
    {
        glow = GameObject.FindGameObjectWithTag("Player").GetComponent<Glow>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActivated)
        {
            spriteRenderer.sprite = activatedSprite;
        }
        else
        {
            spriteRenderer.sprite = originalSprite;
        }

        if (isActivated && !glow.isConnected)
        {
            activatedTimer += Time.deltaTime;
            if (activatedTimer >= activatedTimerEnd)
            {
                //Checks which lightconnector it is and turns it null
                if(glow.lightCon1 == this.gameObject.transform){glow.lightCon1 = null;}
                if(glow.lightCon2 == this.gameObject.transform){glow.lightCon2 = null;}
                isActivated = false;
            }
        }
        else
        {
            activatedTimer = 0;
        }
    }

    public void ActivatePower()
    {
        if (!isActivated)
        {
            if (glow.lightCon1 == null)
            {
                glow.lightCon1 = this.gameObject.transform;
                isActivated = true;
                //return;
            }
            else if (glow.lightCon2 == null)
            {
                glow.lightCon2 = this.gameObject.transform;
                isActivated = true;
                //return;
            }
            else
            {
                return;
            }
        }

        

        
    }

}
