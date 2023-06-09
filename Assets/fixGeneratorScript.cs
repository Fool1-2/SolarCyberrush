using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using gameManager = GameManagerScript;//Turns the gamemanagerscript into a using state to be able to use a static function

public class fixGeneratorScript : MonoBehaviour, IInteractableScript
{
    public static bool genCompleted;
    public static bool genInProgress;
    public Collider2D bc;
    public TMP_Text promptText;
    public string curText = "";
    bool ishere;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        promptText.text = curText;

        if (ishere)
        {
            if (genCompleted)
            {
                curText = "";

            }
            else
            {
                curText = "Press E to fix the generator";

            }
            if (gameManager.isSceneLoaded == false)
            {
                genInProgress = false;
            }
        }

    }
    public void Interact()
    {
        if (!genInProgress)
        {
            if (genCompleted)
            {

            }
            else
            {
                gameManager.LoadPuzzle("Generator1Scene");
                genInProgress = true;
                PlayerMovement.canMove = false;
            }
        }
    }
}
