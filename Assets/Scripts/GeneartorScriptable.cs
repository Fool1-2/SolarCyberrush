using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Geneartor Settings", menuName = "Generator Settings/New Generator Settings")]
public class GeneartorScriptable : ScriptableObject
{
    public int rounds;
    public List<float> roundSpeed;
    public int notesNeededToPass;

    [Tooltip("MaxGen should be a 1 decimal(0.1) and MinGen should be 3 decimals(0.0003)")]
    public float MaxGenTime, MinGenTime;
    [Range(0, 5)]public float Timedifficulty;
}
