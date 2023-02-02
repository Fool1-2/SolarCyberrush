/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]//adds rigidbody2D
[RequireComponent(typeof(BoxCollider2D))]//adds boxcollider2D
public class MovePipe : MonoBehaviour
{
    //Turn the positon of in constraints in rigidbody to limit the axis its on
    
    [SerializeField]bool mouseOn;
    [SerializeField]Rigidbody2D rb;
    Vector2 mousePos;
    

    private void Start()
    {
        mouseOn = false;
    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//Gets the camera position from the screen and puts into the world.

        if (!mouseOn)//If the mouse is off turn the movement off. Also turns the body type from kinematic(still state) to dynamic(move state)
        {
            rb.velocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
        
    }

    private void FixedUpdate() {

        if (mouseOn)//if mouse is on the object move the object according to the position of the mouse. 
        {
            rb.MovePosition(new Vector2(mousePos.x, mousePos.y));
        }
    }

    private void OnMouseDrag()
    {
        mouseOn = true;//checks if player is clicking the object
    }

    private void OnMouseUp() {
        mouseOn = false;//when player clicks off object.
    }

    
}
*/