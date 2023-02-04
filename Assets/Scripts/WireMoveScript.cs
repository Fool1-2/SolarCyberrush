using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]//adds rigidbody2D
[RequireComponent(typeof(BoxCollider2D))]//adds boxcollider2D
public class WireMoveScript : MonoBehaviour
{
    //Turn the positon of in constraints in rigidbody to limit the axis its on
    
    [SerializeField]bool mouseOn;
    [SerializeField]Rigidbody2D rb;
    Vector2 mousePos;
    public Vector2 boxSize;
    public Transform StartObject;
    public Transform EndObject;
    HingeJoint2D hingeJoint2D;
    public bool conOne;
    public bool conTwo;
   


    private void Start()
    {
        mouseOn = false;
        boxSize = transform.localScale;
        hingeJoint2D = gameObject.GetComponent<HingeJoint2D>();
        // Debug.Log("Hello world");
        conOne = false;
        conTwo = false;
    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//Gets the camera position from the screen and puts into the world.

        if (!mouseOn)//If the mouse is off turn the movement off.
        {
            rb.velocity = Vector2.zero;
        }

        if (conOne && conTwo == true)
        {
            Debug.Log("Wire is connected");
        }

    }

    private void FixedUpdate() {

        if (mouseOn)//if mouse is on the object move the object according to the position of the mouse. 
        {
           // float distance = Vector2.Distance(boxSize, mousePos);
            rb.MovePosition(new Vector2(mousePos.x, mousePos.y));
            //   transform.localScale = new Vector2(distance,boxSize.y);
            if (Input.GetKey(KeyCode.Space))
            {
                //float distance = Vector2.Distance(boxSize, mousePos);
                transform.localScale = new Vector2(mousePos.x, boxSize.y);
            }
            if (Input.GetKey(KeyCode.W))
            {
                //checks if the hinge is enabled or disabled
                hingeJoint2D.enabled = !hingeJoint2D.enabled;
            }



        }
    }

    private void OnMouseDrag()
    {
        mouseOn = true;//checks if player is clicking the object
        
    }

    private void OnMouseUp() {
        mouseOn = false;//when player clicks off object.
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ConnecterOne")
        {
            Debug.Log("Connecting 1");
            conOne = true;
        }
        if (collision.gameObject.tag == "ConnectorTwo")
        {
            Debug.Log("Connecting 2");
            conTwo = true;
        }
    }
}


