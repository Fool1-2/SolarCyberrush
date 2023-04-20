using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glow : MonoBehaviour
{
    public static bool isGlowActive;
    //public enum glowAbility{Light, Telekinesis, Growth}// An enum is also converted to ints kinda of like an array
    public int glowAB; 
    public static GameObject currentPossessedObj;

    
    private void OnEnable() {
        PlayerMovement.isPossessing = false;
    }
    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))//Turns on glow when G is pressed
        {
           // 

            isGlowActive = !isGlowActive;//Turns the bool off and on
            
            if (PlayerMovement.isPossessing == true)
            {
                Glow.currentPossessedObj.GetComponent<TeleObj>().isPoss = false;
                PlayerMovement.isPossessing = false;
            }
        }
    }
}

