using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagerScript = gmScript;


public class GeneratorManager : MonoBehaviour
{
    public static List<bool> isGeneratorPuzzleCompleted;

    //bool allGenCompleted;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (!IsGeneratorsCompleted())
        {
            DontDestroyOnLoad(this.gameObject);
        }
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
