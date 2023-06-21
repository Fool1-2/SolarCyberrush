using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class l1Manager : MonoBehaviour
{
    public GeneratorManager generatorGM;

    private void Update() {
        if (generatorGM.isGeneratorsCompleted())
        {
            StartCoroutine(NextLevel());
        }
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(4);
    }
    
}
