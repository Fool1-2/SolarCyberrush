using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class l1Manager : MonoBehaviour
{
    public GeneratorManager generatorGM;
    public Camera panCam;
    public Camera mainCam;
    public GameObject swicther1;
    public GameObject swicther2;
    public GameObject swicther3;
    public GameObject swicther4;
    public static bool panCamOn;


    private void Update() {
        if (generatorGM.isGeneratorsCompleted())
        {
            StartCoroutine(NextLevel());
        }
    }

    IEnumerator NextLevel()
    {
        swicther1.SetActive(false);
        swicther2.SetActive(false);
        swicther3.SetActive(false);
        swicther4.SetActive(false);
       // mainCam.enabled = false;
        panCamOn = true;
        yield return new WaitForSeconds(1f);
       // panCam.enabled = true;
        yield return new WaitForSeconds(22f);
        SceneManager.LoadScene(4);
    }
    
}
