using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public bool isPressed;
    [SerializeField]private bool onePress;
    public AudioClip buttonPressSound;
    Vector2 pressedPos, unpressedPos;

    Transform tf;

   
    Vector3 ScaleChange;
    // Start is called before the first frame update
    void Start()
    {
        tf = gameObject.transform;
        pressedPos = new Vector2(0, 0.07f);
        unpressedPos = new Vector2(0, 0.1f);
        //ScaleChange = new Vector3(0, 0.03f, 0);
        //buttonPressSound = GetComponent<AudioClip>();
    }

    // Update is called once per frame
    void Update()
    {

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
        onePress = false;
        if (!onePress)
        {
            yield return new WaitForSeconds(.1f);
            isPressed = true;
            transform.localPosition = pressedPos;
            onePress = true;
        }
        
        if (onePress)
        {
            yield return new WaitForSeconds(15f);
            isPressed = false;
            transform.localPosition = unpressedPos;
        }
    }
    IEnumerator Unpress()
    {
        yield return new WaitForSeconds(.1f);
        if (isPressed)
        {
            tf.localScale += ScaleChange;
            AudioSource.PlayClipAtPoint(buttonPressSound, ScaleChange);

        }
        isPressed = false;
        onePress = false;
        transform.localPosition = unpressedPos;
    }
}
 