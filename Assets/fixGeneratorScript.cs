using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using gameManager = GameManagerScript;//Turns the gamemanagerscript into a using state to be able to use a static function

public class fixGeneratorScript : MonoBehaviour, IInteractableScript
{
    [SerializeField]private GeneratorManager genManager;
    public static bool genCompleted;
    public static bool genInProgress;
    public int genNumID;
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
            if (GeneratorManager.isGeneratorPuzzleCompleted[genNumID - 1])
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
        if (!genManager.genInProgress)
        {
            if(!GeneratorManager.isGeneratorPuzzleCompleted[genNumID - 1])
            {
                genManager.curGenNumID = genNumID;
                gameManager.LoadPuzzle("Generator1Scene");
                PlayerMovement.canMove = false;
            }
        }
    }
}
