using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagerScript = gmScript;


public class GeneratorManager : MonoBehaviour
{
    public List<bool> isGeneratorPuzzleCompleted;
    public int curGenNumID;
    public bool genInProgress;
    public GeneartorScriptable curgGenScriptable; 
    [HideInInspector]public bool firstGen;
    [SerializeField]private GameObject playerObj;

    // Update is called once per frame
    void Update()
    {   
        if (genInProgress)
        {
            playerObj.SetActive(false);
        }
        else
        {
            playerObj.SetActive(true);
        }

        if (!isGeneratorsCompleted())
        {
           // DontDestroyOnLoad(this.gameObject);
        }
    }

    public bool isGeneratorsCompleted()
    {
        for (int i = 0; i < isGeneratorPuzzleCompleted.Capacity; i++)
        {
            if (!isGeneratorPuzzleCompleted[i])
            {
                return false;
            }
        }
        return true;
    }
}
