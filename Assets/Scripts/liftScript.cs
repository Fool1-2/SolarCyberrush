using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liftScript : MonoBehaviour
{
    Vector2 VectorDown, VectorUp;
    float motionSpeed = 5f;
    Transform liftTransform;
    public ButtonScript buttonScript;
    
    //This will be triggered to true when the lift button is being pressed
    public static bool buttonPressed = false;


    // Start is called before the first frame update
    void Start()
    {
       
        liftTransform = gameObject.transform;
        VectorDown = new Vector2(-6.5f, -8.8f);
        VectorUp = new Vector2(-6.5f, 4.3f);
    }

    // Update is called once per frame
    void Update()
    {
        //If the lift button is pressed the lift will go to the up position else go to down position
        if (buttonScript.isPressed)
        {
            transform.position = Vector3.MoveTowards(transform.position, VectorUp, motionSpeed * Time.deltaTime);
            
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, VectorDown, motionSpeed * Time.deltaTime);
        }
    }
}
