using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    [SerializeField] Transform armTransform;
    [SerializeField]float maxRot;
    SpriteRenderer playerSpriteRend;
    SpriteRenderer armSpriteRenderer;
    private void Start()
    {
        armTransform = gameObject.GetComponentInChildren<Transform>();
        armSpriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        playerSpriteRend = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();

    }
    // Update is called once per frame
    void Update()
    {
        //Works for right
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        mousePos.Normalize();
        float rotation_Z = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        float clampPos = Mathf.Clamp(rotation_Z, -maxRot, maxRot);
        //clampPos -= 180;

        if (rotation_Z >= 90 || rotation_Z <= -90)
        {
            armSpriteRenderer.flipX = true;
            
        }
        else
        {
            armSpriteRenderer.flipX = true;
            
        }

        transform.rotation = Quaternion.Euler(0, 0, clampPos);
        //flipX false is facing left

    }
}
