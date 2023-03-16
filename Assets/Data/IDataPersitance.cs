using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersitance
{
    public void LoadData(GameData gameData);
    public void SaveData(ref GameData gameData);
}
