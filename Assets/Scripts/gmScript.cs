using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gmScript : MonoBehaviour
{
    public List<string> ObjectivesList;
    public TMP_Text objectiveText;
    public int objectiveNumber;
    public GameObject player;
    public Vector2 curPlayerPos = new Vector2(-14f, -5.5f);
    public List<Vector2> instantiatePositions;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        objectiveText.text = "Current Objective: " + ObjectivesList[objectiveNumber];
            
    }
    

}
