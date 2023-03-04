using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gmScript : MonoBehaviour
{
    public List<string> ObjectivesList;
    public TMP_Text objectiveText;
    public int objectiveNumber = 0;
    public int noteNumber = 0;

    public GameObject player;
    public Vector2 curPlayerPos = new Vector2(-14f, -5.5f);
    public List<Vector2> instantiatePositions;

    //Stuff for the notes
    public Canvas noteCanvas;
    public List<bool> hasNote;
    //The note displays
    public List<Sprite> NoteSprites;
    Image NoteImage;

    //

    // Start is called before the first frame update
    void Start()
    {
        noteCanvas.enabled = false;
        objectiveText.text = "Current Objective: " + ObjectivesList[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (objectiveNumber == 1 && GrateScript.slidePuzzleCompleted)
        {
            objectiveNumber++;
            objectiveText.text = "Current Objective: " + ObjectivesList[objectiveNumber] + "(" + noteNumber + "/5).";
        }
        //Note displays
        if (Input.GetKeyDown(KeyCode.Alpha1) && hasNote[0] == true)
        {
            NoteImage.sprite = NoteSprites[0];
            Debug.Log("I Did a thing");
            noteCanvas.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && hasNote[1] == true)
        {
            NoteImage.sprite = NoteSprites[1];
            noteCanvas.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && hasNote[2] == true)
        {
            NoteImage.sprite = NoteSprites[2];
            noteCanvas.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && hasNote[3] == true)
        {
            NoteImage.sprite = NoteSprites[3];
            noteCanvas.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5) && hasNote[4] == true)
        {
            NoteImage.sprite = NoteSprites[4];
            noteCanvas.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            OnLevelWasLoaded(1);
        }
    }
    private void OnLevelWasLoaded(int level)
    {
        if (level == 1)
        {
            if (!GrateScript.slidePuzzleCompleted)
            {
                curPlayerPos = instantiatePositions[0];
            }
            else
            {
                curPlayerPos = instantiatePositions[1];
            }
            ReloadPlayer();
        }
    }
    void ReloadPlayer()
    {
        Instantiate(player, curPlayerPos, Quaternion.identity);
    }
    public void closeMenu()
    {
        noteCanvas.enabled = false;
    }

}
