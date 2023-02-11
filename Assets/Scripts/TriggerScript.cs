using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public ButtonScript buttonscript;
    GameObject[] camBoxCollider;

    // Start is called before the first frame update
    void Start()
    {
        camBoxCollider = GameObject.FindGameObjectsWithTag("CamSwitcher");//finds all the gameObjects that have the tag Camswitcher
        foreach(GameObject col in camBoxCollider)
        {
            Physics2D.IgnoreCollision(col.GetComponent<BoxCollider2D>(), GetComponent<Collider2D>());//ignores all the gameObjects collison with the tag CamSwitcher 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        buttonscript.notPressed();
        Debug.Log("Exitted");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Telekinesis" || collision.gameObject.tag != "Light")
        {
            buttonscript.Pressed();
            Debug.Log("Entered");
        }

    }
}
