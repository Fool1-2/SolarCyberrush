using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glow : MonoBehaviour
{
    public bool isGlowActive;
    //public enum glowAbility{Light, Telekinesis, Growth}// An enum is also converted to ints kinda of like an array
    public int glowAB; 
    public static GameObject currentPossessedObj;

    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.G) && !PlayerMovement.isPossessing)//Turns on glow when G is pressed
        {
            isGlowActive = !isGlowActive;//Turns the bool off and on
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Glow.currentPossessedObj.GetComponent<TeleObj>().isPoss = false;
        }
    }
}
