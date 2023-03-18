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
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag != "Telekinesis" || other.gameObject.tag != "Light")
        {
            buttonscript.Pressed();
        }
    }
}
