using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glow : MonoBehaviour
{
    public bool isGlowActive;
    public enum glowAbility{Light, Telekinesis, Growth}// An enum is also converted to ints kinda of like an array
    public glowAbility glowAB; 
    public static GameObject currentPossessedObj;

    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.G))//Turns on glow when G is pressed
        {
            isGlowActive = !isGlowActive;//Turns the bool off and on
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))//Goes to the last glow ability
        {
            if ((int)glowAB == 0)//If it hits the lowest glow number than it will go up to highest number(The last glow)
            {
                glowAB += 3;
            }
            glowAB -= 1;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))//Goes to the next glow ability
        {
            if ((int)glowAB == 2)//If it hits the max glow number than it will go back to 0(The first glow)
            {
                glowAB -= 3;
            }
            glowAB += 1;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerMovement.isPossessing = false;
            Glow.currentPossessedObj.GetComponent<TeleObj>().isPoss = false;
        }
    }
}
