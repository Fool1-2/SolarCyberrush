using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEditor;
using System;
using System.IO;


public class DataPersitanceManager : MonoBehaviour
{
    public static DataPersitanceManager instance {get; private set;}//The variable to call the New, Load, and Save game functions
    private GameData gameData;
    List<IDataPersitance> dataPersitances;
    public string fileName;
    public static string fullPathFile;
    private FileHandler fileData;
    public static Vector2 playerSpawn;

    private void OnValidate() {
        fullPathFile = Path.Combine(Application.persistentDataPath, fileName);
    }
    
    private void Awake() {

        if (instance == null)
        {
            playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform.position;
            instance = this;//If instance is null make this object/script the new instance
        }
        this.fileData = new FileHandler(Application.persistentDataPath, fileName);
        this.dataPersitances = FindAllDataPersitance();
        LoadGame();

        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;

    }

    private void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        this.dataPersitances = FindAllDataPersitance();
        LoadGame();
    }

    public void OnSceneUnloaded(Scene scene)
    {
        SaveGame();
    }

    public void NewGame()
    {
        gameData = new GameData();//If this function is called revert back to normal settings.
    }
    public void LoadGame()
    {
        this.gameData = fileData.Load();

        if (gameData == null)
        {
            NewGame();//if there is no gamedata then start a new game
        }

        foreach (IDataPersitance dataPer in dataPersitances)
        {
            dataPer.LoadData(gameData);
        }
    }
    public void SaveGame()
    {
        
        foreach (IDataPersitance dataPer in dataPersitances)
        {
            dataPer.SaveData(ref gameData);
        }


        fileData.Save(gameData);
    }

    private List<IDataPersitance> FindAllDataPersitance()
    {
        IEnumerable<IDataPersitance> dataPer = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersitance>();//
        return new List<IDataPersitance>(dataPer);//Adds all of the objects it found into the functions list.
    }
}
