using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    public gmScript gm;
    public int noteNumber;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GMOb").GetComponent<gmScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gm.hasNote[noteNumber - 1] = true;
            gm.noteNumber++;
            if (gm.noteNumber == 5 && gm.objectiveNumber == 2)
            {
                gm.objectiveNumber = 3;
                gm.objectiveText.text = "Current Objective: " + gm.ObjectivesList[3];
            }
            Destroy(gameObject);            
        }
    }
}
