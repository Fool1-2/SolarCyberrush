using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GSManager : MonoBehaviour
{
    [SerializeField]private GameObject[] leftNotes;
    [SerializeField]private GameObject[] rightNotes;
    [SerializeField]private Animation noteAnim;
    [SerializeField]private Animator anim;
    private bool isNoteRunning;
    private bool resetNotes;
    [SerializeField] private int totalNotes;
    private float noteTimer;
    public bool hasGameStarted = false;
    public int Timedifficulty;
    public int accuracyDifficulty;
    public int NotesCompleted;
    public int NotesSuceeded;
    bool gameFinished;
    bool didPlayerwin;
    int generatorNumber; 
    public AudioClip song;
    [SerializeField]AudioSource songProducer;
    public float songTime;
    public float songBPM;
    public float secPerBeat;
    
    // Start is called before the first frame update
    void Start()
    {
        songTime = song.length;
        secPerBeat = songBPM / 60f;
        isNoteRunning = false;
        hasGameStarted = true;

        anim = GetComponent<Animator>();
        noteAnim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Reset", resetNotes);
        anim.SetBool("CanPress", isNoteRunning);
        anim.SetFloat("AnimSpeed", secPerBeat);
        
        //If a note is being played counts down the timer for the player to press space. If they do press space notesSuceeded goes up. Then notes completed goes up and timer is reset
        if (hasGameStarted)
        {
            if (!isNoteRunning)
            {
                noteTimer = 0;
            }
            else
            {
                noteTimer += Time.deltaTime;
                if (noteTimer >= 1f)
                {
                    resetNotes = true;
                }
            }

            if (IsAllNotesActivated())
            {
                isNoteRunning = true;
            }
            else
            {
                isNoteRunning = false;
                resetNotes = false;
            }

            if (isNoteRunning)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (noteTimer <= 0.1 && noteTimer >= 0.001)
                    {
                        resetNotes = true;
                        NotesCompleted++;
                        print("NICE NICE YOOYOYOYO GABAGABA");                  
                    }
                    else if(noteTimer <= 0.3 && noteTimer >= 0.003)
                    {
                        resetNotes = true;
                        NotesCompleted++;
                        print("PRETTY GOOD GANGY");   
                    }
                    else if(noteTimer <= 0.6 && noteTimer >= 0.006)
                    {
                        resetNotes = true;
                        NotesCompleted++;
                        print("ok I mean, I guess");  
                    }
                }  
            } 
        }


        if (NotesCompleted == totalNotes)
        {
            gameFinished = true;
            if (totalNotes - NotesSuceeded >= accuracyDifficulty)
            {
                didPlayerwin = true;
                //indicates generator has been solved
                l1Manager.isGeneratorPuzzleCompleted[generatorNumber - 1] = true;
            }
            else
            {
                didPlayerwin = false;
            }
            //EndPuzzle();
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

    IEnumerator EndPuzzle()
    {
        if (didPlayerwin)
        {
            //Display win or lose
        }
        else
        {
            //idk flash all the lights or something to show you goofed
        }
        yield return new WaitForSeconds(5);
        //Need to change to load the first level
        SceneManager.LoadScene(0);
    }

    public void reset()
    {
        foreach (GameObject note in leftNotes)
        {
            note.SetActive(false);
        }
        foreach (GameObject note in rightNotes)
        {
            note.SetActive(false);
        }
    }
}
