using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractScript : MonoBehaviour
{
    public float interactArea;
    public UnityEvent interactEvent;
    Collider2D col;
    public bool isplayerNear;
    public LayerMask objectToInteract;

    private void Update() {

        if (isplayerNear)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                interactEvent.Invoke();
                GameObject.FindGameObjectWithTag("Player").SetActive(false);
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


}
