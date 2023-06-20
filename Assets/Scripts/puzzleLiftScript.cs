using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleLiftScript : MonoBehaviour
{
    Vector2 VectorDown, VectorUp;
    float motionSpeed = 5f;
    Transform liftTransform;
    public ButtonScript buttonScript;
    public bool goingUp;
    public bool goingDown;
    public float timer;
    // Start is called before the first frame update
    public static bool buttonPressed = false;


    // Start is called before the first frame update
    void Start()
    {

        liftTransform = gameObject.transform;
        VectorDown = new Vector2(-46.66f, -36.80f);
        VectorUp = new Vector2(-46.66f, 12.0736f);
        goingUp = false;
        goingDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        //If the lift button is pressed the lift will go to the up position else go to down position
        if (buttonScript.isPressed)
        {
            if (timer < 2000)
            {
                transform.position = Vector3.MoveTowards(transform.position, VectorDown, motionSpeed * Time.deltaTime);
                goingDown = true;
                goingUp = false;
            }
            if (timer >= 3000)
            {
                transform.position = Vector3.MoveTowards(transform.position, VectorUp, motionSpeed * Time.deltaTime);
                goingUp = true;
                goingDown = false;
                //
            }
            if (!OptionsMenuScript.isPaused)
            {
                timer++;
            }
        }

        if (!buttonScript.isPressed || timer >= 5000)
        {
            transform.position = Vector3.MoveTowards(transform.position, VectorUp, motionSpeed * Time.deltaTime);
            timer = 0;
            goingUp = false;
            goingDown = false;
        }

    }

}
