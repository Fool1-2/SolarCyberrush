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
            if (Input.GetKeyDown(KeyCode.E) && !SGameManager.isPlayerBallOut)
            {
                SGameManager.isPlayerBallOut = true;
                player.SetActive(true);
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
        print("Test, this is from the pipe");
    }


}

