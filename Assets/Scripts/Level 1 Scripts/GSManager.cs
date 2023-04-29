using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GSManager : MonoBehaviour
{
    public bool hasGameStarted = false;
    public int Timedifficulty;
    public int accuracyDifficulty;
    float noteTimer;
    public int NotesCompleted;
    int NotesSuceeded;
    bool isNoteRunning;
    [SerializeField] int totalNotes;
    bool gameFinished;
    bool didPlayerwin;
    int generatorNumber;

    public List<GameObject> NoteObjects;

    public AudioClip song;
    [SerializeField]AudioSource songProducer;
    public float songTime;
    public float songBPM;
    public float secPerBeat;
    
    // Start is called before the first frame update
    void Start()
    {
        songTime = song.length;
        secPerBeat = songBPM/60f;
        isNoteRunning = true;
        hasGameStarted = true;
        if (isNoteRunning)
        {
            songProducer.PlayOneShot(song);
        }
    }

    // Update is called once per frame
    void Update()
    {

        /*
        //If a note is being played counts down the timer for the player to press space. If they do press space notesSuceeded goes up. Then notes completed goes up and timer is reset
        if (isNoteRunning)
        {
            noteTimer += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                NotesCompleted++;
                NotesSuceeded++;
                isNoteRunning = false;
            }
            else if (noteTimer > Timedifficulty)
            {
                NotesCompleted++;
                isNoteRunning = false;
            }
        }
        else
        {
            noteTimer = 0;
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
            EndPuzzle();
        }
        */
    }

    public void noteSucessCheck()
    {
        isNoteRunning = true;
    }

    IEnumerator EndPuzzle()
    {
        //Need to change to load the first level
        if (didPlayerwin)
        {
            //Display win or lose
        }
        else
        {
            //idk flash all the lights or something to show you goofed
        }
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }

    public void reset()
    {
        for (int i = 0; i < NoteObjects.Capacity; i++)
        {
            NoteObjects[i].GetComponent<TimerObjectScript>().reset();
        }
    }
}
