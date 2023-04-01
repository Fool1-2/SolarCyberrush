using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gamemanager = GameManagerScript;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector]public float horizontal;
    public float speed;
    public float jumpPower;
    private bool jumped;
    [SerializeField]private Rigidbody2D rb;
    [SerializeField]private Transform groundCheck;
    [SerializeField]private LayerMask groundLayer;
    [SerializeField]private float groundCheckNum;
    public static bool isPossessing;
    public float possessedrangeNum;
    public LayerMask possessedLayer;
    public AudioSource playerJumpUpSound;
    //public AudioSource playerRunSound;
    public AudioSource playerRunSound;

    public AudioSource glowActivate;
    public AudioSource glowChangeSound;

    public bool running;

    private SpriteRenderer _renderer;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
     
        if (Input.GetKeyDown(KeyCode.M))
        {
            GrateScript.slidePuzzleCompleted = true;
        }


        //rb.bodyType = RigidbodyType2D.Dynamic;
        
        
        if (!Glow.isGlowActive)
        {

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                playerRunSound.Play();
            }
            //Seperating out the sound Not the same
            horizontal = Input.GetAxisRaw("Horizontal");//Gets the keys from the Input manager. Horizontal = left and right
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                if (horizontal > 0)
                {
                    _renderer.flipX = true;
                    
                }
                else if (horizontal < 0)
                {
                    _renderer.flipX = false;
                }
            }
            else
            {
                playerRunSound.Stop();                 
            }

            if (Input.GetKeyDown(KeyCode.W) && isGrounded())
            {
                jumped = true;
                playerJumpUpSound.Play();
            }


        }
        else
        {
            playerRunSound.Stop();
            rb.velocity = new Vector2(0,-1);
            rb.inertia = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space) && (Glow.isGlowActive))//Turns on glow when G is pressed
        {

            glowActivate.Play();

        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && (Glow.isGlowActive))//Turns on glow when G is pressed
        {

            glowChangeSound.Play();

        }
        if (Glow.currentPossessedObj != null)//Makes sure to check only if an object is possessed(Stops a error popping up)
        {

            glowActivate.Play();

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
        if (jumped)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumped = false;
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
