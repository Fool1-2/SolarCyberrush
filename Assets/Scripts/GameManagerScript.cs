using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using gameManager = SwitchCamera;


public class GameManagerScript : MonoBehaviour
{
    public List<GameObject> playerList;
    public static bool isSceneLoaded;
    public AudioSource OST1;
    public AudioSource OST2;
    public AudioSource puzzleWinSound;
    public static bool cameraControl;
    public static float volume;
    [SerializeField] Slider volumeSlider;
    public Canvas pauseMenuCanvas;
    [SerializeField] TMP_Text sliderText;
    public static bool ranThroughSIA;
    private void Update()
    {

        if (wireSceneManager.wirePuzzleCompleted == true)
        {
            puzzleWinSound.Play();
        }
        if (playerList[0] == null)
        {
            playerList[0] = GameObject.FindGameObjectWithTag("Player");//finds the player
        }

        try
        {
            if (wireSceneManager.Mcamera.enabled == false || GrateScript.slidePuzzleInProgress == true)//turns off the playermovement in the original scene if we have loaded into another scene
            {
    
                PlayerMovement.canMove = false;
            }
    
            if (wireSceneManager.Mcamera.enabled == true && GrateScript.slidePuzzleInProgress == false)//turns on the playermovement in the original scene if we have loaded into another scene
            {
                PlayerMovement.canMove = true;
    
            }

  
        }
        catch (System.Exception)
        {
           return;
        }
        if (InsideBuildingManagerScript.atSIA)
        {
            //PlayerMovement.canMove = false;
        }
        if (!InsideBuildingManagerScript.atSIA)
        {
            //PlayerMovement.canMove = true;
        }
        else
        {
            //playerList[0].SetActive(true);
        }
        OST1.volume = volume;
        if (isSceneLoaded == true)
        {
            
            //OST2.Play();
            OST1.Stop();
           // OST2.Play();

        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
           // openPauseMenu();
        }
        //volume = volumeSlider.value;
        //sliderText.text = "Volume: " + Mathf.Round(volumeSlider.value * 100);


        /* if (Input.GetKeyDown(KeyCode.K))
         {
          LoadWirePuzzle();
         }*/


        /*  if (Input.GetKeyDown(KeyCode.Q))
          {
             // SceneManager.UnloadSceneAsync("WirePuzzleScene");
              SceneManager.LoadSceneAsync("L1F2", LoadSceneMode.Additive);

              SceneManager.SetActiveScene(SceneManager.GetSceneByName("L1F2"));
          }*/


    }

    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);// this object doesnt die
       // OST1.Play();
        if (pauseMenuCanvas == null)
        {
            return;
        }
        pauseMenuCanvas.enabled = false;
       // volumeSlider.value = volume;
       // OST2.Play();

    }

    public static void LoadWirePuzzle()
    {
        //  SceneManager.UnloadSceneAsync("L1F2");
        isSceneLoaded = true;
        wireSceneManager.Mcamera.enabled = false;
        //PlayerMovement/can = true;
        SceneManager.LoadSceneAsync("WirePuzzleScene", LoadSceneMode.Additive);// Loads the wire puzzle scene addative to the main scene
       //cameraControl = true;
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("WirePuzzleScene"));// sets wirepuzzle scene as active scene

    }
    public static void LoadSIA()
    {
        
        isSceneLoaded = true;
        InsideBuildingManagerScript.camera2.enabled = false;
       // InsideBuildingManagerScript.atSIA = true;
        PlayerMovement.isPossessing = false;
        SceneManager.LoadSceneAsync("SIARoomScene", LoadSceneMode.Additive);// Loads the wire puzzle scene addative to the main scene
                                                                               //cameraControl = true;
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("SIARoomScene"));// sets wirepuzzle scene as active scene

    }

    public static void UnloadSia()
    {
        isSceneLoaded = false;
        InsideBuildingManagerScript.camera2.enabled = true;
        PlayerMovement.isPossessing = false;
        SceneManager.UnloadSceneAsync("SIARoomScene");
    }
   
    public static void CameraControl()
    {
        QuitScene.Camera.enabled = false;
        InsideBuildingManagerScript.camera2.enabled = true;

        // isSceneLoaded = false;

    }
    public static void CameraControl2()
    {
        QuitScene.Camera.enabled = false;
        InsideBuildingManagerScript.Mcamera.enabled = false;
        UnLoadPuzzle("SIARoomScene");

        // isSceneLoaded = false;

    }
    public static void UnloadWirePuzzle()
    {
        isSceneLoaded = false;
        //Glow.isGlowActive = false;
        
        SceneManager.UnloadSceneAsync("WirePuzzleScene");// unload wire puzzle scene(use when finished in scene)
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("FinalLevel2Part2"));
        wireSceneManager.Mcamera.enabled = true;
    }

    public static void LoadPuzzle(string SceneName)
    {
        
        isSceneLoaded = true;
        PlayerMovement.canMove = true;
        SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);//Loads the scene by the string
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(SceneName));
    }

    public static void LoadPuzzle2(string SceneName)
    {
        
        isSceneLoaded = true;
        PlayerMovement.canMove = true;
        SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);//Loads the scene by the string
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(SceneName)); 
    }

    public static void UnLoadPuzzle(string SceneName)
    {
        
        isSceneLoaded = false; 
        PlayerMovement.canMove = true;
        SceneManager.UnloadSceneAsync(SceneName);//Unloads the scene by string
    }
   /* public void openPauseMenu()
    {
        pauseMenuCanvas.enabled = true;
        Time.timeScale = 0;
    }
    public void closePauseMenu()
    {
        pauseMenuCanvas.enabled = false;
        Time.timeScale = 1;
    }*/
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        GrateScript.slidePuzzleCompleted = false;
        GrateScript.slidePuzzleInProgress = false;
        
        Destroy(this.gameObject);
    }
}

