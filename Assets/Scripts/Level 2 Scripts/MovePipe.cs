using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



[RequireComponent(typeof(Rigidbody2D))]//adds rigidbody2D
//[RequireComponent(typeof(BoxCollider2D))]//adds boxcollider2D
public class MovePipe : MonoBehaviour, IVirtualMouse
{
    //Turn the positon of in constraints in rigidbody to limit the axis its on
    
    public bool mouseOn;
    public bool clicked;
    [SerializeField]private Rigidbody2D rb;
    [SerializeField]private Camera cam;

    [SerializeField]private Vector2 ObjectCamPos;

    Vector2 mousePos;
    [SerializeField]GameObject virtualMouse;


    private void Start()
    {
        mouseOn = false;
        rb = GetComponent<Rigidbody2D>();
        ObjectCamPos = cam.WorldToScreenPoint(transform.position);
        CursorControl.SetLocalCursorPos(ObjectCamPos);
    }

    private void OnEnable() {
        virtualMouse = GameObject.Find("MOUSECircle");
    }

    void MovingMouse()
    {
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

    void MovingVirtualMouse()
    {
        if (!clicked)//If the mouse is off turn the movement off. Also turns the body type from kinematic(still state) to dynamic(move state)
        {
            rb.velocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void Update()
    {
        //rb.MovePosition(new Vector2(virtualMouse.position.x, virtualMouse.position.y));

        MovingMouse();

        MovingVirtualMouse();

        if (mouseOn)//if mouse is on the object move the object according to the position of the mouse. 
        {
           // ObjectCamPos = cam.WorldToScreenPoint(transform.position);
           // CursorControl.SetLocalCursorPos(ObjectCamPos);
            rb.MovePosition(new Vector2(mousePos.x, mousePos.y));
        }

        if (clicked)
        {
            rb.MovePosition(new Vector2(virtualMouse.transform.position.x, virtualMouse.transform.position.y));
        }
    }

    public void Click()
    {
        if (!virtualMouse.GetComponent<MoveWithMouse>().hasClicked)
        {
            if (!clicked)
            {
                virtualMouse.transform.position = transform.position;
                virtualMouse.GetComponent<MoveWithMouse>().colObj = this.gameObject;
            }
            clicked = !clicked;
            virtualMouse.GetComponent<MoveWithMouse>().hasClicked = true;
        }
        else
        {
            if (virtualMouse.GetComponent<MoveWithMouse>().colObj == this.gameObject)
            {
                clicked = !clicked;
                virtualMouse.GetComponent<MoveWithMouse>().hasClicked = false;
            }
            else
            {
                return;
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

    private void OnMouseDown() {
        ObjectCamPos = cam.WorldToScreenPoint(transform.position);
        var mouse = Mouse.current;
        mouse.WarpCursorPosition(ObjectCamPos);
    }

    
}
