using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RythemScriptTest : MonoBehaviour
{
    public GameObject[] leftNotes;
    public GameObject[] rightNotes;
    public GameObject finalObject;
    public bool isActivated = false;
    [SerializeField]private bool restartNote = false;
    [SerializeField]private float timerObj;
    [SerializeField]private GSManager gsManager;
    [SerializeField]Color orginalColor;
    [SerializeField]Color activatedColor;

    // Update is called once per frame
    void Update()
    {
        if (gsManager.hasGameStarted)
        {
            if (!isActivated)
            {
                StartCoroutine(RythemBeat(gsManager.secPerBeat));
            }
            else
            {
                timerObj += Time.deltaTime;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (timerObj >= 0.01)
                    {
                        gsManager.NotesCompleted += 1;
                        print(gsManager.NotesCompleted);
                        RestartNotes();
                    }
                    else if(timerObj <= 1)
                    {
                        gsManager.NotesCompleted += 1;
                        print(gsManager.NotesCompleted);
                        RestartNotes();
                    }
                }

                if(timerObj >= 1.5f)
                {
                    print("Failed");
                    RestartNotes();
                    isActivated = false;
                }
            }

            if (restartNote)
            {
                StopCoroutine(RythemBeat(gsManager.secPerBeat));
            }
        }


    }

    void RestartNotes()
    {
        isActivated = false;
        timerObj = 0f;
        foreach (GameObject leftNote in leftNotes)
        {
            leftNote.SetActive(false);
        }
        foreach (GameObject rightNote in rightNotes)
        {
            rightNote.SetActive(false);
        }
        restartNote = false;
    }

    public IEnumerator RythemBeat(float timedBeat)
    {
        if (!restartNote)
        {
            for (int i = 0; i < leftNotes.Length; i++)    
            {
                leftNotes[i].SetActive(true);
                rightNotes[i].SetActive(true);
                yield return new WaitForSeconds(timedBeat);
            }
            isActivated = true;
        }



        

                                                   
    }
}
