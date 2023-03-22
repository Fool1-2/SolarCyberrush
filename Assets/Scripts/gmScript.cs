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
    public Sprite noteImageSprite;
    public Sprite noteSol1;
    public Image noteImage;
    //

    // Start is called before the first frame update
    void Start()
    {
        //Note you cannot set the sprite on a disabled object
        noteImageSprite = GameObject.Find("NoteImage").GetComponent<Sprite>();
        noteImageSprite = noteSol1;
        noteCanvas.enabled = false;
        objectiveText.text = "Current Objective: " + ObjectivesList[0];
    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Note displays
        if (Input.GetKeyDown(KeyCode.Alpha1) && hasNote[0] == true)
        {
            noteUIUp(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && hasNote[1] == true)
        {
            noteUIUp(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && hasNote[2] == true)
        {
            noteUIUp(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && hasNote[3] == true)
        {
            noteUIUp(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5) && hasNote[4] == true)
        {
            noteUIUp(5);
        }
        if (!ExitDoorScript.wirePuzzleCompleted)
        {
            objectiveText.text = "Find the locker and retrieve the keys";
        }
    }
    
    void ReloadPlayer()
    {
        //Instantiate(player, curPlayerPos, Quaternion.identity);
    }
    public void closeMenu()
    {
        noteCanvas.enabled = false;
        Time.timeScale = 1;
    }
    public void noteUIUp(int noteNumber)
    {
        Time.timeScale = 0;
        noteCanvas.enabled = true;
        noteImageSprite = NoteSprites[noteNumber - 1];
        noteImage.sprite = noteImageSprite;
    }
}
