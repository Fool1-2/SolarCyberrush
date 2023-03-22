using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using gameManager = GameManagerScript;//Turns the gamemanagerscript into a using state to be able to use a static function

public class wireSceneManager : MonoBehaviour
{
    public Collider2D bc;
    public static bool wirePuzzleCompleted;
    public static bool wirePuzzleInProgress;
    public TMP_Text promptText;
    public string curText = "";
    bool ishere;
    public GameObject player;
    //public PlaceHolderSaveScript saveManager;


    gmScript gm;

    public bool delayActive;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        bc = gameObject.GetComponent<Collider2D>();
        gm = GameObject.Find("GMOb").GetComponent<gmScript>();
        wirePuzzleCompleted = false;
    }

    // Update is called once per frame
    void Update()
    {
        promptText.text = curText;
        if (Input.GetKey(KeyCode.M))
        {
            wirePuzzleCompleted = true;
        }
        if (ishere)
        {
            
            Debug.Log("Here");
            if (!wirePuzzleCompleted)
            {
               // curText = "Press E to do wires";
            }
            if (wirePuzzleCompleted)
            {
                curText = "Nice Job";
            }
            if (wirePuzzleInProgress == false)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    wirePuzzleInProgress = true;
                    gameManager.LoadWirePuzzle();
                    Debug.Log("Going");
                    
                }

            }
            if(gameManager.isSceneLoaded == false)
            {
                wirePuzzleInProgress = false;
            }



        }
        if (!ishere)
        {



            wirePuzzleCompleted = false;
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
            
            curText = "Press E to do wires";
            Debug.Log("HEY");
            player = collision.gameObject;
            if (gm.objectiveNumber == 0)
            {
                gm.objectiveNumber = 1;
                gm.objectiveText.text = "Current Objective: " + gm.ObjectivesList[1];
            }

        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ishere = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("left");
        ishere = false;
        promptText.text = "";

    }
}