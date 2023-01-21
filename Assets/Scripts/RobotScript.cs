using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotScript : MonoBehaviour
{
    public static bool isRobotActive;
    public bool isAbletoMove;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//Gets the rigidbody
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))//when space is pressed activates the robot and turns on the move bool.
        {
            isRobotActive = true;
            isAbletoMove = true;
        }
    }
    private void FixedUpdate()
    {
        if (isRobotActive)
        {
            if (isAbletoMove)
            {
                if (!this.gameObject.GetComponent<SpriteRenderer>().flipX)//The sprite will move towards the direction it's facing.
                {
                    transform.Translate(0.1f, 0f, 0f);
                }
                else
                {
                    transform.Translate(-0.1f, 0f, 0f);
                }
            }
            else
            {
                transform.Translate(0f, 0f, 0f);//Stops all movement when isAbletoMove is false
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == "Floor")// if the robot touhes the floor it will stop moving.
        {
            isAbletoMove = false;
        }
    }
    
}
