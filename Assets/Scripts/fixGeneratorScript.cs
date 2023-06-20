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
    [SerializeField]private GeneartorScriptable genScriptable;

    public static bool genCompleted;
    //public bool genInProgress;
    public int genNumID;
    public TMP_Text promptText;
    public string curText = "";
    bool ishere;

    // Start is called before the first frame update
    private void Awake() {
        genManager.genInProgress = false;
    }

    // Update is called once per frame
    void Update()
    {
        promptText.text = curText;
        

        if (ishere)
        {
            if (genManager.isGeneratorPuzzleCompleted[genNumID - 1])
            {
                curText = "";

            }
            else
            {
                curText = "Press E to fix the generator";

            }
        }
        

    }
    public void Interact()
    {
        if (!genManager.genInProgress)
        {
            if(!genManager.isGeneratorPuzzleCompleted[genNumID - 1])
            {
                genManager.curGenNumID = genNumID;
                genManager.curgGenScriptable = genScriptable;
                PlayerMovement.canMove = false;
                genManager.genInProgress = true;
                gameManager.LoadPuzzle("Generator1Scene");
            }
        }
    }
}
