using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private float horizontal;
    public float speed;
    public float jumpPower;
    public Rigidbody2D rb;
    public Transform groundCheck;
    public float groundCheckNum;
    public LayerMask groundMask;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

    }

    bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckNum, groundMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckNum);
    }
}
