using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using gameManager = GameManagerScript;
using UnityEngine.SceneManagement; 

public class SGameManager : MonoBehaviour
{
    
    public static bool isWin;
    public static bool playerLose;
    public static bool isPlayerBallOut;
    private GameObject playerBall;
    private Vector2 locator;
    [SerializeField]private GameObject[] pipes;

    
    private void OnEnable() {
        pipes = GameObject.FindGameObjectsWithTag("Pipes");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlayerBallOut)
        {
            foreach (GameObject pipe in pipes)
            {
                pipe.GetComponent<PipeController>().isDone = false;
            }
        }

        if (Input.GetKey(KeyCode.T)) 
        { 
            isWin = true; 
        }
 
 
        if (isWin) 
        { 
            GrateScript.slidePuzzleCompleted = true; 

            gameManager.UnLoadPuzzle("SlidePuzzle");
        } 
    }
}
