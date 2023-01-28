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

    //Notes: Make it so that when the object collides with something it turns off the telekinesis



    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        xMagnitude = gameObject.transform.localScale.y * .5f;
        yMagnitude = gameObject.transform.localScale.x;
        speed = 11;
        duration = .1f;
        yDif = 1;
        shakeForce = 20;
        isNotRunningShake = true;
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
        if (isPoss && isNotRunningShake)
        {
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
        Debug.Log("Shook");
        yield return null;
    }
}
