using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{

    public bool x;
    public bool y;
    [SerializeField]bool mouseOff;
    Vector2 originalTransform;

    private void Start()
    {
        mouseOff = true;
    }

    private void Update()
    {
        if (mouseOff)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            //GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            
        }
    }

    private void OnMouseDrag()
    {
        mouseOff = false;
        float distance_towards_Camera = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        if (y)
        {
            Vector3 pos_Move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_towards_Camera));
            transform.position = new Vector3(pos_Move.x, transform.position.y, pos_Move.z);
        }
        else if (x)
        {
            Vector3 pos_Move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_towards_Camera));
            transform.position = new Vector3(transform.position.x, pos_Move.y, pos_Move.z);
        }
    }

    private void OnMouseExit()
    {
        mouseOff = true;
    }
}
