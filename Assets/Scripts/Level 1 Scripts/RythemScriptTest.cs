using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RythemScriptTest : MonoBehaviour
{
    /*
    [SerializeField]private GeneratorMiniGame gSManager;
    [SerializeField]private GameObject[] leftNotes;
    [SerializeField]private GameObject[] rightNotes;
    [SerializeField]private Animation noteAnim;
    [SerializeField]private Animator anim;
    [SerializeField]private bool canPlayerPress;
    private bool resetNotes; 
    [SerializeField]float circutTimer;


    private void Update() {
        //anim.SetBool("Reset", resetNotes);
        //anim.SetBool("CanPress", canPlayerPress);

        if (gSManager.hasGameStarted)
        {
            if (!canPlayerPress)
            {
                circutTimer = 0;
                //anim.SetFloat("AnimSpeed", gSManager.secPerBeat);
                anim.Play("NoteAnim");
            }

            if (IsAllNotesActivated())
            {
                canPlayerPress = true;
            }
            else
            {
                canPlayerPress = false;
                resetNotes = false;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (circutTimer <= 0.1 && circutTimer >= 0.001)
                {
                    resetNotes = true;
                    //gSManager.NotesCompleted++;
                    print("NICE NICE YOOYOYOYO GABAGABA");                  
                }
                else if(circutTimer <= 0.3 && circutTimer >= 0.003)
                {
                    resetNotes = true;
                    //gSManager.NotesCompleted++;
                    print("PRETTY GOOD GANGY");   
                }
                else if(circutTimer <= 0.6 && circutTimer >= 0.006)
                {
                    resetNotes = true;
                    //gSManager.NotesCompleted++;
                    print("ok I mean, I guess");  
                }
            }   

            if (canPlayerPress)
            {
                circutTimer += Time.deltaTime;
                if (circutTimer >= 1f)
                {
                    resetNotes = true;
                }
            }

        }
    }

    bool IsAllNotesActivated()
    {
        for (int i = 0; i < 3; i++)
        {
            if (!leftNotes[i].activeInHierarchy && !rightNotes[i].activeInHierarchy)
            {
                return false;
            }
        }

        return true;
    }
    */
}
