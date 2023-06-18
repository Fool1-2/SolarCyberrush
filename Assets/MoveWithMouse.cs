using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithMouse : MonoBehaviour
{
    SpriteRenderer spriteR;
    

    private void Start() {
        spriteR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Glow.isGlowActive)
        {
            spriteR.enabled = true;
            Vector2 mouseMovement = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mouseMovement;
        }
        else
        {
            spriteR.enabled = false;
        }
    }
}
