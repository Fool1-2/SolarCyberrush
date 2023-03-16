using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SceneSwitcher = SwichScenes;
using UnityEngine.SceneManagement; 

public class SGameManager : MonoBehaviour
{
    
    public static bool isWin;
    

    private void Awake() {
        
    }

    private void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
    }

    public void OnSceneUnloaded(Scene scene)
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
