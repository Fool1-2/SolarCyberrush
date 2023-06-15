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
    [SerializeField] GameObject build1GlobalLight;
    [SerializeField] GameObject build2GlobalLight;
    GeneratorManager genManager;


    // Start is called before the first frame update
    void Start()
    {
        globalLight.SetActive(false);
        build1GlobalLight.SetActive(false);
        build2GlobalLight.SetActive(false);
        for (int i = 0; i < building1Lights.Count; i++)
        {
            building1Lights[i].SetActive(true);
        }
        for (int i = 0; i < building2Lights.Count; i++)
        {
            building2Lights[i].SetActive(true);
        }
        for (int i = 0; i < building3Lights.Count; i++)
        {
            building3Lights[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void checkLights()
    {
        if (genManager.isGeneratorPuzzleCompleted[2])
        {
            globalLight.SetActive(true);
            for (int i = 0; i < building3Lights.Count; i++)
            {
                building3Lights[i].SetActive(false);
            }
            build1GlobalLight.SetActive(false);
            build2GlobalLight.SetActive(false);
        }
        if (genManager.isGeneratorPuzzleCompleted[0] && !genManager.isGeneratorPuzzleCompleted[2])
        {
            build1GlobalLight.SetActive(true);
            for (int i = 0; i < building1Lights.Count; i++)
            {
                building1Lights[i].SetActive(false);
            }
        }
      
        if (genManager.isGeneratorPuzzleCompleted[1] && !genManager.isGeneratorPuzzleCompleted[2])
        {
            build2GlobalLight.SetActive(true);
            for (int i = 0; i < building2Lights.Count; i++)
            {
                building2Lights[i].SetActive(false);
            }
        }
    }
}
