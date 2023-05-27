using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public bool isPressed;
    [SerializeField]private bool onePress;
    public AudioSource buttonPressSound;
    Vector2 pressedPos, unpressedPos;
    public int buttonNumber;

    Transform tf;
    float timerWoah;
    public bool timerOn;
    public bool timeUp;

   
    Vector3 ScaleChange;
    // Start is called before the first frame update
    void Start()
    {
       // buttonPressSound = GetComponent<AudioSource>();
        tf = gameObject.transform;
        pressedPos = new Vector2(0, 0.07f);
        unpressedPos = new Vector2(0, 0.1f);
        //ScaleChange = new Vector3(0, 0.03f, 0);
        //buttonPressSound = GetComponent<AudioClip>();
    }

    // Update is called once per frame
    void Update()
    {

        if (buttonNumber < 0)
        {
            buttonNumber = 0;
        }
        if (timerOn)
        {
            timerWoah += Time.deltaTime;
            if (timerWoah >= 15f)
            {
                timeUp = true;
            }
        }

        if (timeUp)
        {
            //isPressed = false;
            //transform.localPosition = unpressedPos;
        }

        if (!timerOn)
        {
            timerWoah = 0;
        }
    }
    public void Pressed()
    {

        //Fix so it only gets called once with the lerp
          StartCoroutine(Press());


    }
    public void notPressed()
    {
         StartCoroutine(Unpress());


    }
    IEnumerator Press()
    {
        if (!timeUp)
        {
            onePress = false;
            if (!onePress)
            {
                yield return new WaitForSeconds(.1f);
                
                transform.localPosition = pressedPos;
                buttonNumber++;
                timerOn = true;
                if(buttonNumber == 3)
                {
                    isPressed = true;
                    onePress = true;
                }
                
                buttonPressSound.Play();
            }
        }
    }
    IEnumerator Unpress()
    {
        yield return new WaitForSeconds(.1f);
        if (isPressed)
        {
            StopCoroutine(Press());
            tf.localScale += ScaleChange;
            

        }
        isPressed = false;
        onePress = false;
        buttonNumber--;
        transform.localPosition = unpressedPos;
    }
}
 