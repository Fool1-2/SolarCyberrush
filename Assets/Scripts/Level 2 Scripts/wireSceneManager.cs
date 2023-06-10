using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using gameManager = GameManagerScript;//Turns the gamemanagerscript into a using state to be able to use a static function

public class wireSceneManager : MonoBehaviour, IInteractableScript
{
    public Collider2D bc;
    public static Camera Mcamera;
    public static bool wirePuzzleCompleted;
    public static bool wirePuzzleInProgress;
    // public AudioSource puzzleWinSound;
   // public AudioClip impact;
    public AudioSource audioSource;
    public TMP_Text promptText;
    public string curText = "";
    bool ishere;
    public bool hasPlayed;
    public Camera camera2;
    public GameObject player;// this is the player
    
    
    //public PlaceHolderSaveScript saveManager;


    gmScript gm;

    public bool delayActive;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        Mcamera = camera2;
        Mcamera.enabled = true;
        bc = gameObject.GetComponent<Collider2D>();
        gm = GameObject.Find("GMOb").GetComponent<gmScript>();
        wirePuzzleCompleted = false;
        //audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (wirePuzzleCompleted)
        {
            //StartCoroutine(PlayWinSoundAfterPuzzleCompletionCoroutine());
            
            if (!hasPlayed)
            {
                audioSource.Play();
                hasPlayed = true;
            }
            curText = "Nice Job";


        }
        promptText.text = curText;

        if (ishere)
        {
            
            if(gameManager.isSceneLoaded == false)
            {
                wirePuzzleInProgress = false;
                
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

    public void Interact()
    {
        if (wirePuzzleInProgress == false && wirePuzzleCompleted == false)
        {
            wirePuzzleInProgress = true;
            
            gameManager.LoadWirePuzzle();
            
            wireScript.died = false;

        }
        if(wirePuzzleInProgress == true)
        {
            QuitScene.Camera.enabled = true;
            wireSceneManager.Mcamera.enabled = false;

        }
       /* if (QuitScene.Camera.enabled == false)
        {

                QuitScene.Camera.enabled = true;
                Mcamera.enabled = false;
            

        }*/

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            if (!wirePuzzleCompleted)
            {
                curText = "Press E to unlock the wires";
            }
            //Debug.Log("HEY");
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
        //Debug.Log("left");
        ishere = false;
        promptText.text = "";

    }

}