using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwichScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void SceneSwitch(string scene)
    {
        SceneManager.LoadScene(1);
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            SceneManager.LoadScene(1);
        }

    }
}
