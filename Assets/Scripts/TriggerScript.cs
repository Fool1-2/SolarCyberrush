using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public ButtonScript buttonscript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Telekinesis" || collision.gameObject.tag != "Light")
        {
            buttonscript.Pressed();
        }
        Debug.Log("Entered");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        buttonscript.notPressed();
        Debug.Log("Exitted");
    }
}
