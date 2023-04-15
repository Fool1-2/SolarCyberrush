using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisionScript : MonoBehaviour
{
    public Collider2D[] ignoredCollider;//The object the collider ignores
    
    private void FixedUpdate() {
        foreach (Collider2D ignorecol in ignoredCollider)
        {
            Physics2D.IgnoreCollision(ignorecol, GetComponent<Collider2D>());
        }
    }
}

    
