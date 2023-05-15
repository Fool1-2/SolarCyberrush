using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liftScript : MonoBehaviour
{
    Vector2 VectorDown, VectorUp;
    float motionSpeed = 5f;
    Transform liftTransform;
    public ButtonScript buttonScript;
    public bool goingUp;
    public bool goingDown;
    public float timer;

    //This will be triggered to true when the lift button is being pressed
    public static bool buttonPressed = false;


    // Start is called before the first frame update
    void Start()
    {

        liftTransform = gameObject.transform;
        VectorDown = new Vector2(-6.5f, -8.8f);
        VectorUp = new Vector2(-6.5f, 4.3f);
        goingUp = false;
        goingDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        //If the lift button is pressed the lift will go to the up position else go to down position
        if (buttonScript.isPressed)
        {
            if (timer < 2000f)
            {
                transform.position = Vector3.MoveTowards(transform.position, VectorUp, motionSpeed * Time.deltaTime);
            }
            if (timer >= 3000f)
            {
                transform.position = Vector3.MoveTowards(transform.position, VectorDown, motionSpeed * Time.deltaTime);
                //
            }
            if (timer >= 4000f)
            {
                timer = 0;
            }
            if (!OptionsMenuScript.isPaused)
            {
                timer++;
            }
            
        }

        if (!buttonScript.isPressed)
        {
            transform.position = Vector3.MoveTowards(transform.position, VectorDown, motionSpeed * Time.deltaTime);
            timer = 0;
        }

    }


}
