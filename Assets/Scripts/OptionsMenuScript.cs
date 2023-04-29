using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OptionsMenuScript : MonoBehaviour
{
    public Canvas settingsCanvas;
    public Slider slider;
    public TMP_Text sliderText;
    // Start is called before the first frame update
    void Start()
    {
        settingsCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameManagerScript.volume = slider.value;
        sliderText.text = "Volume: " + Mathf.Round(slider.value * 100);
        if (Input.GetKeyDown(KeyCode.W))
        {
            Screen.SetResolution(800, 600, false);
            Debug.Log("Resoulution is 800, 600,");
        }  
        if (Input.GetKeyDown(KeyCode.S))
        {
            Screen.SetResolution(1920, 1080, false);
            Debug.Log("Resoulution is 1920, 1080");
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
}
