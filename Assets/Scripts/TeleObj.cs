using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class TeleObj : MonoBehaviour
{
    public bool isPoss;
    float horizontal;
    float vertical;
    [SerializeField]float speed;
    [SerializeField]Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (this.gameObject != Glow.currentPossessedObj)
        {
            isPoss = false;          
        }
    }

    private void FixedUpdate()
    {
        PossessionMovement(isPoss);
    }

    void PossessionMovement(bool isPoss)
    {
        
        if (isPoss)
        {
            rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
