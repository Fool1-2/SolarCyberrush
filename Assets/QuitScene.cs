using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitScene : MonoBehaviour
{
    public static Camera Camera;
    
    public Camera camera1;
    
    // Start is called before the first frame update
    void Start()
    {
        Camera = camera1;
        Camera.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buttonPressed()
    {
        //Debug.Log("HI");
        GameManagerScript.UnloadWirePuzzle();


    }
    public void cameraControl()
    {
        Camera.enabled = false;
        

    }
}
