using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



[RequireComponent(typeof(Rigidbody2D))]//adds rigidbody2D
//[RequireComponent(typeof(BoxCollider2D))]//adds boxcollider2D
public class MovePipe : MonoBehaviour
{
    //Turn the positon of in constraints in rigidbody to limit the axis its on
    
    public bool mouseOn;
    [SerializeField]private Rigidbody2D rb;
    [SerializeField]private Camera cam;

    [SerializeField]private Vector2 ObjectCamPos;

    Vector2 mousePos;
    

    private void Start()
    {
        mouseOn = false;
        rb = GetComponent<Rigidbody2D>();
        ObjectCamPos = cam.WorldToScreenPoint(transform.position);
        CursorControl.SetLocalCursorPos(ObjectCamPos);
    }

    private void Update()
    {


        if (mouseOn)//if mouse is on the object move the object according to the position of the mouse. 
        {
           // ObjectCamPos = cam.WorldToScreenPoint(transform.position);
           // CursorControl.SetLocalCursorPos(ObjectCamPos);
            rb.MovePosition(new Vector2(mousePos.x, mousePos.y));
        }
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);//Gets the camera position from the screen and puts into the world.
        
        if (!mouseOn)//If the mouse is off turn the movement off. Also turns the body type from kinematic(still state) to dynamic(move state)
        {
            rb.velocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
        else
        {
            //CursorControl.SetPosition(0, 0);
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void OnMouseDrag()
    {
        mouseOn = true;//checks if player is clicking the object
    }

    private void OnMouseUp() {
        mouseOn = false;//when player clicks off object.
    }

    private void OnMouseDown() {
        ObjectCamPos = cam.WorldToScreenPoint(transform.position);
        var mouse = Mouse.current;
        mouse.WarpCursorPosition(ObjectCamPos);
    }

    
}
