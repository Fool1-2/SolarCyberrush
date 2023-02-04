using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    Vector2 smoothPosition;
    Transform camTransform;
    public bool isMoving;
    public float camMoveSpeed;
    
    

    // Start is called before the first frame update
    void Start()
    {
        camTransform = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();//Finds the cameras transform
    }

    // Update is called once per frame
    void Update()
    {

       if (isMoving)
       {
            smoothPosition = Vector2.MoveTowards(camTransform.position, transform.position, camMoveSpeed * Time.deltaTime);//Moves the camera towards the this objects position at a set speed
            camTransform.position = smoothPosition;  
       }
       camTransform.position = new Vector3(camTransform.position.x, camTransform.position.y, -10f);//Sets the Z to -10 so we can see the screen

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            isMoving = true;//if player is in the boxcollider then turns on moving
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            isMoving = false;//if player is not in the boxcollider then turns off moving
        }
    }
    
    
}
