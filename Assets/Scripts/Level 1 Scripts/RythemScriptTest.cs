using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RythemScriptTest : MonoBehaviour
{
    public GameObject[] leftObjects;
    public GameObject[] rigthObjects;
    public GameObject finalObject;
    public bool isActivated;

    public float timerSong;
    public float beatTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActivated)
        {
            //StartCoroutine(RythemBeat());
        }
    }

    public IEnumerator RythemBeat(float timedBeat)
    {
        for (int i = 0; i < leftObjects.Length; i++)    
        {
            leftObjects[i].SetActive(true);
            rigthObjects[i].SetActive(true);
            yield return new WaitForSeconds(1f);
        }

        isActivated = false;
        foreach (GameObject leftObj in leftObjects)
        {
            leftObj.SetActive(false);
        }
        foreach (GameObject rightObj in rigthObjects)
        {
            rightObj.SetActive(false);
        }

                                                   
    }
}
