using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
public class GrateScript : MonoBehaviour
{
    public BoxCollider2D bc;
    public static bool slidePuzzleCompleted;
    public TMP_Text promptText;
    public string curText = "";
    bool ishere;
    public GameObject player;
    public PlaceHolderSaveScript saveManager;
   

    gmScript gm;

    public bool delayActive;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        saveManager = GameObject.Find("SaveSceneGM").GetComponent<PlaceHolderSaveScript>();
        bc = gameObject.GetComponent<BoxCollider2D>();
        gm = GameObject.Find("GMOb").GetComponent<gmScript>();
    }

    // Update is called once per frame
    void Update()
    {
        promptText.text = curText;
        if (Input.GetKeyDown(KeyCode.M))
        {
            slidePuzzleCompleted = true;
        }
        if (ishere)
        { 
            Debug.Log("Here");
            if (slidePuzzleCompleted)
            {
                curText = "Press E to Crawl to the Exit";
            }
            else
            {
                curText = "Press E to Clear the Pipe";
            }

            
        }
        if (delayActive)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                delayActive = false;
                timer = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ishere = true;
            player = collision.gameObject;
            if (gm.objectiveNumber == 0)
            {
                gm.objectiveNumber = 1;
                gm.objectiveText.text = "Current Objective: " + gm.ObjectivesList[1];
            }

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (slidePuzzleCompleted)
                {
                    delayActive = true;
                    player.GetComponent<Transform>().position = new Vector3(20, -4, 0);
                }
                else
                {
                    SceneManager.LoadScene(2);
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("left");
        ishere = false;
        promptText.text = "";

    }
}
