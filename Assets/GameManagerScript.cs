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

    public static float volume;
    [SerializeField] Slider volumeSlider;
    public Canvas pauseMenuCanvas;
    [SerializeField] TMP_Text sliderText;

    private void Update()
    {
        if(wireSceneManager.wirePuzzleCompleted == true)
        {
            puzzleWinSound.Play();
        }
        if (playerList[0] == null)
        {
            playerList[0] = GameObject.FindGameObjectWithTag("Player");//finds the player
        }

        if (isSceneLoaded)//turns off the playermovement in the original scene if we have loaded into another scene
        {
            PlayerMovement.canMove = false;
        }

        if (!isSceneLoaded)//turns on the playermovement in the original scene if we have loaded into another scene
        {
            PlayerMovement.canMove = true;
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
            openPauseMenu();
        }
        volume = volumeSlider.value;
        sliderText.text = "Volume: " + Mathf.Round(volumeSlider.value * 100);


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
        OST1.Play();
        pauseMenuCanvas.enabled = false;
        volumeSlider.value = volume;
       // OST2.Play();

    }

    public static void LoadWirePuzzle()
    {
        //  SceneManager.UnloadSceneAsync("L1F2");
        isSceneLoaded = true;
        //PlayerMovement/can = true;
        SceneManager.LoadSceneAsync("WirePuzzleScene", LoadSceneMode.Additive);// Loads the wire puzzle scene addative to the main scene

        SceneManager.SetActiveScene(SceneManager.GetSceneByName("WirePuzzleScene"));// sets wirepuzzle scene as active scene 
    }

    public static void UnloadWirePuzzle()
    {
        isSceneLoaded = false;
        //Glow.isGlowActive = false;
        
        SceneManager.UnloadSceneAsync("WirePuzzleScene");// unload wire puzzle scene(use when finished in scene)
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("L1F2"));
    }

    public static void LoadPuzzle(string SceneName)
    {
        isSceneLoaded = true;
        SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);//Loads the scene by the string
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(SceneName));
        
        
    }

    public static void UnLoadPuzzle(string SceneName)
    {
        isSceneLoaded = false;
        SceneManager.UnloadSceneAsync(SceneName);//Unloads the scene by string
    }
    public void openPauseMenu()
    {
        pauseMenuCanvas.enabled = true;
        Time.timeScale = 0;
    }
    public void closePauseMenu()
    {
        pauseMenuCanvas.enabled = false;
        Time.timeScale = 1;
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        Destroy(this.gameObject);
    }
}

