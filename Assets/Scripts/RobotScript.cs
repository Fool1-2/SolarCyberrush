using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotScript : MonoBehaviour, ILightAbility
{
    public bool isRobotActive;
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
        if (other.gameObject.tag == "Light")// if the robot touhes the floor it will stop moving.
        {
            ActivatePower();
        }

        
    }

    public void ActivatePower()
    {
        isRobotActive = true;
    }
    
}
