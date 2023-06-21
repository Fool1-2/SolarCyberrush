using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractPipe : MonoBehaviour, IInteractableScript
{
    public float interactArea;
    public UnityEvent interactEvent;
    Collider2D col;
    public bool isplayerNear;
    public LayerMask objectToInteract;

    public GameObject player;//The pipe player not the real one
    public GameObject actualPlayer;

    private void Update() {

        if (player.activeInHierarchy)
        {
            actualPlayer.SetActive(false);
        }
        else
        {
            actualPlayer.SetActive(true);
        }

        if (isplayerNear)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton2) && !SGameManager.isPlayerBallOut)
            {
                if (Glow.isGlowActive && Glow.glowType == 0)
                {
                    SGameManager.isPlayerBallOut = true;
                    player.SetActive(true);
                }
            }
        }
        
    }

    private void FixedUpdate() {
        col = Physics2D.OverlapCircle(transform.position, interactArea, objectToInteract);

        if (col != null)
        {
            isplayerNear = true;
        }
        else
        {
            isplayerNear = false;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, interactArea);
    }

    public void Interact()
    {
        if (!SGameManager.isPlayerBallOut)
        {
            SGameManager.isPlayerBallOut = true;
            player.SetActive(true);
        }
    }


}

