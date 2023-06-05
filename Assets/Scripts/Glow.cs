using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glow : MonoBehaviour
{
    public static bool isGlowActive;
    public bool glowboolthing;
    //public enum glowAbility{Light, Telekinesis, Growth}// An enum is also converted to ints kinda of like an array
    public int glowAB; 
    public static GameObject currentPossessedObj;

    #region LightBridgeSettings
    public Transform lightCon1, lightCon2;
    [SerializeField]private GameObject lightBridgePrefab;
    private GameObject bridge;
    [HideInInspector]public bool isConnected;
    private float calculatedScale;
    private float rotation_Z;
    private float bridgeTimer;
    [Range(0, 20)]
    [SerializeField]private float bridgeEndTime;
    #endregion

    
    private void OnEnable() {
        PlayerMovement.isPossessing = false;
    }

    void Update()
    {
        #region activatingGlow 
        if (PlayerMovement.canMove && !PlayerMovement.isPaused)

        {
            #endregion activatingGlow 
            if (Input.GetKeyDown(KeyCode.Q))//Turns on glow when G is pressed 
            {

                isGlowActive = !isGlowActive;//Turns the bool off and on 

                if (PlayerMovement.isPossessing == true)
                {

                    isGlowActive = !isGlowActive;//Turns the bool off and on 
                    Glow.currentPossessedObj.GetComponent<TeleObj>().isPoss = false;
                    PlayerMovement.isPossessing = false;
                }

                #region LightBridgeController
                if (lightCon1 != null && lightCon2 != null)
                {
                    // 

                    isGlowActive = !isGlowActive;//Turns the bool off and on

                    if (PlayerMovement.isPossessing == true)
                    {
                        SpawnLightBridge();
                        bridgeTimer += Time.deltaTime;
                        if (bridgeTimer >= bridgeEndTime)
                        {
                            lightCon1.gameObject.GetComponent<LightBridgeConnector>().isActivated = false;
                            lightCon2.gameObject.GetComponent<LightBridgeConnector>().isActivated = false;
                            lightCon1 = null;
                            lightCon2 = null;
                            Destroy(bridge);
                            isConnected = false;
                        }
                    }
                }
                #endregion LightBridgeController
                if (!isConnected)
                {
                    bridgeTimer = 0;
                }

            }
        }
    

    }
    
    void SpawnLightBridge()
    {

        //Gets the middle positon between the two connectors and divids it by two
        Vector2 midPoint;
        midPoint.x = (lightCon1.position.x + lightCon2.position.x)/2;
        midPoint.y = (lightCon1.position.y + lightCon2.position.y)/2;


        if(bridge == null)
        {
            bridge = Instantiate(lightBridgePrefab, midPoint, Quaternion.identity);
            bridge.transform.position = midPoint;
            calculatedScale = Vector2.Distance(lightCon1.position, lightCon2.position) - 2;//This calculates the distance between the two points to get the right scale
            bridge.transform.localScale = new Vector2(calculatedScale, 10f);//Adds the scale to the objects x scale
            rotation_Z = Mathf.Atan2(lightCon2.position.y - lightCon1.position.y, lightCon2.position.x - lightCon1.position.x) * Mathf.Rad2Deg;//Gets the rotation needed between the two positions(complicated math dont ever ask me how to explain got it off of pure luck.)
            bridge.transform.rotation = Quaternion.Euler(0, 0, rotation_Z);//Adds the needed rotaton to the Z axis\
            lightCon1.gameObject.GetComponent<LightBridgeConnector>().isActivated = false;
            lightCon2.gameObject.GetComponent<LightBridgeConnector>().isActivated = false;
            lightCon1 = null;
            lightCon2 = null;

        }  
        else
        {
            Destroy(bridge);
            bridgeTimer = 0;
            SpawnLightBridge();
        }
    }
}

