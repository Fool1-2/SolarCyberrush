using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontal;
    public float speed;
    public float jumpPower;
    [SerializeField]private Rigidbody2D rb;
    [SerializeField]private Transform groundCheck;
    [SerializeField]private LayerMask groundLayer;
    [SerializeField]private float groundCheckNum;
    public static bool isPossessing;
    public float possessedrangeNum;
    public LayerMask possessedLayer;

    private void Start() {
        
        rb = GetComponent<Rigidbody2D>();
        if (!GrateScript.slidePuzzleCompleted)
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            GrateScript.slidePuzzleCompleted = true;
        }
        rb.bodyType = RigidbodyType2D.Dynamic;
        if (!Glow.isGlowActive)
        {
            horizontal = Input.GetAxisRaw("Horizontal");//Gets the keys from the Input manager. Horizontal = left and right
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded())//checks if player has pressed space and is on the ground before jumping
            {   
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            }
        }
        else
        {
            rb.velocity = new Vector2(0,-1);
            rb.inertia = 0;
        }

        if (Glow.currentPossessedObj != null)//Makes sure to check only if an object is possessed(Stops a error popping up)
        {
            if (Glow.currentPossessedObj.GetComponent<TeleObj>().isPoss)//if the current possessedObj isPoss bool on then it will trun on isPossessing
            {
                isPossessing = true;
            }
            else
            {
                isPossessing = false;
            }
        }

    }

    private void FixedUpdate()
    {
        if (!isPossessing && !Glow.isGlowActive)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);//Moves the player by multiplying it by 
        }

        //Collider2D inRange = Physics2D.OverlapCircle(transform.position, possessedrangeNum, possessedLayer);

    }
    
    bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckNum, groundLayer);//returns true if the groundCheck is touching the layer mask groundLayer
    }

    private void OnDrawGizmos() 
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckNum);//Shows the outline of it in scene
        //Gizmos.DrawWireSphere(transform.position, possessedrangeNum);
    }
}
