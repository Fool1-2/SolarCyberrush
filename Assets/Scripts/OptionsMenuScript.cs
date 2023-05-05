using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OptionsMenuScript : MonoBehaviour
{
    public Canvas settingsCanvas;
    public static bool settingsCanvasEnabled;
    public Slider slider;
    public TMP_Text sliderText;
    [SerializeField] Slider volumeSlider;
    public AudioSource mainMenuMusic;
    public static float volume;
    
   // public bool menuOpen;
    
    // Start is called before the first frame update
    void Start()
    {
        settingsCanvas.enabled = false;
        volumeSlider.value = 0.5f;
        mainMenuMusic.Play();
        
        //DontDestroyOnLoad(this.gameObject);
       // menuOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameManagerScript.volume = slider.value;
        sliderText.text = "Volume: " + Mathf.Round(slider.value * 100);
        volume = volumeSlider.value;
        mainMenuMusic.volume = volume;
        /* if (Input.GetKeyDown(KeyCode.W))
         {
             Screen.SetResolution(800, 600, false);
             Debug.Log("Resoulution is 800, 600,");
         }  
         if (Input.GetKeyDown(KeyCode.S))
         {
             Screen.SetResolution(1920, 1080, false);
             Debug.Log("Resoulution is 1920, 1080");
         }*/

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            settingsCanvas.enabled = !settingsCanvas.enabled;
          // Debug.Log("Work");




        }

        if(settingsCanvas.enabled == true)
        {
            Time.timeScale = 0;
           // Time.fixedDeltaTime = 0;
            

        }
        else
        {

            Time.timeScale = 1;
           // Time.fixedDeltaTime = 1;
            
        }


    }
    public void close()
    {
        settingsCanvas.enabled = false;


    }


    public void open()
    {
        settingsCanvas.enabled = true;


    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void resolutionOption800x600()
    {
        Screen.SetResolution(800, 600, false);
    }


    public void resolutionOption1024x768()
    {
        Screen.SetResolution(1024, 768, false);
    }


    public void resolutionOption1280x1024()
    {
        Screen.SetResolution(1280, 1024, false);
    }


    public void resolutionOption1280x720()
    {
        Screen.SetResolution(1280, 720, false);
    }


    public void resolutionOption1366x768()
    {
        Screen.SetResolution(1366, 768, false);
    }


    public void resolutionOption1600x900()
    {
        Screen.SetResolution(1600, 900, false);
    }


    public void resolutionOption1280x800()
    {
        Screen.SetResolution(1280, 800, false);
    }

    public void resolutionOption1440x900()
    {
        Screen.SetResolution(1440, 900, false);
    }

    public void resolutionOption1680x1050()
    {
        Screen.SetResolution(1680, 1050, false);
    }

    public void resolutionOption1920by1080()
    {
        Screen.SetResolution(1920, 1080, false);
    }

    public void resolutionOption2560x1440()
    {
        Screen.SetResolution(2560, 1440, false);
    }

    public void fullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
