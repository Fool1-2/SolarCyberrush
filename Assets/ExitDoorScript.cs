using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ExitDoorScript : MonoBehaviour
{
    public static bool wirePuzzleCompleted = false;
    public TMP_Text doorText;
    string curText;
    bool ishere;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        doorText.text = curText;
        if (ishere)
        {
            if (wirePuzzleCompleted)
            {
                curText = "Press E to exit.";
            }
            else
            {
                curText = "Press E to fix door";
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (wirePuzzleCompleted)
                {
                    //Level completed loads main menu for now
                    SceneManager.LoadScene(0);
                }
                else
                {
                    SceneManager.LoadScene(3);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ishere = true;
        }
    }
    //While in range of the door
    private void OnTriggerStay2D(Collider2D collision)
    {
//Didnt work
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Makes text invisable when player leaves
        ishere = false;
        curText = "";

    }
}
