using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glow : MonoBehaviour
{
    public static bool isGlowActive;
    //public enum glowAbility{Light, Telekinesis, Growth}// An enum is also converted to ints kinda of like an array
    public int glowAB; 
    public static GameObject currentPossessedObj;
    [SerializeField]private bool isConnected;
    public Transform lightCon1, lightCon2;
    [SerializeField]private GameObject lightBridge;
    Vector2 bridgeScale;
    [SerializeField]private float calculatedScale;
    GameObject bridge;
    
    private void OnEnable() {
        PlayerMovement.isPossessing = false;
    }
    
    void Update()
    {
        #region activatingGlow
        if (Input.GetKeyDown(KeyCode.Q))//Turns on glow when G is pressed
        {
            isGlowActive = !isGlowActive;//Turns the bool off and on
            
            if (PlayerMovement.isPossessing == true)
            {
                Glow.currentPossessedObj.GetComponent<TeleObj>().isPoss = false;
                PlayerMovement.isPossessing = false;
            }
        }
        #endregion

        if (isConnected)
        {
            SpawnLightBridge();
        }

    }

    void SpawnLightBridge()
    {
        Vector2 midPoint;
        midPoint.x = (lightCon1.position.x + lightCon2.position.x)/2;
        midPoint.y = (lightCon1.position.y + lightCon2.position.y)/2;
         

        if(bridge == null)
        {
            bridge = Instantiate(lightBridge, midPoint, Quaternion.identity);
        }  
        else
        {
            calculatedScale = Vector2.Distance(lightCon1.position, lightCon2.position) - 2;
            bridge.transform.localScale = new Vector2(calculatedScale, 10f);
            
        }
    }

    float CheckIfNegative(float numberInQuestion)
    {
        float returnNumber;

        if (numberInQuestion < 0)
        {
            returnNumber = numberInQuestion * -1;
            numberInQuestion = returnNumber;
            
        }

        return numberInQuestion;
        
    }
}

