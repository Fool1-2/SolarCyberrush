using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using dataPerManager = DataPersitanceManager;

[System.Serializable]
public class GameData
{
    public Vector2 playerPos;
    

    public GameData()
    {
        playerPos = DataPersitanceManager.playerSpawn;
    }

}
