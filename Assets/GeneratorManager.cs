using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagerScript = gmScript;


public class GeneratorManager : MonoBehaviour
{
    public List<bool> isGeneratorPuzzleCompleted;
    [SerializeField]private int amountOfGen;
    public int curGenNumID;
    public bool genInProgress;

    // Update is called once per frame
    void Update()
    {
        //isGeneratorPuzzleCompleted.Capacity = amountOfGen;
        if (!isGeneratorsCompleted())
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    bool isGeneratorsCompleted()
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

    bool IsGeneratorsCompleted()
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
