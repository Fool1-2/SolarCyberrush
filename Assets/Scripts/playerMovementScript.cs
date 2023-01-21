using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementScript : MonoBehaviour
{
    //Movement variables
    public Rigidbody2D rb;
    float speed = 10;
    public bool canJump = true;
    public float jumpSpeed;
    public Vector3 vector3;

    public static bool notPoss = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) && canJump && notPoss)
        {
            canJump = false;
            //rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed * 1);
            //rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
            //transform.position = transform.position + new Vector3(0, jumpSpeed * Time.deltaTime, 0);
            //rb.AddForce(Vector3.up * jumpSpeed, ForceMode2D.Impulse);

        }
    }
    private void FixedUpdate()
    {
        HorMovement();
        //Hard fix to lower velocity for jump
        rb.velocity = rb.velocity * .85f;
        if (rb.velocity.y <= 0.01f)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }
    void HorMovement()
    {
        //Horizontal Movement
        float x = Input.GetAxisRaw("Horizontal");
        Vector2 moveDir = new Vector2(x, (rb.velocity.y));
        rb.MovePosition(rb.position + moveDir * speed * Time.fixedDeltaTime);
    }
    //Some floors are triggers and some are collisions
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the floor is made of floor, you can jump (So wall and side jumps arent a thing)
        if (collision.gameObject.tag == "Floor")
        {
            canJump = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If the floor is made of floor, you can jump (So wall and side jumps arent a thing)
        if (collision.gameObject.tag == "Floor")
        {
            canJump = true;
        }
    }
}
