using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class MovePipe : MonoBehaviour
{

    enum axisEnum{x, y};
    [SerializeField]axisEnum axis;
    [SerializeField]bool mouseOn;
    public Transform testObject;
    Rigidbody2D rb;
    

    private void Start()
    {
        mouseOn = false;
    }

    private void Update()
    {
        


    }

    private void OnMouseDrag()
    {
        mouseOn = true;

        if (axis == axisEnum.y)//The object only goes on the Y axis
        {
            transform.position = new Vector2(transform.position.x, testObject.position.y);
            
        }
        else if (axis == axisEnum.x)//The object only goes on the X axis
        {

            transform.position = new Vector2(testObject.position.x, transform.position.y);
        }
    }

    private void OnMouseUp() {
        mouseOn = false;
    }

    
}
