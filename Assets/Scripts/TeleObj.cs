using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class TeleObj : MonoBehaviour
{
    public bool isPoss;
    float horizontal;
    float vertical;
    [SerializeField]float speed;
    [SerializeField]Rigidbody2D rb;
    int randPos;
    //The function shake turns this on and off everytime it moves in one direction as to not call a shake every frame
    public static bool isNotRunningShake;
    //The duration of the shake
    public float duration;
    //The shake magnitude that varies
    float xMagnitude;
    float yMagnitude;
    //the force of shaking    
    public float shakeForce = 1;
    //Determin shake
    float xShake;
    float yShake;
    public float yDif = 1f;
    Vector2 shakeVector;
    [SerializeField]Material outLine;
    [SerializeField]Vector2 outLineVec;

    //Notes: Make it so that when the object collides with something it turns off the telekinesis
    public float teleWaitTimer = 0;



    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        xMagnitude = 1;
        yMagnitude = 1;
        speed = 11;
        duration = .1f;
        yDif = 1;
        shakeForce = 3;
        isNotRunningShake = true;
        outLine = GetComponent<SpriteRenderer>().material;
    }
    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.tag == "FloatTeleObj")
        {
            teleWaitTimer = 0;
        }
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (this.gameObject != Glow.currentPossessedObj)
        {
            isPoss = false;          
        }
        if (isPoss)
        {
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 60;
        }

        if (Glow.glowType == 0 && Glow.isGlowActive)//if glow is on and telekensis is active then light2D will turn on the objects lights
        {
            outLine.SetVector("_Thickness", outLineVec);
            outLineVec = new Vector2(0.03f, 0.03f);
        }
        else
        {
            outLine.SetVector("_Thickness", outLineVec);
            outLineVec = Vector2.zero;
        }

    }

    private void FixedUpdate()
    {
        PossessionMovement(isPoss);
        if (isPoss && isNotRunningShake)
        {
            teleWaitTimer += Time.deltaTime;
            StartCoroutine(shake());
        }
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
    IEnumerator shake()
    {
        isNotRunningShake = false;
        //rerandomize shake direction and strength and repeat
        //Sets the vectors to move either left or right
        randPos = Random.Range(1, 3);
        if (randPos == 1)
        {
            xShake = -1;
        }
        else
        {
            xShake = 1;
        }
        randPos = Random.Range(1, 3);
        if (randPos == 1)
        {
            yShake = -1;
        }
        else
        {
            yShake = 1;
        }
        float elapsed = 0.0f;
        //for the duration shake in one direction for the force and magnitudes
        xMagnitude = Random.Range(0.5f, 1f);
        yMagnitude = Random.Range(0.5f, 1f);
        while (elapsed < duration)
        {
            //The Y shake is Ydif times stronger than the x
            //The shake vector is multiplied by the random magnitude to form a vector with both random direction and force
            shakeVector = new Vector2(xShake * xMagnitude, yShake * yMagnitude * yDif);
            //Get keyboard inputs
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            //Set the inputs into a vector
            Vector2 moveDir = new Vector2(x, y);
            //Parentheses one is the shaking multiplied by shake force
            //Parentheses two is the keyboard driven movement
            rb.MovePosition(rb.position + (shakeVector * shakeForce * Time.fixedDeltaTime) + (moveDir * speed * Time.fixedDeltaTime));
            elapsed += Time.deltaTime;
        }
        isNotRunningShake = true;
        yield return null;
    }
    //These two combined break telekinesis when you're touching somethimg
    private void OnCollisionEnter2D(Collision2D collision)
    {
   

        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "floor" || collision.gameObject.layer == 6 || collision.gameObject.tag == "Player")
        {

            if (teleWaitTimer > 1)
            {
                isPoss = false;
                PlayerMovement.isPossessing = false;
                teleWaitTimer = 0;
            }
        }


    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "floor" || collision.gameObject.layer == 6 || collision.gameObject.tag == "Player")
        {

            if (teleWaitTimer > 1)
            {
                isPoss = false;
                PlayerMovement.isPossessing = false;
                teleWaitTimer = 0;
            }
        }
    }
}
