using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using gameManager = GameManagerScript;
using UnityEngine.SceneManagement; 

public class SGameManager : MonoBehaviour
{
    
    public static bool isWin;
    public static bool isPlayerBallOut;
    private GameObject playerBall;
    private Vector2 locator;

    
    private void OnEnable() {
        //locator = new Vector2(163.2843f, -106.2213f);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.T)) 
        { 
            isWin = true; 
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            gameManager.UnLoadPuzzle("SlidePuzzle");
            gameManager.LoadPuzzle("SlidePuzzle");
        } 
 
 
        if (isWin) 
        { 
            GrateScript.slidePuzzleCompleted = true; 

            gameManager.UnLoadPuzzle("SlidePuzzle");
        } 
    }
}
