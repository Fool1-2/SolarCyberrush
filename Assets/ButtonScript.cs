using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public bool isPressed;
    Vector2 pressedPos, unpressedPos;

    Transform tf;

   
    Vector3 ScaleChange;
    // Start is called before the first frame update
    void Start()
    {
        tf = gameObject.transform;
        pressedPos = new Vector2(0, 0.5f);
        unpressedPos = new Vector2(0, 0.6f);
        ScaleChange = new Vector3(0, 0.1f, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Pressed()
    {
        //Fix so it only gets called once with the lerp
        if (!isPressed)
        {
            tf.localScale -= ScaleChange;
        }
        isPressed = true;
        transform.localPosition = pressedPos;
        
    }
    public void notPressed()
    {
        if (isPressed)
        {
            tf.localScale += ScaleChange;
        }
        isPressed = false;
        transform.localPosition = unpressedPos;
        
    }
}
 