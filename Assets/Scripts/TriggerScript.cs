using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public ButtonScript buttonscript;
    GameObject[] camBoxCollider;
    public Collider2D[] ignoredCollider;

    // Start is called before the first frame update
    void Start()
    {
        camBoxCollider = GameObject.FindGameObjectsWithTag("CamSwitcher");//finds all the gameObjects that have the tag Camswitcher
        foreach(GameObject col in camBoxCollider)
        {
            Physics2D.IgnoreCollision(col.GetComponent<BoxCollider2D>(), GetComponent<Collider2D>());//ignores all the gameObjects collison with the tag CamSwitcher 
        }
        buttonscript = GameObject.Find("PressableButton").GetComponent<ButtonScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        buttonscript.timerOn = false;
        buttonscript.timeUp = false;
        buttonscript.notPressed();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        buttonscript.Pressed();
        if (other.gameObject.tag != "Telekinesis" || other.gameObject.tag != "Light")
        {
            if (!buttonscript.timeUp)
            {
                buttonscript.Pressed();
            }
            
        }
    }

}
