using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SGameManager : MonoBehaviour
{
    public PlaceHolderSaveScript saveManager;
    public static bool isWin;
    

    // Start is called before the first frame update
    void Start()
    {
        saveManager = GameObject.Find("SaveSceneGM").GetComponent<PlaceHolderSaveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWin)
        {
            saveManager.Load_Scene();
        }
    }
}
