using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;
using gameManager = GameManagerScript;//Turns the gamemanagerscript into a using state to be able to use a static function

public class GrateScript : MonoBehaviour
{
    public Collider2D bc;
    public static bool slidePuzzleCompleted;
    public static bool slidePuzzleInProgress;
    public TMP_Text promptText;
    public string curText = "";
    bool ishere;
    public GameObject player;
    //public PlaceHolderSaveScript saveManager;
    Light2D l2d;

    gmScript gm;

    public bool delayActive;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        bc = gameObject.GetComponent<Collider2D>();
        gm = GameObject.Find("GMOb").GetComponent<gmScript>();
        l2d = gameObject.GetComponent<Light2D>();
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
            if (slidePuzzleCompleted)
            {
                curText = "Press E to Crawl to the Exit";
            }
            else
            {
                curText = "Press E to Clear the Pipe";
            }
            if (slidePuzzleInProgress == false)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!slidePuzzleCompleted)
                    {
                        slidePuzzleInProgress = true;
                        gameManager.LoadPuzzle("SlidePuzzle");
                    }
                    else if (!delayActive)
                    {
                        delayActive = true;
                        player.GetComponent<Transform>().position = new Vector3(20, -4, 0);
                    }

                }
                

            }
            if (gameManager.isSceneLoaded == false)
            {
                slidePuzzleInProgress = false;
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
        if (ishere)
        {
            l2d.enabled = true;
        }
        else
        {
            l2d.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ishere = true;
            player = collision.gameObject;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           /* if (Input.GetKeyDown(KeyCode.E))
            {
                if (slidePuzzleCompleted)
                {
                    delayActive = true;
                    player.GetComponent<Transform>().position = new Vector3(20, -4, 0);
                }
                else
                {
                    gameManager.LoadPuzzle("SlidePuzzle");//Loads SlidePuzzle if slidePuzzle is not completed
                }
            }*/
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ishere = false;
        curText = "";

    }

    public void sendPlayerBack()
    {
        if (!delayActive)
        {
            delayActive = true;
            player.GetComponent<Transform>().position = new Vector3(11, 8.25f, 0);
        }
    }
}
