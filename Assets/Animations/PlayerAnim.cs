using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Animator anim;
    private bool onceOffset;
    private Transform playerPosition;
    private Vector3 offset = new Vector3(-1f, -1f, 0f);

    // Start is called before the first frame update
    private void OnEnable() {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
        playerPosition = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("IsGlow", Glow.isGlowActive);
        if (!Glow.isGlowActive) 
        { 
            anim.SetInteger("XInput", (int)playerMovement.horizontal);
            onceOffset = false;
        }
        
    }
}
