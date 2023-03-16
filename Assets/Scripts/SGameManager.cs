using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SceneSwitcher = SwichScenes;
using UnityEngine.SceneManagement; 

public class SGameManager : MonoBehaviour
{
    public PlaceHolderSaveScript saveManager;
    public static bool isWin;
    

    // Start is called before the first frame update
    void Start()
    {
        
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
            SceneManager.LoadScene(2);
        } 
 
 
        if (isWin) 
        { 
            GrateScript.slidePuzzleCompleted = true; 
 
            SceneSwitcher.SceneSwitch("L1F2");
        } 
    }
}
