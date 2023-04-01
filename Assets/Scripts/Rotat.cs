using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotat : MonoBehaviour
{
    public List<GameObject> wiresInScene;

    private void Update() {
        //Diabolical...
        if (wiresInScene[0].GetComponent<wireScript>().isWireConnected && wiresInScene[1].GetComponent<wireScript>().isWireConnected && wiresInScene[2].GetComponent<wireScript>().isWireConnected && wiresInScene[3].GetComponent<wireScript>().isWireConnected && wiresInScene[4].GetComponent<wireScript>().isWireConnected)
        {
            print("Why oh god why...");
        }
    }
}