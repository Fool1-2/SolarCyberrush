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
    public AudioSource puzzleWinSound;
    public TMP_Text promptText;
    public string curText = "";
    bool ishere;
    public GameObject player;// this is the player
    
    public List<GameObject> wiresInScene;

    gmScript gm;

    public bool delayActive;
    public float timer;
    public static bool allWiresConnected;

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
        if (wiresInScene.Contains(GameObject.FindGameObjectWithTag("Wires")))
        {
            wiresInScene.Add(GameObject.FindGameObjectWithTag("Wires"));
        }

        promptText.text = curText;
        if (Input.GetKey(KeyCode.M))
        {
            wirePuzzleCompleted = true;
        }

        if (ishere)
        {

            if (wirePuzzleCompleted)
            {
                puzzleWinSound.Play();
                curText = "Nice Job";
            }
            if (wirePuzzleInProgress == false && wirePuzzleCompleted == false)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    wirePuzzleInProgress = true;
                    gameManager.LoadWirePuzzle();

                }

            }
            if(gameManager.isSceneLoaded == false)
            {
                wirePuzzleInProgress = false;
            }

            //Master Piece
            if (wiresInScene[0].GetComponent<wireScript>().isWireConnected && wiresInScene[1].GetComponent<wireScript>().isWireConnected && wiresInScene[2].GetComponent<wireScript>().isWireConnected && wiresInScene[3].GetComponent<wireScript>().isWireConnected && wiresInScene[4].GetComponent<wireScript>().isWireConnected)
            {
                //Debug.Log("ChangeNOW");
                
                //SceneInfo.isNextScene = isNextScene;
                wireSceneManager.wirePuzzleCompleted = true;
                
                //SceneManager.SetActiveScene(SceneManager.GetSceneByName("WirePuzzleScene"));
                //SceneManager.UnloadSceneAsync("WirePuzzleScene");
                // SceneManager.LoadScene(1);
                
                StartCoroutine(CCoroutine());

            }

            if (Input.GetKey(KeyCode.H))
            {
                //wirePuzzleCompleted = true;
                wireSceneManager.wirePuzzleCompleted = true;

                //SceneInfo.isNextScene = isNextScene;
                // SceneManager.UnloadSceneAsync("WirePuzzleScene");// unload wire puzzle scene(use when finished in scene)
                // SceneManager.SetActiveScene(SceneManager.GetSceneByName("L1F2"));
                // SceneManager.LoadScene(1);
                StartCoroutine(CCoroutine());
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
    public IEnumerator CCoroutine()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        puzzleWinSound.Play();
        yield return new WaitForSeconds(1);// wait for a secound and change color
        GameManagerScript.UnloadWirePuzzle();
        //randomFinished = true;
        yield return null;
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