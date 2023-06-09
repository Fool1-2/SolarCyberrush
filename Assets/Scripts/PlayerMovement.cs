using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gamemanager = GameManagerScript;

public class PlayerMovement : MonoBehaviour
{
    [Header("-----Movement-----")]
    #region Basic Movement Elements
    [HideInInspector]public float horizontal;
    public static bool canMove;
    public float speed;
    public float jumpPower;
    private bool jumped;
    public static bool isPaused;
    [SerializeField]private Rigidbody2D rb;
    public static bool playerflipped;
    #endregion

    [Header("-----GroundChecks-----")]
    #region groundChecks
    [SerializeField]private Transform groundCheck;
    [SerializeField]private LayerMask groundLayer;
    [SerializeField]private Vector2 groundVec;
    private float groundCheckNum;
    #endregion

    [Header("-----Telekensis-----")]
    #region telekensis
    public static bool isPossessing;
    public float possessedrangeNum;
    public LayerMask possessedLayer;
    #endregion

    [Header("-----PlayerSounds-----")]
    #region PlayerSounds
    public AudioSource playerJumpUpSound;
    public AudioSource playerRunSound;//public AudioSource playerRunSound;
    public AudioSource glowActivate;
    public AudioSource glowChangeSound;
    public AudioSource glowShootSound;
    #endregion

    [Header("-----Interact-----")]
    #region Interactables
    [SerializeField]private Vector2 interactArea;
    private float interactAreaNum;
    Collider2D interactCol;
    [SerializeField]LayerMask interactMask;
    #endregion

    private SpriteRenderer _renderer;
    
    private void OnEnable() {
        playerJumpUpSound = GameObject.Find("PlayerJumpSound").GetComponent<AudioSource>();
        playerRunSound = GameObject.Find("PlayerRunSound").GetComponent<AudioSource>();
        glowActivate = GameObject.Find("GlowActivateSound").GetComponent<AudioSource>();
        glowChangeSound = GameObject.Find("GlowChangeSound").GetComponent<AudioSource>();
    }

    private void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        canMove = true;
        isPaused = false;
        
    }
    // Update is called once per frame
    void Update()
    {


        if (interactCol != null)//checks if interactcol is equal to anything
        {
            var interactable = interactCol.GetComponent<IInteractableScript>();//equals the object to a variable
            if (interactable != null && Input.GetKeyDown(KeyCode.E))//checks again if its not null and if the player pressed E
            {
                interactable.Interact();//Activates the function
            }
        }

        if (Glow.isGlowActive && Input.GetKeyDown(KeyCode.Mouse0))
        {
            glowShootSound.Play();
            //Debug.Log("Left mouse button");
        }

        //controlls the turning of the player
        if (playerflipped)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);//flips the player and everything attached to the player as a child
        }
        else if (!playerflipped)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);//reverts it back to its original position
        }

        if (!Glow.isGlowActive && canMove && !isPaused)
        {

        if (!Glow.isGlowActive && canMove && !isPaused && InsideBuildingManagerScript.atSIA == false)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.None;
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                playerRunSound.Play();
            }

            //Seperating out the sound Not the same
            horizontal = Input.GetAxisRaw("Horizontal");//Gets the keys from the Input manager. Horizontal = left and right

            if (horizontal > 0)
            {
                playerflipped = true;
            }
            else if (horizontal < 0)
            {
                playerflipped = false;
            }

            if (horizontal == 0)
            {
                playerRunSound.Stop();
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
            {
                GetComponent<Animator>().Play("SolarCyberrushJumping");
                jumped = true;
                playerJumpUpSound.Play();
            }
        }
        else
        {
            playerRunSound.Stop();
            rb.velocity = new Vector2(0,0);
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            rb.inertia = 0;

        }

        if (Input.GetKeyDown(KeyCode.Q) && (Glow.isGlowActive))//Turns on glow when G is pressed
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
        interactCol = Physics2D.OverlapBox(transform.position, interactArea, interactAreaNum, interactMask);//Checks if the object has a collider + the layermask interactable

        if (!isPossessing && !Glow.isGlowActive)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);//Moves the player by multiplying it by
        }
        if (jumped)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumped = false;
        }
        
        
    }

    bool isGrounded()
    {
        return Physics2D.OverlapBox(groundCheck.position, groundVec, groundCheckNum, groundLayer);//returns true if the groundCheck is touching the layer mask groundLayer
    }


    private void OnDrawGizmos() 
    {
        Gizmos.DrawWireCube(groundCheck.position, groundVec);//Shows the outline of it in scene
        Gizmos.color = Color.blue;//changes the color of the interactable box
        Gizmos.DrawWireCube(transform.position, interactArea);
    }



}




