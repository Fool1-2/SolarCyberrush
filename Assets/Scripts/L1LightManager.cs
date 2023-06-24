using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1LightManager : MonoBehaviour
{
    //These lists contain the light object not the object with the sprite
    public List<GameObject> building1Lights;
    public List<GameObject> building2Lights;
    public List<GameObject> building3Lights;
    [SerializeField] GameObject globalLight;
    //[SerializeField] GameObject build1GlobalLight;
    //[SerializeField] GameObject build2GlobalLight;
    [SerializeField] GeneratorManager genManager;
    [SerializeField] GameObject building1LightObject;
    [SerializeField] GameObject building2LightObject;
    [SerializeField] GameObject building3LightObject;

    // Start is called before the first frame update
    void Start()
    {
        genManager = GameObject.Find("GeneratorManager").GetComponent<GeneratorManager>();
        globalLight.SetActive(false);
        //build1GlobalLight.SetActive(false);
        //build2GlobalLight.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (genManager != null)
        {
            Debug.Log("Gen is not null");
        }

    }

    public void checkLights()
    {
        if (genManager.isGeneratorPuzzleCompleted[2])
        {
            //globalLight.SetActive(true);
            for (int i = 0; i < building3Lights.Count; i++)
            {
                building3Lights[i].GetComponent<lightFlickerScript>().genPowered();
            }
            building3LightObject.SetActive(true);
            //build1GlobalLight.SetActive(false);
            //build2GlobalLight.SetActive(false);
        }
        if (genManager.isGeneratorPuzzleCompleted[0] && !genManager.isGeneratorPuzzleCompleted[2])
        {
            //build1GlobalLight.SetActive(true);
            for (int i = 0; i < building1Lights.Count; i++)
            {
                building1Lights[i].GetComponent<lightFlickerScript>().genPowered();
            }
            building1LightObject.SetActive(true);
        }
      
        if (genManager.isGeneratorPuzzleCompleted[1] && !genManager.isGeneratorPuzzleCompleted[2])
        {
            //build2GlobalLight.SetActive(true);
            for (int i = 0; i < building2Lights.Count; i++)
            {
                building2Lights[i].GetComponent<lightFlickerScript>().genPowered();
            }
            building2LightObject.SetActive(true);
        }
    }
}
