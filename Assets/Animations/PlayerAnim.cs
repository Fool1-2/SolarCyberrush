using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Transform playerPosition;
    private Animator anim;

    public static bool playerFall;
    [SerializeField]private AnimationClip fallAnimation;
    private IEnumerator _fallFunc;


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
        anim.SetBool("IsJumping", playerMovement.isGrounded());
        if (!Glow.isGlowActive) 
        { 
            anim.SetInteger("XInput", (int)playerMovement.horizontal);
        }

        if (fallAnimation != null)
        {
            if (playerFall)
            {
                _fallFunc = PlayerFallAnimation(fallAnimation.length);
                StartCoroutine(_fallFunc);
            }
            else
            {
                if(_fallFunc != null) {StopCoroutine(_fallFunc);}
            }
        }
        else
        {
            return;
        }
        
        
    }

    IEnumerator PlayerFallAnimation(float FallTime)
    {
        anim.SetBool("PlayerFall", true);
        PlayerMovement.canPlayerInteract = false;
        PlayerMovement.canMove = false;
        yield return new WaitForSeconds(FallTime);
        anim.SetBool("PlayerFall", false);
        PlayerMovement.canPlayerInteract = true;
        PlayerMovement.canMove = true;
        playerFall = false;
    }

    
}
