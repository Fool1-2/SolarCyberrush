using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerObjectScript : MonoBehaviour
{
    private GSManager GS;
    public float Initialtimer;
    public float timer;
    bool noteHasNotPlayed = true;
    // Start is called before the first frame update
    void Start()
    {
        GS = GameObject.Find("GeneratorSceneManager").GetComponent<GSManager>();
        timer = Initialtimer;
    }

    // Update is called once per frame
    void Update()
    {
        //While game is playing the timer decreases
        if (GS.hasGameStarted && noteHasNotPlayed)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            //If the game isnt playing the timer is always the same as the initial timer
            reset();
        }
        /*Use something like this to call your visuals early
        if (timer < 1 && bool this function has not been called yet)
        You can change the timer value to make it call earlier before the note. If call a function in this if statement. */
        if (timer < 0)
        {
            GS.noteSucessCheck();
            noteHasNotPlayed = false;

        }
    }

    public void reset()
    {
        timer = Initialtimer;
        noteHasNotPlayed = true;
    }

}
