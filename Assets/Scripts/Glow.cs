using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.InputSystem;

public class Glow : MonoBehaviour
{
    public static bool isGlowActive;
    public static int glowType;
    [SerializeField]private Light2D _glowLight;
    [Range(1, 10)]
    [SerializeField]private float _glowLightIntensity;
    [SerializeField]private Color[] _glowColor;
    
    [SerializeField]private GameObject _glowShooterArm;
    public static GameObject currentPossessedObj;

    public AudioSource glowActivate;
    public AudioSource glowChangeSound;
    [SerializeField]private Camera camA;

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

    
    private void OnEnable() 
    {
        PlayerMovement.isPossessing = false;
        glowActivate = GameObject.Find("GlowActivateSound").GetComponent<AudioSource>();
        glowChangeSound = GameObject.Find("GlowChangeSound").GetComponent<AudioSource>();
    }

    void Update()
    {
        
        if (isGlowActive)
        {
            _glowShooterArm.SetActive(true);
            _glowLight.color = _glowColor[glowType];
            _glowLight.intensity = _glowLightIntensity;
            PlayerMovement.canPlayerInteract = false;

            /*
            var gamepadTest = Gamepad.current;
            var mouse = Mouse.current;

            var look = camA.WorldToScreenPoint(gamepadTest.leftStick.ReadValue() * 8);
            mouse.WarpCursorPosition(look);
            print(look);
            */
            

            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.JoystickButton5))
            {
                glowType++;
                if (glowType > 1)
                {
                    glowType = 0;
                }
                glowChangeSound.Play();
            }
        }
        else
        {
            _glowShooterArm.SetActive(false);
            _glowLight.intensity = 0;
            PlayerMovement.isPossessing = false;
            PlayerMovement.canPlayerInteract = true;
        }

        switch (glowType)
        {
           case 0:
                _glowLight.color = _glowColor[glowType];
                break;
           case 1:
                _glowLight.color = _glowColor[glowType];
                break;
        }

        #region activatingGlow 
        if (PlayerMovement.canMove && !PlayerMovement.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.JoystickButton4))//Turns on glow when G is pressed 
            {

                isGlowActive = !isGlowActive;//Turns the bool off and on 
                glowActivate.Play();

                if (PlayerMovement.isPossessing == true)
                {
                    isGlowActive = false;//Turns the bool off and on 
                    Glow.currentPossessedObj.GetComponent<TeleObj>().isPoss = false;
                    PlayerMovement.isPossessing = false;
                }
            }

            if (lightCon1 != null && lightCon2 != null)
            {
                //isGlowActive = !isGlowActive;//Turns the bool off and on

                if (PlayerMovement.isPossessing == false)
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

            if (!isConnected)
            {
                bridgeTimer = 0;
            }

        }
        #endregion activatingGlow 

    }

    void SpawnLightBridge()
    {

        //Gets the middle positon between the two connectors and divids it by two


        if (bridge == null)
        {
            Vector2 midPoint;
            midPoint.x = (lightCon1.position.x + lightCon2.position.x) / 2;
            midPoint.y = (lightCon1.position.y + lightCon2.position.y) / 2;


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
        }
    }
}

