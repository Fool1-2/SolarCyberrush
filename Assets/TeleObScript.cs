using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleObScript : MonoBehaviour
{
    
    public Rigidbody2D rb;
    public static bool isPoss;
    public float speed = 3f;
    int randPos;
    //The function shake turns this on and off everytime it moves in one direction as to not call a shake every frame
    public static bool isNotRunningShake;
    //The duration of the shake
    public float duration;
    //The shake magnitude that varies
    float xMagnitude;
    float yMagnitude;
    //the force of shaking    
    public float shakeForce;
    //Determin shake
    float xShake;
    float yShake;
    public float yDif;
    Vector2 shakeVector;
    public static Transform tf;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tf = transform;
        xMagnitude = gameObject.transform.localScale.y * .5f;
        yMagnitude = gameObject.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {

        if (isPoss)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(pause());
                isPoss = false;
                isNotRunningShake = true;
                playerMovementScript.notPoss = true;
            }
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

    }
    //I hoonestly dont think this does anything
    IEnumerator pause()
    {
        yield return new WaitForSeconds(1f);
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
    private void FixedUpdate()
    {
        if (isPoss && isNotRunningShake)
        {
            StartCoroutine(shake());
        }
    }
    /*void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 moveDir = new Vector2(x, y);
        rb.MovePosition(rb.position + moveDir * speed * Time.fixedDeltaTime);
    }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Telekenisis")
        {
            playerMovementScript.notPoss = false;
            Destroy(collision.gameObject);
            isPoss = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Telekenisis")
        {
            playerMovementScript.notPoss = false;
            Destroy(collision.gameObject);
            isPoss = true;
        }
    }
}
